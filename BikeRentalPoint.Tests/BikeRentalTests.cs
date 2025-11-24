using BikeRentalPoint.Domain.Fixture;
using BikeRentalPoint.Shared.Enums;


namespace BikeRentalPoint.Tests;

/// <summary>
/// Unit tests
/// </summary>
public class BikeRentalTests(DataSeed fixture) : IClassFixture<DataSeed>
{
    private readonly DataSeed _fixture = fixture;

    /// <summary>
    /// Tests retrieval of all mountain bikes 
    /// </summary>
    [Fact]
    public void GetAllMountainsBikes()
    {
        var models = _fixture.Models
                    .Where(m => m.BikeType == BikeType.Mountain)
                    .ToList();

        Assert.NotEmpty(models);
        Assert.Equal(3, models.Count);
        Assert.All(models, m => Assert.Equal(BikeType.Mountain, m.BikeType));
    }

    /// <summary>
    /// Tests calculation of top 5 bike models by rental profit
    /// </summary>
    [Fact]
    public void GetTop5ModelsByProfit()
    {
        var query = _fixture.Rents
            .Join(_fixture.Bikes,
                rent => rent.BikeId,
                bike => bike.Id,
                (rent, bike) => new { rent, bike })
            .Join(_fixture.Models,
                rb => rb.bike.ModelId,
                model => model.Id,
                (rb, model) => new { rb.rent, model })
            .GroupBy(x => x.model)
            .Select(g => new
            {
                Model = g.Key,
                Profit = g.Sum(x => (decimal)x.rent.Duration.TotalHours * x.model.PricePerHour)
            })
            .OrderByDescending(x => x.Profit)
            .Take(5)
            .ToList();

        Assert.NotEmpty(query);
        Assert.Equal(5, query.Count);
        Assert.All(query, x => Assert.True(x.Profit > 0));
        Assert.Contains(query, m => m.Profit == 136.5m);
    }

    /// <summary>
    /// Tests calculation of top 5 bike models by total rental duration
    /// </summary>
    [Fact]
    public void GetTop5ModelsByDuration()
    {
        var query = _fixture.Rents
            .Join(_fixture.Bikes,
                rent => rent.BikeId,
                bike => bike.Id,
                (rent, bike) => new { rent, bike })
            .Join(_fixture.Models,
                rb => rb.bike.ModelId,
                model => model.Id,
                (rb, model) => new { rb.rent, model })
            .GroupBy(x => x.model)
            .Select(g => new
            {
                Model = g.Key,
                TotalDuration = g.Sum(x => x.rent.Duration.TotalHours)
            })
            .OrderByDescending(x => x.TotalDuration)
            .Take(5)
            .ToList();

        Assert.NotEmpty(query);
        Assert.Contains(query, m => m.TotalDuration == 10.5);
    }

    /// <summary>
    /// Tests calculation of minimum, maximum and average rental duration statistics
    /// </summary>
    [Fact]
    public void GetMinMaxAvgRentDuration()
    {
        var durations = _fixture.Rents.Select(r => r.Duration.TotalHours).ToList();
        var min = durations.Min();
        var max = durations.Max();
        var avg = durations.Average();

        Assert.Equal(1.5, min, 2);
        Assert.Equal(6, max, 2);
        Assert.Equal(3.17, Math.Round(avg, 2), 2);
    }

    /// <summary>
    /// Tests calculation of total rental duration grouped by bike type
    /// </summary>
    [Fact]
    public void GetTotalRentDurationByType()
    {
        var grouped = _fixture.Rents
            .Join(_fixture.Bikes,
                rent => rent.BikeId,
                bike => bike.Id,
                (rent, bike) => new { rent, bike })
            .Join(_fixture.Models,
                rb => rb.bike.ModelId,
                model => model.Id,
                (rb, model) => new { rb.rent, model })
            .GroupBy(x => x.model.BikeType)
            .Select(g => new { Type = g.Key, Total = g.Sum(x => x.rent.Duration.TotalHours) })
            .ToList();

        Assert.NotEmpty(grouped);
        Assert.All(grouped, g => Assert.True(g.Total > 0));
        Assert.Contains(grouped, m => m.Total == 10.5);
    }

    /// <summary>
    /// Tests identification of top renters by number of rentals
    /// </summary>
    [Fact]
    public void GetTopRentersByRentCount()
    {
        var result = _fixture.Rents
            .Join(_fixture.Renters,
                rent => rent.RenterId,
                renter => renter.Id,
                (rent, renter) => new { rent, renter })
            .GroupBy(x => x.renter)
            .Select(g => new { Renter = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(10)
            .ToList();

        Assert.Contains(result, x => x.Renter.Id == _fixture.Renters[0].Id);
    }
}