using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalPoint.Infrastructure.EfCore.Repository;

/// <summary>
/// Repository for managing <see cref="Renter"/> entities in the database
/// </summary>
public class RenterEfCoreRepository(BikeRentalPointDbContext context) : IRepository<Renter, Guid>
{
    /// <summary>
    /// Adds a new renter to the database
    /// </summary>
    /// <param name="entity">The renter to create</param>
    /// <returns>The created <see cref="Renter"/> entity</returns>
    public async Task<Renter> Create(Renter entity)
    {
        var result = await context.Renters.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes a renter by ID
    /// </summary>
    /// <param name="entityId">The ID of the renter to delete</param>
    /// <returns>true if the deletion was successful; otherwise, false</returns>
    public async Task<bool> Delete(Guid entityId)
    {
        var entity = await context.Renters.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Renters.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves a renter by ID
    /// </summary>
    /// <param name="entityId">The ID of the renter to retrieve</param>
    /// <returns>The <see cref="Renter"/> entity, or null if not found</returns>
    public async Task<Renter?> Get(Guid entityId) =>
        await context.Renters.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all renters
    /// </summary>
    /// <returns>A list of <see cref="Renter"/> entities</returns>
    public async Task<IList<Renter>> GetAll() =>
        await context.Renters.ToListAsync();

    /// <summary>
    /// Updates an existing renter
    /// </summary>
    /// <param name="entity">The renter with updated data</param>
    /// <returns>The updated <see cref="Renter"/> entity</returns>
    public async Task<Renter> Update(Renter entity)
    {
        context.Renters.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}