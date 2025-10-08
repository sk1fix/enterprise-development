namespace BikeRentalPoint.Domain.Models;

/// <summary>
/// Bike rental information
/// </summary>
public class Rent
{
    /// <summary>
    /// Unique identifier of the rent
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Date and time when the rental period started
    /// </summary>
    public required DateTime StartTime { get; set; }

    /// <summary>
    /// Duration of the rental period in hours
    /// </summary>
    public required TimeSpan Duration { get; set; }

    /// <summary>
    /// Bike associated with this rent
    /// </summary>
    public required Bike Bike { get; set; }

    /// <summary>
    /// Renter associated with this rent
    /// </summary>
    public required Renter Renter { get; set; }
}