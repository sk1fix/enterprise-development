namespace BikeRentalPoint.Application.Contracts.Bike;

/// <summary>
/// Interface for bicycle service operations
/// </summary>
public interface IBikeService : IApplicationService<BikeDto, CreateBikeDto, Guid>
{
    /// <summary>
    /// Get all bicycles
    /// </summary>
    /// <returns>Collection of all bicycles</returns>
    public Task<IEnumerable<BikeDto>> GetAllBikesAsync();

    /// <summary>
    /// Get a bicycle by unique identifier
    /// </summary>
    /// <param name="id">Unique identifier of the bicycle</param>
    /// <returns>Bicycle details or null if not found</returns>
    public Task<BikeDto?> GetBikeByIdAsync(Guid id);

    /// <summary>
    /// Create a new bicycle
    /// </summary>
    /// <param name="createBikeDto">Bicycle creation data</param>
    /// <returns>Created bicycle details</returns>
    public Task<BikeDto> CreateBikeAsync(CreateBikeDto createBikeDto);

    /// <summary>
    /// Update an existing bicycle
    /// </summary>
    /// <param name="id">Unique identifier of the bicycle to update</param>
    /// <param name="updateBikeDto">Updated bicycle data</param>
    /// <returns>Updated bicycle details or null if not found</returns>
    public Task<BikeDto?> UpdateBikeAsync(Guid id, CreateBikeDto updateBikeDto);

    /// <summary>
    /// Delete a bicycle by unique identifier
    /// </summary>
    /// <param name="id">Unique identifier of the bicycle to delete</param>
    /// <returns>True if deletion was successful, false if bicycle not found</returns>
    public Task<bool> DeleteBikeAsync(Guid id);
}