namespace BikeRentalPoint.Application.Contracts.Rent;

/// <summary>
/// Interface for rental service operations
/// </summary>
public interface IRentService : IApplicationService<RentDto, CreateRentDto, Guid>
{
    /// <summary>
    /// Get all rental records
    /// </summary>
    /// <returns>Collection of all rental records</returns>
    public Task<IEnumerable<RentDto>> GetAllRentsAsync();

    /// <summary>
    /// Get a rental record by unique identifier
    /// </summary>
    /// <param name="id">Unique identifier of the rental</param>
    /// <returns>Rental details or null if not found</returns>
    public Task<RentDto?> GetRentByIdAsync(Guid id);

    /// <summary>
    /// Create a new rental record
    /// </summary>
    /// <param name="createRentDto">Rental creation data</param>
    /// <returns>Created rental details</returns>
    public Task<RentDto> CreateRentAsync(CreateRentDto createRentDto);

    /// <summary>
    /// Update an existing rental record
    /// </summary>
    /// <param name="id">Unique identifier of the rental to update</param>
    /// <param name="updateRentDto">Updated rental data</param>
    /// <returns>Updated rental details or null if not found</returns>
    public Task<RentDto?> UpdateRentAsync(Guid id, CreateRentDto updateRentDto);

    /// <summary>
    /// Delete a rental record by unique identifier
    /// </summary>
    /// <param name="id">Unique identifier of the rental to delete</param>
    /// <returns>True if deletion was successful, false if rental not found</returns>
    public Task<bool> DeleteRentAsync(Guid id);
}