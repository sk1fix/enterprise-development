using BikeRentalPoint.Application.Contracts.Rent;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace BikeRentalPoint.Infrastructure.Kafka;
/// <summary>
/// Background Kafka consumer that subscribes to a configured topic and processes batches of <see cref="CreateRentDto"/> messages by delegating to <see cref="IRentService"/>
/// </summary>
/// <param name="consumer">Typed Kafka consumer instance for reading messages with <see cref="Guid"/> keys and rent batch payloads</param>
/// <param name="scopeFactory">Factory used to create DI scopes for resolving scoped services such as <see cref="IRentService"/></param>
/// <param name="configuration">Application configuration used to resolve Kafka settings, including the target topic name</param>
/// <param name="logger">Logger used to record diagnostic, warning, and error information during consumption and processing</param>
public sealed class BikeKafkaConsumer(IConsumer<Guid, IList<CreateRentDto>> consumer, IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger<BikeKafkaConsumer> logger) : BackgroundService
{
    private readonly string _topicName =
        configuration.GetSection("Kafka")["TopicName"] ?? throw new KeyNotFoundException("TopicName section of Kafka is missing");

    /// <summary>
    /// Executes the consumer loop: subscribes to the Kafka topic, continuously consumes messages, processes each rent contract in the batch, and commits the offsets on success
    /// </summary>
    /// <param name="stoppingToken">Cancellation token used to gracefully stop the consumer loop and close the underlying Kafka connection</param>
    /// <returns>A task that represents the lifetime of the background consumer operation</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield();

        try
        {
            consumer.Subscribe(_topicName);
            logger.LogInformation("Consumer successfully subscribed to topic {topic}", _topicName);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to subscribe consumer {consumer} to topic {topic}", consumer.Name, _topicName);
            return;
        }

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(stoppingToken);

                    if (consumeResult?.Message?.Value is null || consumeResult.Message.Value.Count == 0)
                        continue;

                    logger.LogInformation(
                        "Consumed message {key} from topic {topic} via consumer {consumer}",
                        consumeResult.Message.Key, _topicName, consumer.Name);

                    using var scope = scopeFactory.CreateScope();
                    var rentService = scope.ServiceProvider.GetRequiredService<IRentService>();

                    foreach (var contract in consumeResult.Message.Value)
                    {
                        try
                        {
                            await rentService.Create(contract);
                        }
                        catch (KeyNotFoundException ex)
                        {
                            logger.LogWarning(ex, "Skipping invalid appointment contract BikeId={bikeId} RenterId={renterId}", contract.BikeId, contract.RenterId);
                        }
                    }

                    consumer.Commit(consumeResult);

                    logger.LogInformation(
                        "Successfully processed and committed message {key} from topic {topic} via consumer {consumer}",
                        consumeResult.Message.Key, _topicName, consumer.Name);
                }
                catch (ConsumeException ex) when (ex.Error.Code == ErrorCode.UnknownTopicOrPart)
                {
                    logger.LogWarning("Topic {topic} is not available yet, waiting...", _topicName);
                    await Task.Delay(2000, stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to consume or process message from topic {topic}", _topicName);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
        finally
        {
            try
            {
                consumer.Close();
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Error during consumer close");
            }
        }
    }
}