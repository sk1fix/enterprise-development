using AutoMapper;
using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;


namespace BikeRentalPoint.Application.Services;

/// <summary>
/// Service for managing bicycle operations
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
public class BikeService(IRepository<Bike, Guid> repository, IMapper mapper) : IBikeService
{
    /// <summary>
    /// Create a new bicycle
    /// </summary>
    /// <param name="dto">Bicycle creation data</param>
    /// <returns>Created bicycle details</returns>
    public async Task<BikeDto> Create(CreateBikeDto dto)
    {
        var entity = mapper.Map<Bike>(dto);
        var result = await repository.Create(entity);
        return mapper.Map<BikeDto>(result);
    }

    /// <summary>
    /// Get a bicycle by unique identifier
    /// </summary>
    /// <param name="bikeId">Unique identifier of the bicycle</param>
    /// <returns>Bicycle details</returns>
    /// <exception cref="KeyNotFoundException">Thrown when bicycle is not found</exception>
    public async Task<BikeDto> Get(Guid bikeId)
    {
        var entity = await repository.Get(bikeId)
                     ?? throw new KeyNotFoundException($"Entity with ID {bikeId} not found");
        return mapper.Map<BikeDto>(entity);
    }

    /// <summary>
    /// Get all bicycles
    /// </summary>
    /// <returns>List of all bicycles</returns>
    public async Task<IList<BikeDto>> GetAll() => mapper.Map<List<BikeDto>>(await repository.GetAll());

    /// <summary>
    /// Update an existing bicycle
    /// </summary>
    /// <param name="bikeId">Unique identifier of the bicycle to update</param>
    /// <param name="dto">Updated bicycle data</param>
    /// <returns>Updated bicycle details</returns>
    /// <exception cref="KeyNotFoundException">Thrown when bicycle is not found</exception>
    public async Task<BikeDto> Update(Guid bikeId, CreateBikeDto dto)
    {
        var entity = await repository.Get(bikeId)
                     ?? throw new KeyNotFoundException($"Entity with ID {bikeId} not found");

        mapper.Map(dto, entity);
        var result = await repository.Update(entity);

        return mapper.Map<BikeDto>(result);
    }

    /// <summary>
    /// Delete a bicycle by unique identifier
    /// </summary>
    /// <param name="bikeId">Unique identifier of the bicycle to delete</param>
    /// <returns>True if deletion was successful, false otherwise</returns>
    public async Task<bool> Delete(Guid bikeId) => await repository.Delete(bikeId);

    /// <summary>
    /// Get the model information for a specific bicycle
    /// </summary>
    /// <param name="bikeId">Unique identifier of the bicycle</param>
    /// <returns>Model details of the bicycle</returns>
    /// <exception cref="KeyNotFoundException">Thrown when bicycle is not found</exception>
    public async Task<ModelDto> GetBikeModel(Guid bikeId)
    {
        var entity = await repository.Get(bikeId)
                     ?? throw new KeyNotFoundException($"Entity with ID {bikeId} not found");
        return mapper.Map<ModelDto>(entity.Model);
    }
}
