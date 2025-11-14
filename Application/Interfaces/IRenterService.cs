using BikeRentalPoint.Application.DTO;

namespace BikeRentalPoint.Application.Interfaces;

public interface IRenterService
{
    public Task<IEnumerable<RenterDto>> GetAllRentersAsync();
    public Task<RenterDto?> GetRenterByIdAsync(Guid id);
    public Task<RenterDto> CreateRenterAsync(CreateRenterDto createRenterDto);
    public Task<RenterDto?> UpdateRenterAsync(Guid id, CreateRenterDto updateRenterDto);
    public Task<bool> DeleteRenterAsync(Guid id);
}