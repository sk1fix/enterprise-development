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
    /// Model associated with this bike
    /// </summary>
    public required Model Model { get; set; }
}
