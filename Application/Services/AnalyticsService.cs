using AutoMapper;
using BikeRentalPoint.Application.Contracts;
using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Application.Contracts.Renter;
using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;

public class AnalyticsService(
    IRepository<Rent, Guid> rentRepository,
    IRepository<Bike, Guid> bikeRepository,
    IMapper mapper) : IAnalyticsService
{
    /// <summary>
    /// Get all mountain bikes
    /// </summary>
    /// <returns>List of mountain bikes</returns>
    public async Task<IList<BikeDto>> GetMountainBikesAsync()
    {
        var bikes = await bikeRepository.GetAll();
        var mountainBikes = bikes
            .Where(b => b.Model.BikeType == BikeType.Mountain)
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

        var modelProfits = rents
            .GroupBy(r => r.Bike.Model)
            .Select(g => new
            {
                Model = g.Key,
                Profit = g.Sum(r => (decimal)r.Duration.TotalHours * r.Bike.Model.PricePerHour)
            })
            .OrderByDescending(x => x.Profit)
            .Take(5)
            .Select(x => mapper.Map<ModelDto>(x.Model))
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

        var modelDurations = rents
            .GroupBy(r => r.Bike.Model)
            .Select(g => new
            {
                Model = g.Key,
                TotalDuration = g.Sum(r => r.Duration.TotalHours)
            })
            .OrderByDescending(x => x.TotalDuration)
            .Take(5)
            .Select(x => mapper.Map<ModelDto>(x.Model))
            .ToList();

        return modelDurations;
    }

    /// <summary>
    /// Get statistics on the minimum, maximum, and average rental duration calculated
    /// </summary>
    /// <returns>statistics on the minimum, maximum, and average rental duration calculated</returns>
    public async Task<(double min, double max, double avg)> GetRentalStatisticsAsync()
    {
        var rents = await rentRepository.GetAll();

        var durations = rents.Select(r => r.Duration.TotalHours).ToList();

        if (!durations.Any())
            return (0, 0, 0);

        var min = durations.Min();
        var max = durations.Max();
        var avg = durations.Average();

        return (min, max, avg);
    }

    /// <summary>
    /// Get the best renters by the number of rentals
    /// </summary>
    /// <returns>List of best renters</returns>
    public async Task<IList<RenterDto>> GetTopRentersAsync()
    {
        var rents = await rentRepository.GetAll();

        var topRenters = rents
            .GroupBy(r => r.Renter)
            .Select(g => new
            {
                Renter = g.Key,
                Count = g.Count()
            })
            .OrderByDescending(x => x.Count)
            .Take(10)
            .Select(x => mapper.Map<RenterDto>(x.Renter))
            .ToList();

        return topRenters;
    }

    /// <summary>
    /// Get total rental duration grouped by bike type
    /// </summary>
    /// <returns>Total duration by bike type</returns>
    public async Task<IList<(BikeType Type, double TotalHours)>> GetTotalRentDurationByTypeAsync()
    {
        var rents = await rentRepository.GetAll();

        var grouped = rents
            .GroupBy(r => r.Bike.Model.BikeType)
            .Select(g => (Type: g.Key, TotalHours: g.Sum(r => r.Duration.TotalHours)))
            .ToList();

        return grouped;
    }
}