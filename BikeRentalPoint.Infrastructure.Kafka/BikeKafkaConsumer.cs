using BikeRentalPoint.Application.Contracts.Rent;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace BikeRentalPoint.Infrastructure.Kafka;
/// <summary>
/// Background service for consuming bike rental requests from Kafka topics
/// </summary>
/// <param name="consumer">Kafka consumer instance for processing rental messages</param>
/// <param name="scopeFactory">Factory for creating service scopes for dependency resolution</param>
/// <param name="configuration">Application configuration for accessing Kafka settings</param>
/// <param name="logger">Logger for tracking consumer activities and errors</param>
public class BikeKafkaConsumer(IConsumer<Guid, IList<CreateRentDto>> consumer, IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger<BikeKafkaConsumer> logger) : BackgroundService
{
    private readonly string _topicName = configuration.GetSection("Kafka")["TopicName"] ?? throw new KeyNotFoundException("TopicName section of Kafka is missing");

    /// <summary>
    /// Main execution method for the background service
    /// </summary>
    /// <param name="stoppingToken">Cancellation token to stop the consumer service</param>
    /// <returns>Task representing the asynchronous operation</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        await Task.Yield();
        await Consume(stoppingToken);
    }

    /// <summary>
    /// Continuously consumes rental contracts from Kafka topic and processes them
    /// </summary>
    /// <param name="stoppingToken">Cancellation token to stop consumption</param>
    /// <returns>Task representing the consumption process</returns>
    private async Task Consume(CancellationToken stoppingToken)
    {
        consumer.Subscribe(_topicName);
        logger.LogInformation("Consumer successfully subscribed to topic {topic}", _topicName);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Consuming from topic {topic} via consumer {consumer}", _topicName, consumer.Name);
                var consumeResult = consumer.Consume(stoppingToken);

                using var scope = scopeFactory.CreateScope();
                var rentService = scope.ServiceProvider.GetRequiredService<IRentService>();
                foreach (var contract in consumeResult.Message.Value)
                {
                    await rentService.Create(contract);
                }
                logger.LogInformation("Successfully consumed message {key} from topic {topic} via consumer {consumer}", consumeResult.Message.Key, _topicName, consumer.Name);
                consumer.Commit();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occured during receiving contracts from {topic}", _topicName);
        }
    }
}

