using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Application.Contracts.Renter;

namespace BikeRentalPoint.Application.Contracts.Analytics;
/// <summary>
/// Interface for performing analytical queries
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Get all mountain bikes
    /// </summary>
    /// <returns>List of mountain bikes</returns>
    public Task<IList<BikeDto>> GetMountainBikesAsync();

    /// <summary>
    /// Get a calculation of top 5 bike models by rental profit
    /// </summary>
    /// <returns>List of 5 by profit models</returns>
    public Task<IList<ModelDto>> GetTopModelsByProfitAsync();

    /// <summary>
    /// Get a calculation of the top 5 bike models by total rental duration
    /// </summary>
    /// <returns>List of 5 by duration models</returns>
    public Task<IList<ModelDto>> GetTopModelsByDurationAsync();

    /// <summary>
    /// Get statistics on the minimum, maximum, and average rental duration calculated
    /// </summary>
    /// <returns>statistics on the minimum, maximum, and average rental duration calculated</returns>
    public Task<RentalStatisticsDto> GetRentalStatisticsAsync();

    /// <summary>
    /// Get the best renters by the number of rentals
    /// </summary>
    /// <returns>List of best renters</returns>
    public Task<IList<RenterDto>> GetTopRentersAsync();

    /// <summary>
    /// Get total rental duration grouped by bike type
    /// </summary>
    /// <returns>Total duration by bike type</returns>
    public Task<IList<BikeTypeDurationDto>> GetTotalRentDurationByTypeAsync();
}