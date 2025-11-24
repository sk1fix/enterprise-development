using AutoMapper;
using BikeRentalPoint.Application.Contracts;
using BikeRentalPoint.Application.Contracts.Renter;
using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;


namespace BikeRentalPoint.Application.Services;

/// <summary>
/// Service for managing renter operations
/// </summary>
/// <param name="repository">Repository for data access</param>
/// <param name="mapper">AutoMapper instance for object mapping</param>
public class RenterService(IRepository<Renter, Guid> repository, IMapper mapper) : IApplicationService<RenterDto, CreateRenterDto, Guid>
{
    /// <summary>
    /// Create a new renter
    /// </summary>
    /// <param name="dto">Renter creation data</param>
    /// <returns>Created renter details</returns>
    public async Task<RenterDto> Create(CreateRenterDto dto)
    {
        var entity = mapper.Map<Renter>(dto);
        var result = await repository.Create(entity);
        return mapper.Map<RenterDto>(result);
    }

    /// <summary>
    /// Get a renter by unique identifier
    /// </summary>
    /// <param name="renterId">Unique identifier of the renter</param>
    /// <returns>Renter details</returns>
    /// <exception cref="KeyNotFoundException">Thrown when renter is not found</exception>
    public async Task<RenterDto> Get(Guid renterId)
    {
        var entity = await repository.Get(renterId)
                     ?? throw new KeyNotFoundException($"Entity with ID {renterId} not found");
        return mapper.Map<RenterDto>(entity);
    }

    /// <summary>
    /// Get all renters
    /// </summary>
    /// <returns>List of all renters</returns>
    public async Task<IList<RenterDto>> GetAll() => mapper.Map<List<RenterDto>>(await repository.GetAll());

    /// <summary>
    /// Update an existing renter
    /// </summary>
    /// <param name="renterId">Unique identifier of the renter to update</param>
    /// <param name="dto">Updated renter data</param>
    /// <returns>Updated renter details</returns>
    /// <exception cref="KeyNotFoundException">Thrown when renter is not found</exception>
    public async Task<RenterDto> Update(Guid renterId, CreateRenterDto dto)
    {
        var entity = await repository.Get(renterId)
                     ?? throw new KeyNotFoundException($"Entity with ID {renterId} not found");

        mapper.Map(dto, entity);
        var result = await repository.Update(entity);

        return mapper.Map<RenterDto>(result);
    }

    /// <summary>
    /// Delete a renter by unique identifier
    /// </summary>
    /// <param name="renterId">Unique identifier of the renter to delete</param>
    /// <returns>True if deletion was successful, false otherwise</returns>
    public async Task<bool> Delete(Guid renterId) => await repository.Delete(renterId);
}
