using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Application.Contracts.Renter;


namespace BikeRentalPoint.Application.Contracts;
/// <summary>
/// Interface for performing analytical queries
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Get all mountain bikes
    /// </summary>
    /// <returns>List of mountain bikes</returns>
    public Task<IEnumerable<BikeDto>> GetMountainBikesAsync();

    /// <summary>
    /// Get a calculation of top 5 bike models by rental profit
    /// </summary>
    /// <returns>List of 5 by profit models</returns>
    public Task<IEnumerable<ModelDto>> GetTopModelsByProfitAsync();

    /// <summary>
    /// Get a calculation of the top 5 bike models by total rental duration
    /// </summary>
    /// <returns>List of 5 by duration models</returns>
    public Task<IEnumerable<ModelDto>> GetTopModelsByDurationAsync();

    /// <summary>
    /// Get statistics on the minimum, maximum, and average rental duration calculated
    /// </summary>
    /// <returns>statistics on the minimum, maximum, and average rental duration calculated</returns>
    public Task<(double min, double max, double avg)> GetRentalStatisticsAsync();

    /// <summary>
    /// Get the best renters by the number of rentals
    /// </summary>
    /// <returns>List of best renters</returns>
    public Task<IEnumerable<RenterDto>> GetTopRentersAsync();
}