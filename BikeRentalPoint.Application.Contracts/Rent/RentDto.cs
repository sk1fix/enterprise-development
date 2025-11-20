namespace BikeRentalPoint.Application.Contracts.Rent;

/// <summary>
/// DTO for GET requests to rents
/// </summary>
/// <param name="Id">Unique identifier of the rental</param>
/// <param name="StartTime">Date and time when rental period started</param>
/// <param name="Duration">Duration of the rental period</param>
/// <param name="BikeId">Unique identifier of the rented bicycle</param>
/// <param name="RenterId">Unique identifier of the renter</param>
public sealed record RentDto(Guid Id, DateTime StartTime, TimeSpan Duration, Guid BikeId, Guid RenterId);