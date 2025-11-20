namespace BikeRentalPoint.Application.Contracts.Bike;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="SerialNumber"></param>
/// <param name="Color"></param>
/// <param name="ModelId"></param>
public sealed record BikeDto(Guid Id, string SerialNumber, string Color, Guid ModelId);