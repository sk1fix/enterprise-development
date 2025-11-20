namespace BikeRentalPoint.Application.Contracts.Bike;

/// <summary>
/// Represents a bicycle unit
/// </summary>
/// <param name="Id">Unique identifier of the bicycle</param>
/// <param name="SerialNumber">Manufacturer's serial number for identification</param>
/// <param name="Color">Color of the bicycle frame</param>
/// <param name="ModelId">Unique identifier of the bicycle model</param>
public sealed record BikeDto(Guid Id, string SerialNumber, string? Color, Guid ModelId);