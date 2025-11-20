namespace BikeRentalPoint.Application.Contracts.Bike;

/// <summary>
/// 
/// </summary>
/// <param name="SerialNumber"></param>
/// <param name="Color"></param>
/// <param name="ModelId"></param>
public sealed record CreateBikeDto(string SerialNumber, string Color, Guid ModelId);
