namespace BikeRentalPoint.Application.Contracts.Bike;

/// <summary>
/// Represents data for creating or updating a bicycle
/// </summary>
/// <param name="SerialNumber">Manufacturer's serial number for identification</param>
/// <param name="Color">Color of the bicycle frame</param>
/// <param name="ModelId">Unique identifier of the bicycle model</param>
public sealed record CreateBikeDto(string SerialNumber, string? Color, Guid ModelId);
