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
    public required float WheelSize { get; set; }

    /// <summary>
    /// Maximum permissible passenger weight
    /// </summary>
    public required int MaxPassengerWeight { get; set; }

    /// <summary>
    /// Bike weight
    /// </summary>
    public required float BikeWeight { get; set; }

    /// <summary>
    /// Type of bicycle brakes
    /// </summary>
    public required string BrakeType { get; set; } 

    /// <summary>
    /// Model year
    /// </summary>
    public required int ModelYear { get; set; }

    /// <summary>
    /// Price of an hour of rent
    /// </summary>
    public required decimal PricePerHour { get; set; }

    /// <summary>
    /// Type of bicycle model
    /// </summary>
    public required BikeType BikeType { get; set; }
}
