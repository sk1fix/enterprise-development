using BikeRentalPoint.Application.Contracts.Rent;
using BikeRentalPoint.Generator.Kafka.Host.Interfaces;
using Confluent.Kafka;

namespace BikeRentalPoint.Generator.Kafka.Host;

/// <summary>
/// Kafka producer service responsible for publishing batches of <see cref="CreateRentDto"/> messages to a configured topic
/// </summary>
/// <param name="configuration">Application configuration used to resolve Kafka settings, including the target topic name</param>
/// <param name="producer">Typed Kafka producer instance for sending messages with <see cref="Guid"/> keys and rent batch payloads</param>
/// <param name="logger">Logger used to record diagnostic and error information during message publishing</param>
public class BikeRentalPointKafkaProducer(IConfiguration configuration, IProducer<Guid, IList<CreateRentDto>> producer, ILogger<BikeRentalPointKafkaProducer> logger) : IProducerService
{
    private readonly string _topicName = configuration.GetSection("Kafka")["TopicName"] ?? throw new KeyNotFoundException("TopicName section of Kafka is missing");

    /// <summary>
    /// Asynchronously sends a batch of rent contracts to the configured Kafka topic as a single message
    /// </summary>
    /// <param name="batch">The collection of <see cref="CreateRentDto"/> instances to be published</param>
    /// <returns>A task that represents the asynchronous send operation</returns>
    public async Task SendAsync(IList<CreateRentDto> batch)
    {
        try
        {
            logger.LogInformation("Sending a batch of {count} contracts to {topic}", batch.Count, _topicName);
            var message = new Message<Guid, IList<CreateRentDto>>
            {
                Key = Guid.NewGuid(),
                Value = batch
            };
            await producer.ProduceAsync(_topicName, message);

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occured during sending a batch of {count} contracts to {topic}", batch.Count, _topicName);
        }
    }
}
