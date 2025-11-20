using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Application.Contracts.Renter;


namespace BikeRentalPoint.Application.Contracts;

public interface IAnalyticsService
{
    public Task<IEnumerable<BikeDto>> GetMountainBikesAsync();
    public Task<IEnumerable<ModelDto>> GetTopModelsByProfitAsync();
    public Task<IEnumerable<ModelDto>> GetTopModelsByDurationAsync();
    public Task<(double min, double max, double avg)> GetRentalStatisticsAsync();
    public Task<IEnumerable<RenterDto>> GetTopRentersAsync();
}