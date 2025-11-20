namespace BikeRentalPoint.Application.Contracts.Rent;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="StartTime"></param>
/// <param name="Duration"></param>
/// <param name="BikeId"></param>
/// <param name="RenterId"></param>
public sealed record RentDto(Guid Id, DateTime StartTime, TimeSpan Duration, Guid BikeId, Guid RenterId);
