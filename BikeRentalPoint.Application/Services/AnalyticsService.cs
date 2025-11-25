using AutoMapper;
using BikeRentalPoint.Application.Contracts.Analytics;
using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Application.Contracts.Renter;
using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;
using BikeRentalPoint.Shared.Enums;

/// <summary>
/// Interface for performing analytical queries
/// </summary>
public class AnalyticsService(
    IRepository<Rent, Guid> rentRepository,
    IRepository<Bike, Guid> bikeRepository,
    IRepository<Model, Guid> modelRepository,
    IRepository<Renter, Guid> renterRepository,
    IMapper mapper) : IAnalyticsService
{
    /// <summary>
    /// Get all mountain bikes
    /// </summary>
    /// <returns>List of mountain bikes</returns>
    public async Task<IList<BikeDto>> GetMountainBikesAsync()
    {
        var bikes = await bikeRepository.GetAll();
        var models = await modelRepository.GetAll();

        var mountainBikes = bikes
            .Where(b => models.First(m => m.Id == b.ModelId).BikeType == BikeType.Mountain)
            .ToList();

        return mapper.Map<List<BikeDto>>(mountainBikes);
    }

    /// <summary>
    /// Get a calculation of top 5 bike models by rental profit
    /// </summary>
    /// <returns>List of 5 by profit models</returns>
    public async Task<IList<ModelDto>> GetTopModelsByProfitAsync()
    {
        var rents = await rentRepository.GetAll();
        var bikes = await bikeRepository.GetAll();
        var models = await modelRepository.GetAll();

        var modelProfits = rents
            .GroupBy(r => bikes.First(b => b.Id == r.BikeId).ModelId)
            .Select(g => new
            {
                ModelId = g.Key,
                Profit = g.Sum(r =>
                {
                    var bike = bikes.First(b => b.Id == r.BikeId);
                    var model = models.First(m => m.Id == bike.ModelId);
                    return (decimal)r.Duration.TotalHours * model.PricePerHour;
                })
            })
            .OrderByDescending(x => x.Profit)
            .Take(5)
            .Select(x => mapper.Map<ModelDto>(models.First(m => m.Id == x.ModelId)))
            .ToList();

        return modelProfits;
    }

    /// <summary>
    /// Get a calculation of the top 5 bike models by total rental duration
    /// </summary>
    /// <returns>List of 5 by duration models</returns>
    public async Task<IList<ModelDto>> GetTopModelsByDurationAsync()
    {
        var rents = await rentRepository.GetAll();
        var bikes = await bikeRepository.GetAll();
        var models = await modelRepository.GetAll();

        var modelDurations = rents
            .GroupBy(r => bikes.First(b => b.Id == r.BikeId).ModelId)
            .Select(g => new
            {
                ModelId = g.Key,
                TotalDuration = g.Sum(r => r.Duration.TotalHours)
            })
            .OrderByDescending(x => x.TotalDuration)
            .Take(5)
            .Select(x => mapper.Map<ModelDto>(models.First(m => m.Id == x.ModelId)))
            .ToList();

        return modelDurations;
    }

    /// <summary>
    /// Get statistics on the minimum, maximum, and average rental duration calculated
    /// </summary>
    /// <returns>statistics on the minimum, maximum, and average rental duration calculated</returns>
    public async Task<RentalStatisticsDto> GetRentalStatisticsAsync()
    {
        var rents = await rentRepository.GetAll();

        var durations = rents.Select(r => r.Duration.TotalHours).ToList();

        if (!durations.Any())
            return new RentalStatisticsDto(0, 0, 0);

        var min = durations.Min();
        var max = durations.Max();
        var avg = durations.Average();

        return new RentalStatisticsDto(min, max, avg);
    }

    /// <summary>
    /// Get the best renters by the number of rentals
    /// </summary>
    /// <returns>List of best renters</returns>
    public async Task<IList<RenterDto>> GetTopRentersAsync()
    {
        var rents = await rentRepository.GetAll();
        var renters = await renterRepository.GetAll();

        var topRenters = rents
            .GroupBy(r => r.RenterId)
            .Select(g => new
            {
                RenterId = g.Key,
                Count = g.Count()
            })
            .OrderByDescending(x => x.Count)
            .Take(10)
            .Select(x => mapper.Map<RenterDto>(renters.First(r => r.Id == x.RenterId)))
            .ToList();

        return topRenters;
    }

    /// <summary>
    /// Get total rental duration grouped by bike type
    /// </summary>
    /// <returns>Total duration by bike type</returns>
    public async Task<IList<BikeTypeDurationDto>> GetTotalRentDurationByTypeAsync()
    {
        var rents = await rentRepository.GetAll();
        var bikes = await bikeRepository.GetAll();
        var models = await modelRepository.GetAll();

        var grouped = rents
            .Join(bikes, rent => rent.BikeId, bike => bike.Id, (rent, bike) => new { rent, bike })
            .Join(models, rb => rb.bike.ModelId, model => model.Id, (rb, model) => new { rb.rent, model })
            .GroupBy(x => x.model.BikeType)
            .Select(g => new BikeTypeDurationDto(
                Type: g.Key,
                TotalHours: g.Sum(x => x.rent.Duration.TotalHours)
            ))
            .ToList();

        return grouped;
    }
}