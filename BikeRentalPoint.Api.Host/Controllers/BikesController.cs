using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalPoint.Api.Host.Controllers;

/// <summary>
/// Controller for managing bicycles in the bike rental system
/// </summary>
/// <param name="service">Service handling bicycle operations</param>
/// <param name="logger">Logger</param>
[Route("api/[controller]")]
[ApiController]
public class BikesController(IBikeService service, ILogger<BikesController> logger) : ControllerBase
{
    /// <summary>
    /// Retrieves all bicycles
    /// </summary>
    /// <returns>A list of all bicycles</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<BikeDto>> GetAll()
    {
        logger.LogInformation("Called GetAll in BikesController");
        return await service.GetAll();
    }

    /// <summary>
    /// Retrieves a specific bicycle by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the bicycle</param>
    /// <returns>The bicycle if found; otherwise, null</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BikeDto>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in BikesController");
        try
        {
            var result = await service.Get(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Creates a new bicycle
    /// </summary>
    /// <param name="bikeDto">The DTO containing bicycle information</param>
    /// <returns>The created bicycle</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BikeDto>> Create([FromBody] CreateBikeDto bikeDto)
    {
        logger.LogInformation("Called Create in BikesController");
        var result = await service.Create(bikeDto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Updates an existing bicycle
    /// </summary>
    /// <param name="id">The unique identifier of the bicycle to update</param>
    /// <param name="bikeDto">The DTO containing updated bicycle information</param>
    /// <returns>The updated bicycle if successful; otherwise, null</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BikeDto>> Update(Guid id, [FromBody] CreateBikeDto bikeDto)
    {
        logger.LogInformation("Called Update in BikesController");
        try
        {
            var result = await service.Update(id, bikeDto);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Deletes a bicycle by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the bicycle to delete</param>
    /// <returns>True if deletion was successful; otherwise, false</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in BikesController");
        var result = await service.Delete(id);
        if (result) return NoContent();
        return NotFound();
    }

    /// <summary>
    /// Gets the model information for a specific bicycle
    /// </summary>
    /// <param name="id">The unique identifier of the bicycle</param>
    /// <returns>The model details of the bicycle</returns>
    [HttpGet("{id:guid}/model")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ModelDto>> GetBikeModel(Guid id)
    {
        logger.LogInformation("Called GetBikeModel in BikesController");
        try
        {
            var result = await service.GetBikeModel(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}