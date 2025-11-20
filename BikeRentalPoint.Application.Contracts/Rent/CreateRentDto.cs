namespace BikeRentalPoint.Application.Contracts.Rent;

/// <summary>
/// 
/// </summary>
/// <param name="StartTime"></param>
/// <param name="Duration"></param>
/// <param name="BikeId"></param>
/// <param name="RenterId"></param>
public sealed record CreateRentDto(DateTime StartTime, TimeSpan Duration, Guid BikeId, Guid RenterId);
