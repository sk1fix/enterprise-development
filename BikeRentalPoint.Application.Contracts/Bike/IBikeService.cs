using BikeRentalPoint.Application.Contracts.Model;

namespace BikeRentalPoint.Application.Contracts.Bike;

/// <summary>
/// Interface for bicycle service operations
/// </summary>
public interface IBikeService : IApplicationService<BikeDto, CreateBikeDto, Guid>
{
    /// <summary>
    /// Get the model information for a specific bicycle
    /// </summary>
    /// <param name="id">Unique identifier of the bicycle</param>
    /// <returns>Model details of the bicycle</returns>
    public Task<ModelDto> GetBikeModel(Guid id);
}