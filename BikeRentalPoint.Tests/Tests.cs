using BikeRentalPoint.Domain.Models;
using BikeRentalPoint.Domain.Fixture;

namespace BikeRentalPoint.Tests;

/// <summary>
/// Unit tests
/// </summary>
public class BikeRentalTests
{
    /// <summary>
    /// Test data initialization
    /// </summary>
    private readonly List<Model> _models;
    private readonly List<Renter> _renters;
    private readonly List<Bike> _bikes;
    private readonly List<Rent> _rents;

    /// <summary>
    /// Initializes test data before each test
    /// </summary>
    public BikeRentalTests()
    {
        _models = DataSeed.GetModels();
        _renters = DataSeed.GetRenters();
        _bikes = DataSeed.GetBikes(_models);
        _rents = DataSeed.GetRents(_bikes, _renters);
    }

    /// <summary>
    /// Tests retrieval of all mountain bikes 
    /// </summary>
    [Fact]
    public void GetAllSportsBikes()
    {
        var query = _models
            .Where(m => m.BikeType == BikeType.Mountain)
            .ToList();

        Assert.NotEmpty(query);
        Assert.Equal(3, query.Count());
    }

    /// <summary>
    /// Tests calculation of top 5 bike models by rental profit
    /// </summary>
    [Fact]
    public void GetTop5ModelsByProfit()
    {
        var query = _rents
            .GroupBy(r => r.Bike.Model)
            .Select(g => new
            {
                Model = g.Key,
                Profit = g.Sum(r => r.Duration * r.Bike.Model.PricePerHour)
            })
            .OrderByDescending(x => x.Profit)
            .Take(5)
            .ToList();

        Assert.NotEmpty(query);
        Assert.Equal(5, query.Count);
    }

    /// <summary>
    /// Tests calculation of top 5 bike models by total rental duration
    /// </summary>
    [Fact]
    public void GetTop5ModelsByDuration()
    {
        var query = _rents
            .GroupBy(r => r.Bike.Model)
            .Select(g => new
            {
                Model = g.Key,
                TotalDuration = g.Sum(r => r.Duration)
            })
            .OrderByDescending(x => x.TotalDuration)
            .Take(5)
            .ToList();

        Assert.NotEmpty(query);
        Assert.Equal(5, query.Count);
    }

    /// <summary>
    /// Tests calculation of minimum, maximum and average rental duration statistics
    /// </summary>
    [Fact]
    public void GetMinMaxAvgRentDuration()
    {
        var min = _rents.Min(r => r.Duration);
        var max = _rents.Max(r => r.Duration);
        var avg = _rents.Average(r => r.Duration);

        Assert.True(max >= min);
        Assert.True(avg >= min);
        Assert.True(avg <= max);
    }

    /// <summary>
    /// Tests calculation of total rental duration grouped by bike type
    /// </summary>
    [Fact]
    public void GetTotalRentDurationByType()
    {
        var query = _rents
            .GroupBy(r => r.Bike.Model.BikeType)
            .Select(g => new
            {
                Type = g.Key,
                TotalDuration = g.Sum(r => r.Duration)
            })
            .ToList();

        Assert.NotEmpty(query);
    }

    /// <summary>
    /// Tests identification of top renters by number of rentals
    /// </summary>
    [Fact]
    public void GetTopRentersByRentCount()
    {
        var query = _rents
            .GroupBy(r => r.Renter)
            .Select(g => new
            {
                Renter = g.Key,
                Count = g.Count()
            })
            .OrderByDescending(x => x.Count)
            .Take(3)
            .ToList();

        Assert.True(query.Count > 0);
        var topRenter = query.First().Renter;
        Assert.Equal(_renters[0].Id, topRenter.Id);
    }
}