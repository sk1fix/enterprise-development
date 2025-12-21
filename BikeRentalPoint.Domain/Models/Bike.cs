using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRentalPoint.Domain.Models;

/// <summary>
/// Information about bike
/// </summary>
[Table("bike")]
public class Bike
{
    /// <summary>
    /// Unique identifier of the bike
    /// </summary>
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Bike serial number
    /// </summary>
    [Column("serial_number")]
    public required string SerialNumber { get; set; }

    /// <summary>
    /// Bike color
    /// </summary>
    [Column("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Foreign key referencing the bicycle model
    /// </summary>
    [Column("model_id")]
    public required Guid ModelId { get; set; }

    /// <summary>
    /// Bicycle model associated with this bike
    /// </summary>
    public virtual Model? Model { get; set; }
}
