namespace BikeRentalPoint.Application.Contracts.Analytics;

/// <summary>
/// DTO for rental duration statistics
/// </summary>
public record RentalStatisticsDto(double Min, double Max, double Avg);
