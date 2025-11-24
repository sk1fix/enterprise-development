using BikeRentalPoint.Application.Contracts;
using BikeRentalPoint.Application.Contracts.Renter;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalPoint.Api.Host.Controllers;

/// <summary>
/// Controller for managing renters in the bike rental system
/// </summary>
/// <param name="service">Service handling renter operations</param>
/// <param name="logger">Logger</param>
[Route("api/[controller]")]
[ApiController]
public class RentersController(IApplicationService<RenterDto, CreateRenterDto, Guid> service, ILogger<RentersController> logger) : ControllerBase
{
    /// <summary>
    /// Retrieves all renters
    /// </summary>
    /// <returns>A list of all renters</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<RenterDto>> GetAll()
    {
        logger.LogInformation("Called GetAll in RentersController");
        return await service.GetAll();
    }

    /// <summary>
    /// Retrieves a specific renter by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the renter</param>
    /// <returns>The renter if found; otherwise, null</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RenterDto>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in RentersController");
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
    /// Creates a new renter
    /// </summary>
    /// <param name="renterDto">The DTO containing renter information</param>
    /// <returns>The created renter</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RenterDto>> Create([FromBody] CreateRenterDto renterDto)
    {
        logger.LogInformation("Called Create in RentersController");
        var result = await service.Create(renterDto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Updates an existing renter
    /// </summary>
    /// <param name="id">The unique identifier of the renter to update</param>
    /// <param name="renterDto">The DTO containing updated renter information</param>
    /// <returns>The updated renter if successful; otherwise, null</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RenterDto>> Update(Guid id, [FromBody] CreateRenterDto renterDto)
    {
        logger.LogInformation("Called Update in RentersController");
        try
        {
            var result = await service.Update(id, renterDto);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Deletes a renter by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the renter to delete</param>
    /// <returns>True if deletion was successful; otherwise, false</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in RentersController");
        var result = await service.Delete(id);
        if (result) return NoContent();
        return NotFound();
    }
}