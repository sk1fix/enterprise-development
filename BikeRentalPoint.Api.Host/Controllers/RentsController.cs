using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Rent;
using BikeRentalPoint.Application.Contracts.Renter;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalPoint.Api.Host.Controllers;

/// <summary>
/// Controller for managing rentals in the bike rental system
/// </summary>
/// <param name="service">Service handling rental operations</param>
/// <param name="logger">Logger</param>
[Route("api/[controller]")]
[ApiController]
public class RentsController(IRentService service, ILogger<RentsController> logger) : ControllerBase
{
    /// <summary>
    /// Retrieves all rentals
    /// </summary>
    /// <returns>A list of all rentals</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<RentDto>> GetAll()
    {
        logger.LogInformation("Called GetAll in RentsController");
        return await service.GetAll();
    }

    /// <summary>
    /// Retrieves a specific rental by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the rental</param>
    /// <returns>The rental if found; otherwise, null</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RentDto>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in RentsController");
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
    /// Creates a new rental
    /// </summary>
    /// <param name="rentDto">The DTO containing rental information</param>
    /// <returns>The created rental</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RentDto>> Create([FromBody] CreateRentDto rentDto)
    {
        logger.LogInformation("Called Create in RentsController");
        var result = await service.Create(rentDto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Updates an existing rental
    /// </summary>
    /// <param name="id">The unique identifier of the rental to update</param>
    /// <param name="rentDto">The DTO containing updated rental information</param>
    /// <returns>The updated rental if successful; otherwise, null</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RentDto>> Update(Guid id, [FromBody] CreateRentDto rentDto)
    {
        logger.LogInformation("Called Update in RentsController");
        try
        {
            var result = await service.Update(id, rentDto);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Deletes a rental by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the rental to delete</param>
    /// <returns>True if deletion was successful; otherwise, false</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in RentsController");
        var result = await service.Delete(id);
        if (result) return NoContent();
        return NotFound();
    }

    /// <summary>
    /// Gets the bicycle information for a specific rental
    /// </summary>
    /// <param name="id">The unique identifier of the rental</param>
    /// <returns>The bicycle details associated with the rental</returns>
    [HttpGet("{id:guid}/bike")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BikeDto>> GetRentBike(Guid id)
    {
        logger.LogInformation("Called GetRentBike in RentsController");
        try
        {
            var result = await service.GetRentBike(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Gets the renter information for a specific rental
    /// </summary>
    /// <param name="id">The unique identifier of the rental</param>
    /// <returns>The renter details associated with the rental</returns>
    [HttpGet("{id:guid}/renter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RenterDto>> GetRentRenter(Guid id)
    {
        logger.LogInformation("Called GetRentRenter in RentsController");
        try
        {
            var result = await service.GetRentRenter(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}