using BikeRentalPoint.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRentalPoint.Domain.Models;

/// <summary>
/// Information about the bike model
/// </summary>
[Table("model")]
public class Model
{
    /// <summary>
    /// Unique identifier of the model
    /// </summary>
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Bike wheel size
    /// </summary>
    [Column("wheel_size")]
    public double? WheelSize { get; set; }

    /// <summary>
    /// Maximum permissible passenger weight
    /// </summary>
    [Column("max_passenger_weight")]
    public double? MaxPassengerWeight { get; set; }

    /// <summary>
    /// Bike weight
    /// </summary>
    [Column("bike_weight")]
    public double? BikeWeight { get; set; }

    /// <summary>
    /// Type of bicycle brakes
    /// </summary>
    [Column("brake_type")]
    public required BrakeType BrakeType { get; set; }

    /// <summary>
    /// Model year
    /// </summary>
    [Column("model_year")]
    public int? ModelYear { get; set; }

    /// <summary>
    /// Price of an hour of rent
    /// </summary>
    [Column("price_per_hour")]
    public required decimal PricePerHour { get; set; }

    /// <summary>
    /// Type of bicycle model
    /// </summary>
    [Column("bike_type")]
    public required BikeType BikeType { get; set; }
}
