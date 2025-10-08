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
    public required string SerialNumber { get; set; }

    /// <summary>
    /// Bike color
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Model associated with this bike
    /// </summary>
    public required Model Model { get; set; }
}
