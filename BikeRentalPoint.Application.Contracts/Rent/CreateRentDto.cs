namespace BikeRentalPoint.Application.Contracts.Rent;

/// <summary>
/// Represents data for creating or updating a bicycle rental
/// </summary>
/// <param name="StartTime">Date and time when rental period starts</param>
/// <param name="Duration">Duration of the rental period</param>
/// <param name="BikeId">Unique identifier of the bicycle to rent</param>
/// <param name="RenterId">Unique identifier of the renter</param>
public sealed record CreateRentDto(DateTime StartTime, TimeSpan Duration, Guid BikeId, Guid RenterId);
