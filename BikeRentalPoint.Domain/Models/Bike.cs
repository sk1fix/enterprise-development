namespace BikeRentalPoint.Domain.Models;

/// <summary>
/// Information about bike
/// </summary>
public class Bike
{
    /// <summary>
    /// Unique identifier of the bike
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Bike serial number
    /// </summary>
    public required int SerialNumber { get; set; }

    /// <summary>
    /// Bike color
    /// </summary>
    public required string Color { get; set; }

    /// <summary>
    /// Model associated with this bike
    /// </summary>
    public required Model Model { get; set; }
}
