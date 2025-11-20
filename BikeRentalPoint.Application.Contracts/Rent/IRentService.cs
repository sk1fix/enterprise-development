namespace BikeRentalPoint.Application.Contracts.Rent;

public interface IRentService
{
    public Task<IEnumerable<RentDto>> GetAllRentsAsync();
    public Task<RentDto?> GetRentByIdAsync(Guid id);
    public Task<RentDto> CreateRentAsync(CreateRentDto createRentDto);
    public Task<RentDto?> UpdateRentAsync(Guid id, CreateRentDto updateRentDto);
    public Task<bool> DeleteRentAsync(Guid id);
}