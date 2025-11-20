namespace BikeRentalPoint.Application.Contracts.Model;

/// <summary>
/// Interface for bicycle model service operations
/// </summary>
public interface IModelService : IApplicationService<ModelDto, CreateModelDto, Guid>
{
    /// <summary>
    /// Get all bicycle models
    /// </summary>
    /// <returns>Collection of all bicycle models</returns>
    public Task<IEnumerable<ModelDto>> GetAllModelsAsync();

    /// <summary>
    /// Get a bicycle model by unique identifier
    /// </summary>
    /// <param name="id">Unique identifier of the model</param>
    /// <returns>Model details or null if not found</returns>
    public Task<ModelDto?> GetModelByIdAsync(Guid id);

    /// <summary>
    /// Create a new bicycle model
    /// </summary>
    /// <param name="createModelDto">Model creation data</param>
    /// <returns>Created model details</returns>
    public Task<ModelDto> CreateModelAsync(CreateModelDto createModelDto);

    /// <summary>
    /// Update an existing bicycle model
    /// </summary>
    /// <param name="id">Unique identifier of the model to update</param>
    /// <param name="updateModelDto">Updated model data</param>
    /// <returns>Updated model details or null if not found</returns>
    public Task<ModelDto?> UpdateModelAsync(Guid id, CreateModelDto updateModelDto);

    /// <summary>
    /// Delete a bicycle model by unique identifier
    /// </summary>
    /// <param name="id">Unique identifier of the model to delete</param>
    /// <returns>True if deletion was successful, false if model not found</returns>
    public Task<bool> DeleteModelAsync(Guid id);
}