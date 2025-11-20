namespace BikeRentalPoint.Application.Contracts.Renter;

/// <summary>
/// Interface for renter service
/// </summary>
public interface IRenterService
{
    /// <summary>
    /// Getting all renters
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<RenterDto>> GetAllRentersAsync();
    /// <summary>
    /// Getting a renter by a unique ID
    /// </summary>
    /// <param name="id">The unique identifier of the renter</param>
    /// <returns></returns>
    public Task<RenterDto?> GetRenterByIdAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createRenterDto"></param>
    /// <returns></returns>
    public Task<RenterDto> CreateRenterAsync(CreateRenterDto createRenterDto);
    public Task<RenterDto?> UpdateRenterAsync(Guid id, CreateRenterDto updateRenterDto);
    public Task<bool> DeleteRenterAsync(Guid id);
}