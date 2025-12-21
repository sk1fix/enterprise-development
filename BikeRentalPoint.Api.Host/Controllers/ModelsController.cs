using BikeRentalPoint.Application.Contracts;
using BikeRentalPoint.Application.Contracts.Model;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalPoint.Api.Host.Controllers;

/// <summary>
/// Controller for managing bicycle models in the bike rental system
/// </summary>
/// <param name="service">Service handling model operations</param>
/// <param name="logger">Logger</param>
[Route("api/[controller]")]
[ApiController]
public class ModelsController(IApplicationService<ModelDto, CreateModelDto, Guid> service, ILogger<ModelsController> logger) : ControllerBase
{
    /// <summary>
    /// Retrieves all bicycle models
    /// </summary>
    /// <returns>A list of all bicycle models</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<ModelDto>> GetAll()
    {
        logger.LogInformation("Called GetAll in ModelsController");
        return await service.GetAll();
    }

    /// <summary>
    /// Retrieves a specific model by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the model</param>
    /// <returns>The model if found; otherwise, null</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ModelDto>> GetById(Guid id)
    {
        logger.LogInformation("Called GetById in ModelsController");
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
    /// Creates a new bicycle model
    /// </summary>
    /// <param name="modelDto">The DTO containing model information</param>
    /// <returns>The created model</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ModelDto>> Create([FromBody] CreateModelDto modelDto)
    {
        logger.LogInformation("Called Create in ModelsController");
        var result = await service.Create(modelDto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Updates an existing model
    /// </summary>
    /// <param name="id">The unique identifier of the model to update</param>
    /// <param name="modelDto">The DTO containing updated model information</param>
    /// <returns>The updated model if successful; otherwise, null</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ModelDto>> Update(Guid id, [FromBody] CreateModelDto modelDto)
    {
        logger.LogInformation("Called Update in ModelsController");
        try
        {
            var result = await service.Update(id, modelDto);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Deletes a model by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the model to delete</param>
    /// <returns>True if deletion was successful; otherwise, false</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(Guid id)
    {
        logger.LogInformation("Called Delete in ModelsController");
        var result = await service.Delete(id);
        if (result) return NoContent();
        return NotFound();
    }
}