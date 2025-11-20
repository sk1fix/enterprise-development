namespace BikeRentalPoint.Application.Contracts.Model;

public interface IModelService
{
    public Task<IEnumerable<ModelDto>> GetAllModelsAsync();
    public Task<ModelDto?> GetModelByIdAsync(Guid id);
    public Task<ModelDto> CreateModelAsync(CreateModelDto createModelDto);
    public Task<ModelDto?> UpdateModelAsync(Guid id, CreateModelDto updateModelDto);
    public Task<bool> DeleteModelAsync(Guid id);
}