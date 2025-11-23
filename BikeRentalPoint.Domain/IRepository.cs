namespace BikeRentalPoint.Domain;

/// <summary>
/// Generic repository interface for data access operations
/// </summary>
/// <typeparam name="TEntity">The type of entity</typeparam>
/// <typeparam name="TKey">The type of entity key</typeparam>
public interface IRepository<TEntity, TKey>
    where TEntity : class
    where TKey : struct
{
    /// <summary>
    /// Create a new entity
    /// </summary>
    /// <param name="entity">Entity to create</param>
    /// <returns>Created entity</returns>
    public Task<TEntity> Create(TEntity entity);

    /// <summary>
    /// Get an entity by unique identifier
    /// </summary>
    /// <param name="entityId">Unique identifier of the entity</param>
    /// <returns>Entity or null if not found</returns>
    public Task<TEntity?> Get(TKey entityId);

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns>List of all entities</returns>
    public Task<IList<TEntity>> GetAll();

    /// <summary>
    /// Update an existing entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <returns>Updated entity</returns>
    public Task<TEntity> Update(TEntity entity);

    /// <summary>
    /// Delete an entity by unique identifier
    /// </summary>
    /// <param name="entityId">Unique identifier of the entity to delete</param>
    /// <returns>True if deletion was successful, false if entity not found</returns>
    public Task<bool> Delete(TKey entityId);
}