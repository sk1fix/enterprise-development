namespace BikeRentalPoint.Application.Contracts.Analytics;

/// <summary>
/// DTO for rental duration statistics
/// </summary>
/// <param name="Min">Minimum rental duration</param>
/// <param name="Max">Maximum rental duration</param>
/// <param name="Avg">Average rental duration</param>
public sealed record RentalStatisticsDto(double Min, double Max, double Avg);
