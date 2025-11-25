using BikeRentalPoint.Shared.Enums;

namespace BikeRentalPoint.Application.Contracts.Analytics;

/// <summary>
/// DTO for bike type rental duration statistics
/// </summary>
/// <param name="Type">Type of bicycle</param>
/// <param name="TotalHours">Total rental hours for this bike type</param>
public sealed record BikeTypeDurationDto(BikeType Type, double TotalHours);
