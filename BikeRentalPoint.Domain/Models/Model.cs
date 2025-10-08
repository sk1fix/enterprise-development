namespace BikeRentalPoint.Domain.Models;

/// <summary>
/// Information about the bike model
/// </summary>
public class Model
{
    /// <summary>
    /// Unique identifier of the model
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Bike wheel size
    /// </summary>
    public double? WheelSize { get; set; }

    /// <summary>
    /// Maximum permissible passenger weight
    /// </summary>
    public double? MaxPassengerWeight { get; set; }

    /// <summary>
    /// Bike weight
    /// </summary>
    public double? BikeWeight { get; set; }

    /// <summary>
    /// Type of bicycle brakes
    /// </summary>
    public required BrakeType BrakeType { get; set; } 

    /// <summary>
    /// Model year
    /// </summary>
    public int? ModelYear { get; set; }

    /// <summary>
    /// Price of an hour of rent
    /// </summary>
    public required decimal PricePerHour { get; set; }

    /// <summary>
    /// Type of bicycle model
    /// </summary>
    public required BikeType BikeType { get; set; }
}
