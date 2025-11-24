using AutoMapper;
using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Rent;
using BikeRentalPoint.Application.Contracts.Renter;
using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;


namespace BikeRentalPoint.Application.Services;

/// <summary>
/// Service for managing rental operations
/// </summary>
/// <param name="repository">Repository for data access</param>
/// <param name="mapper">AutoMapper instance for object mapping</param>
public class RentService(IRepository<Rent, Guid> repository, IMapper mapper) : IRentService
{
    /// <summary>
    /// Create a new rental record
    /// </summary>
    /// <param name="dto">Rental creation data</param>
    /// <returns>Created rental details</returns>
    public async Task<RentDto> Create(CreateRentDto dto)
    {
        var entity = mapper.Map<Rent>(dto);
        var result = await repository.Create(entity);
        return mapper.Map<RentDto>(result);
    }

    /// <summary>
    /// Get a rental record by unique identifier
    /// </summary>
    /// <param name="rentId">Unique identifier of the rental</param>
    /// <returns>Rental details</returns>
    /// <exception cref="KeyNotFoundException">Thrown when rental is not found</exception>
    public async Task<RentDto> Get(Guid rentId)
    {
        var entity = await repository.Get(rentId)
                     ?? throw new KeyNotFoundException($"Entity with ID {rentId} not found");
        return mapper.Map<RentDto>(entity);
    }

    /// <summary>
    /// Get all rental records
    /// </summary>
    /// <returns>List of all rental records</returns>
    public async Task<IList<RentDto>> GetAll() => mapper.Map<List<RentDto>>(await repository.GetAll());

    /// <summary>
    /// Update an existing rental record
    /// </summary>
    /// <param name="rentId">Unique identifier of the rental to update</param>
    /// <param name="dto">Updated rental data</param>
    /// <returns>Updated rental details</returns>
    /// <exception cref="KeyNotFoundException">Thrown when rental is not found</exception>
    public async Task<RentDto> Update(Guid rentId, CreateRentDto dto)
    {
        var entity = await repository.Get(rentId)
                     ?? throw new KeyNotFoundException($"Entity with ID {rentId} not found");

        mapper.Map(dto, entity);
        var result = await repository.Update(entity);

        return mapper.Map<RentDto>(result);
    }

    /// <summary>
    /// Delete a rental record by unique identifier
    /// </summary>
    /// <param name="rentId">Unique identifier of the rental to delete</param>
    /// <returns>True if deletion was successful, false otherwise</returns>
    public async Task<bool> Delete(Guid rentId) => await repository.Delete(rentId);

    /// <summary>
    /// Get the bicycle information for a specific rental
    /// </summary>
    /// <param name="rentId">Unique identifier of the rental</param>
    /// <returns>Bicycle details associated with the rental</returns>
    /// <exception cref="KeyNotFoundException">Thrown when rental is not found</exception>
    public async Task<BikeDto> GetRentBike(Guid rentId)
    {
        var entity = await repository.Get(rentId)
                     ?? throw new KeyNotFoundException($"Entity with ID {rentId} not found");
        return mapper.Map<BikeDto>(entity.Bike);
    }

    /// <summary>
    /// Get the renter information for a specific rental
    /// </summary>
    /// <param name="rentId">Unique identifier of the rental</param>
    /// <returns>Renter details associated with the rental</returns>
    /// <exception cref="KeyNotFoundException">Thrown when rental is not found</exception>
    public async Task<RenterDto> GetRentRenter(Guid rentId)
    {
        var entity = await repository.Get(rentId)
                     ?? throw new KeyNotFoundException($"Entity with ID {rentId} not found");
        return mapper.Map<RenterDto>(entity.Renter);
    }
}
