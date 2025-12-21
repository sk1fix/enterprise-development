using BikeRentalPoint.Application.Contracts.Rent;

namespace BikeRentalPoint.Generator.Kafka.Host.Interfaces;

/// <summary>
/// Abstraction for a service that publishes batches of rent contracts to an external message transport
/// </summary>
public interface IProducerService
{
    /// <summary>
    /// Asynchronously sends a batch of <see cref="CreateRentDto"/> messages to the underlying transport
    /// </summary>
    /// <param name="batch">The collection of rent contracts to be published as a single batch</param>
    /// <returns>A task that represents the asynchronous send operation</returns>
    public Task SendAsync(IList<CreateRentDto> batch);
}