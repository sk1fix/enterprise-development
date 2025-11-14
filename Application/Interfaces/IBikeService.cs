using BikeRentalPoint.Application.DTO;
namespace BikeRentalPoint.Application.Interfaces;

public interface IBikeService
{
    public Task<IEnumerable<BikeDto>> GetAllBikesAsync();
    public Task<BikeDto?> GetBikeByIdAsync(Guid id);
    public Task<BikeDto> CreateBikeAsync(CreateBikeDto createBikeDto);
    public Task<BikeDto?> UpdateBikeAsync(Guid id, CreateBikeDto updateBikeDto);
    public Task<bool> DeleteBikeAsync(Guid id);
}