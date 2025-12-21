using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalPoint.Infrastructure.EfCore.Repository;

/// <summary>
/// Repository for managing <see cref="Rent"/> entities in the database
/// </summary>
public class RentEfCoreRepository(BikeRentalPointDbContext context) : IRepository<Rent, Guid>
{
    /// <summary>
    /// Adds a new rent to the database
    /// </summary>
    /// <param name="entity">The rent to create</param>
    /// <returns>The created <see cref="Rent"/> entity</returns>
    public async Task<Rent> Create(Rent entity)
    {
        var result = await context.Rents.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes a rent by ID
    /// </summary>
    /// <param name="entityId">The ID of the rent to delete</param>
    /// <returns>true if the deletion was successful; otherwise, false</returns>
    public async Task<bool> Delete(Guid entityId)
    {
        var entity = await context.Rents.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Rents.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves a rent by ID
    /// </summary>
    /// <param name="entityId">The ID of the rent to retrieve</param>
    /// <returns>The <see cref="Rent"/> entity, or null if not found</returns>
    public async Task<Rent?> Get(Guid entityId) =>
        await context.Rents.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all rents
    /// </summary>
    /// <returns>A list of <see cref="Rent"/> entities</returns>
    public async Task<IList<Rent>> GetAll() =>
        await context.Rents.ToListAsync();

    /// <summary>
    /// Updates an existing rent
    /// </summary>
    /// <param name="entity">The rent with updated data</param>
    /// <returns>The updated <see cref="Rent"/> entity</returns>
    public async Task<Rent> Update(Rent entity)
    {
        context.Rents.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}