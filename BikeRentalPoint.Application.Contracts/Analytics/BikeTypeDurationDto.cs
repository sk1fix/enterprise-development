using BikeRentalPoint.Shared.Enums;

namespace BikeRentalPoint.Application.Contracts.Analytics;

/// <summary>
/// DTO for bike type rental duration statistics
/// </summary>
public record BikeTypeDurationDto(BikeType Type, double TotalHours);
