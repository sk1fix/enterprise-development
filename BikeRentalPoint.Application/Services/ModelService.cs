using AutoMapper;
using BikeRentalPoint.Application.Contracts;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;


namespace BikeRentalPoint.Application.Services;

/// <summary>
/// Service for managing bicycle model operations
/// </summary>
/// <param name="repository">Repository for data access</param>
/// <param name="mapper">AutoMapper instance for object mapping</param>
public class ModelService(IRepository<Model, Guid> repository, IMapper mapper) : IApplicationService<ModelDto, CreateModelDto, Guid>
{
    /// <summary>
    /// Create a new bicycle model
    /// </summary>
    /// <param name="dto">Model creation data</param>
    /// <returns>Created model details</returns>
    public async Task<ModelDto> Create(CreateModelDto dto)
    {
        var entity = mapper.Map<Model>(dto);
        var result = await repository.Create(entity);
        return mapper.Map<ModelDto>(result);
    }

    /// <summary>
    /// Get a bicycle model by unique identifier
    /// </summary>
    /// <param name="modelId">Unique identifier of the model</param>
    /// <returns>Model details</returns>
    /// <exception cref="KeyNotFoundException">Thrown when model is not found</exception>
    public async Task<ModelDto> Get(Guid modelId)
    {
        var entity = await repository.Get(modelId)
                     ?? throw new KeyNotFoundException($"Entity with ID {modelId} not found");
        return mapper.Map<ModelDto>(entity);
    }

    /// <summary>
    /// Get all bicycle models
    /// </summary>
    /// <returns>List of all bicycle models</returns>
    public async Task<IList<ModelDto>> GetAll() => mapper.Map<List<ModelDto>>(await repository.GetAll());

    /// <summary>
    /// Update an existing bicycle model
    /// </summary>
    /// <param name="modelId">Unique identifier of the model to update</param>
    /// <param name="dto">Updated model data</param>
    /// <returns>Updated model details</returns>
    /// <exception cref="KeyNotFoundException">Thrown when model is not found</exception>
    public async Task<ModelDto> Update(Guid modelId, CreateModelDto dto)
    {
        var entity = await repository.Get(modelId)
                     ?? throw new KeyNotFoundException($"Entity with ID {modelId} not found");

        mapper.Map(dto, entity);
        var result = await repository.Update(entity);

        return mapper.Map<ModelDto>(result);
    }

    /// <summary>
    /// Delete a bicycle model by unique identifier
    /// </summary>
    /// <param name="modelId">Unique identifier of the model to delete</param>
    /// <returns>True if deletion was successful, false otherwise</returns>
    public async Task<bool> Delete(Guid modelId) => await repository.Delete(modelId);
}
