using BikeRentalPoint.Application.DTO;

namespace BikeRentalPoint.Application.Interfaces;

public interface IAnalyticsService
{
    public Task<IEnumerable<BikeDto>> GetSportBikesAsync();
    public Task<IEnumerable<ModelRevenueDto>> GetTopModelsByRevenueAsync(int topCount = 5);
    public Task<IEnumerable<ModelDurationDto>> GetTopModelsByDurationAsync(int topCount = 5);
    public Task<RentalStatisticsDto> GetRentalStatisticsAsync();
    public Task<IEnumerable<BikeTypeDurationDto>> GetTotalRentalTimeByBikeTypeAsync();
    public Task<IEnumerable<TopRenterDto>> GetTopRentersAsync();
}