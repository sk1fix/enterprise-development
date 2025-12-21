using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalPoint.Infrastructure.EfCore.Repository;

/// <summary>
/// Repository for managing <see cref="Model"/> entities in the database
/// </summary>
public class ModelEfCoreRepository(BikeRentalPointDbContext context) : IRepository<Model, Guid>
{
    /// <summary>
    /// Adds a new model to the database
    /// </summary>
    /// <param name="entity">The model to create</param>
    /// <returns>The created <see cref="Model"/> entity</returns>
    public async Task<Model> Create(Model entity)
    {
        var result = await context.Models.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes a model by ID
    /// </summary>
    /// <param name="entityId">The ID of the model to delete</param>
    /// <returns>true if the deletion was successful; otherwise, false</returns>
    public async Task<bool> Delete(Guid entityId)
    {
        var entity = await context.Models.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Models.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves a model by ID
    /// </summary>
    /// <param name="entityId">The ID of the model to retrieve</param>
    /// <returns>The <see cref="Model"/> entity, or null if not found</returns>
    public async Task<Model?> Get(Guid entityId) =>
        await context.Models.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all models
    /// </summary>
    /// <returns>A list of <see cref="Model"/> entities</returns>
    public async Task<IList<Model>> GetAll() =>
        await context.Models.ToListAsync();

    /// <summary>
    /// Updates an existing model
    /// </summary>
    /// <param name="entity">The model with updated data</param>
    /// <returns>The updated <see cref="Model"/> entity</returns>
    public async Task<Model> Update(Model entity)
    {
        context.Models.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}