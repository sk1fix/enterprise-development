namespace BikeRentalPoint.Application.Contracts.Renter;

/// <summary>
/// Interface for renter service operations
/// </summary>
public interface IRenterService : IApplicationService<RenterDto, CreateRenterDto, Guid>
{
    /// <summary>
    /// Get all renters
    /// </summary>
    /// <returns>Collection of all renters</returns>
    public Task<IEnumerable<RenterDto>> GetAllRentersAsync();

    /// <summary>
    /// Get a renter by unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the renter</param>
    /// <returns>Renter details or null if not found</returns>
    public Task<RenterDto?> GetRenterByIdAsync(Guid id);

    /// <summary>
    /// Create a new renter
    /// </summary>
    /// <param name="createRenterDto">Renter creation data</param>
    /// <returns>Created renter details</returns>
    public Task<RenterDto> CreateRenterAsync(CreateRenterDto createRenterDto);

    /// <summary>
    /// Update an existing renter
    /// </summary>
    /// <param name="id">Unique identifier of the renter to update</param>
    /// <param name="updateRenterDto">Updated renter data</param>
    /// <returns>Updated renter details or null if not found</returns>
    public Task<RenterDto?> UpdateRenterAsync(Guid id, CreateRenterDto updateRenterDto);

    /// <summary>
    /// Delete a renter by unique identifier
    /// </summary>
    /// <param name="id">Unique identifier of the renter to delete</param>
    /// <returns>True if deletion was successful, false if renter not found</returns>
    public Task<bool> DeleteRenterAsync(Guid id);
}