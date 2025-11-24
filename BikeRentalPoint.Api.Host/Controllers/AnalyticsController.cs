using BikeRentalPoint.Application.Contracts;
using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Application.Contracts.Renter;
using BikeRentalPoint.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalPoint.Api.Host.Controllers;

/// <summary>
/// Controller for analytical queries in the bike rental system
/// </summary>
/// <param name="service">Service handling analytical operations</param>
/// <param name="logger">Logger</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service, ILogger<AnalyticsController> logger) : ControllerBase
{
    /// <summary>
    /// Retrieves all mountain bikes
    /// </summary>
    /// <returns>A list of mountain bikes</returns>
    [HttpGet("mountain-bikes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<BikeDto>> GetMountainBikes()
    {
        logger.LogInformation("Called GetMountainBikes in AnalyticsController");
        return await service.GetMountainBikesAsync();
    }

    /// <summary>
    /// Retrieves top 5 bike models by rental profit
    /// </summary>
    /// <returns>A list of top 5 models by profit</returns>
    [HttpGet("top-models/profit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<ModelDto>> GetTopModelsByProfit()
    {
        logger.LogInformation("Called GetTopModelsByProfit in AnalyticsController");
        return await service.GetTopModelsByProfitAsync();
    }

    /// <summary>
    /// Retrieves top 5 bike models by total rental duration
    /// </summary>
    /// <returns>A list of top 5 models by duration</returns>
    [HttpGet("top-models/duration")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<ModelDto>> GetTopModelsByDuration()
    {
        logger.LogInformation("Called GetTopModelsByDuration in AnalyticsController");
        return await service.GetTopModelsByDurationAsync();
    }

    /// <summary>
    /// Retrieves rental duration statistics
    /// </summary>
    /// <returns>Minimum, maximum and average rental duration</returns>
    [HttpGet("rental-statistics")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetRentalStatistics()
    {
        logger.LogInformation("Called GetRentalStatistics in AnalyticsController");
        var result = await service.GetRentalStatisticsAsync();
        return Ok(new { result.min, result.max, result.avg });
    }

    /// <summary>
    /// Retrieves best renters by number of rentals
    /// </summary>
    /// <returns>A list of best renters</returns>
    [HttpGet("top-renters")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<RenterDto>> GetTopRenters()
    {
        logger.LogInformation("Called GetTopRenters in AnalyticsController");
        return await service.GetTopRentersAsync();
    }

    /// <summary>
    /// Retrieves total rental duration grouped by bike type
    /// </summary>
    /// <returns>Total duration by bike type</returns>
    [HttpGet("duration-by-type")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetTotalRentDurationByType()
    {
        logger.LogInformation("Called GetTotalRentDurationByType in AnalyticsController");
        var result = await service.GetTotalRentDurationByTypeAsync();

        var formattedResult = result.Select(x => new
        {
            type = x.Type,
            totalHours = x.TotalHours
        }).ToList();
         
        return Ok(new { durations = formattedResult });
    }
}