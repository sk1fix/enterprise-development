using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Renter;

namespace BikeRentalPoint.Application.Contracts.Rent;

/// <summary>
/// Interface for rental service operations
/// </summary>
public interface IRentService : IApplicationService<RentDto, CreateRentDto, Guid>
{
    /// <summary>
    /// Get the bicycle information for a specific rental
    /// </summary>
    /// <param name="id">Unique identifier of the rental</param>
    /// <returns>Bicycle details associated with the rental</returns>
    public Task<BikeDto> GetRentBike(Guid id);

    /// <summary>
    /// Get the renter information for a specific rental
    /// </summary>
    /// <param name="id">Unique identifier of the rental</param>
    /// <returns>Renter details associated with the rental</returns>
    public Task<RenterDto> GetRentRenter(Guid id);
}