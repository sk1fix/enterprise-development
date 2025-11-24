using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRentalPoint.Domain.Models;

/// <summary>
/// Bike rental information
/// </summary>
[Table("rent")]
public class Rent
{
    /// <summary>
    /// Unique identifier of the rent
    /// </summary>
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Date and time when the rental period started
    /// </summary>
    [Column("start_time")]
    public required DateTime StartTime { get; set; }

    /// <summary>
    /// Duration of the rental period in hours
    /// </summary>
    [Column("duration")]
    public required TimeSpan Duration { get; set; }

    /// <summary>
    /// Foreign key referencing the rented bicycle
    /// </summary>
    [Column("bike_id")]
    public required Guid BikeId { get; set; }

    /// <summary>
    /// Bicycle associated with this rental
    /// </summary>
    public virtual Bike? Bike { get; set; }

    /// <summary>
    /// Foreign key referencing the renter
    /// </summary>
    [Column("renter_id")]
    public required Guid RenterId { get; set; }

    /// <summary>
    /// Renter associated with this rental
    /// </summary>
    public virtual Renter? Renter { get; set; }
}