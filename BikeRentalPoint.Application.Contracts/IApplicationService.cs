namespace BikeRentalPoint.Application.Contracts;

/// <summary>
/// Application service interface for CRUD operations
/// </summary>
/// <typeparam name="TDto">DTO for Get requests</typeparam>
/// <typeparam name="TCreateUpdateDto">DTO for Post/Put requests</typeparam>
/// <typeparam name="TKey">The type of the DTO identifier</typeparam>
public interface IApplicationService<TDto, TCreateUpdateDto, TKey>
    where TDto : class
    where TCreateUpdateDto : class
    where TKey : struct
{
    /// <summary>
    /// Getting the entire list of DTOs
    /// </summary>
    /// <returns></returns>
    public Task<IList<TDto>> GetAll();

    /// <summary>
    /// Getting a DTO by ID
    /// </summary>
    /// <param name="id">DTO ID</param>
    /// <returns></returns>
    public Task<TDto> Get(TKey id);

    /// <summary>
    /// Creating a DTO
    /// </summary>
    /// <param name="entity">DTO</param>
    /// <returns></returns>
    public Task<TDto> Create(TCreateUpdateDto entity);

    /// <summary>
    /// DTO Update
    /// </summary>
    /// <param name="id">DTO ID</param>
    /// <param name="entity">DTO</param>
    /// <returns></returns>
    public Task<TDto> Update(TKey id, TCreateUpdateDto entity);

    /// <summary>
    /// Removing DTO
    /// </summary>
    /// <param name="id">DTO ID</param>
    /// <returns></returns>
    public Task<bool> Delete(TKey id);
}