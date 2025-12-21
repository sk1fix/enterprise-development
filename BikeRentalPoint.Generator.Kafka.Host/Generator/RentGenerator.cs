using BikeRentalPoint.Application.Contracts.Rent;
using Bogus;

namespace BikeRentalPoint.Generator.Kafka.Host.Generator;

/// <summary>
/// Provides methods for generating fake <see cref="CreateRentDto"/> instances for testing or demo purposes
/// </summary>
public static class RentGenerator
{
    /// <summary>
    /// Generates a collection of <see cref="CreateRentDto"/> records with random start times, durations, and IDs taken from the provided bike and renter identifier pools
    /// </summary>
    /// <param name="count">The number of rent contracts to generate</param>
    /// <param name="bikeIds">A list of available bike identifiers to randomly assign to generated rents</param>
    /// <param name="renterIds">A list of available renter identifiers to randomly assign to generated rents</param>
    /// <returns>A list containing the requested number of randomly generated rent contracts</returns>
    public static List<CreateRentDto> GenerateLinks(int count, IList<Guid> bikeIds, IList<Guid> renterIds) =>
        new Faker<CreateRentDto>()
            .CustomInstantiator(f => new CreateRentDto(
                StartTime: f.Date.Between(DateTime.UtcNow.AddDays(-30), DateTime.UtcNow.AddDays(30)),
                Duration: TimeSpan.FromMinutes(f.Random.Int(10, 240)),
                BikeId: f.PickRandom(bikeIds),
                RenterId: f.PickRandom(renterIds)
            ))
            .Generate(count);
}
