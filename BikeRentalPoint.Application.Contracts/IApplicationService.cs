namespace BikeRentalPoint.Application.Contracts;

public interface IApplicationService<TDto, TCreateUpdateDto, TKey>
    where TDto : class
    where TCreateUpdateDto : class
    where TKey : struct
{
    public Task<IEnumerable<TDto>> GetAll();
    public Task<TDto?> Get(TKey id);
    public Task<TDto> Create(TCreateUpdateDto entity);
    public Task<TDto> Update(TKey id, TCreateUpdateDto entity);
    public Task<bool> Delete(TKey id);
}