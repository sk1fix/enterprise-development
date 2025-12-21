using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalPoint.Infrastructure.EfCore.Repository;

/// <summary>
/// Repository for managing <see cref="Bike"/> entities in the database
/// </summary>
public class BikeEfCoreRepository(BikeRentalPointDbContext context) : IRepository<Bike, Guid>
{
    /// <summary>
    /// Adds a new bike to the database
    /// </summary>
    /// <param name="entity">The bike to create</param>
    /// <returns>The created <see cref="Bike"/> entity</returns>
    public async Task<Bike> Create(Bike entity)
    {
        var result = await context.Bikes.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes a bike by ID
    /// </summary>
    /// <param name="entityId">The ID of the bike to delete</param>
    /// <returns>true if the deletion was successful; otherwise, false</returns>
    public async Task<bool> Delete(Guid entityId)
    {
        var entity = await context.Bikes.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Bikes.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves a bike by ID
    /// </summary>
    /// <param name="entityId">The ID of the bike to retrieve</param>
    /// <returns>The <see cref="Bike"/> entity, or null if not found</returns>
    public async Task<Bike?> Get(Guid entityId) =>
        await context.Bikes.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all bikes
    /// </summary>
    /// <returns>A list of <see cref="Bike"/> entities</returns>
    public async Task<IList<Bike>> GetAll() =>
        await context.Bikes.ToListAsync();

    /// <summary>
    /// Updates an existing bike
    /// </summary>
    /// <param name="entity">The bike with updated data</param>
    /// <returns>The updated <see cref="Bike"/> entity</returns>
    public async Task<Bike> Update(Bike entity)
    {
        context.Bikes.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}