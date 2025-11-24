using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRentalPoint.Domain.Models;

/// <summary>
/// Information about the bike renter
/// </summary>
[Table("renter")]
public class Renter
{
    /// <summary>
    /// Unique identifier for the renter
    /// </summary>
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Last name of the renter
    /// </summary>
    [Column("last_name")]
    public required string LastName { get; set; }

    /// <summary>
    /// First name of the renter
    /// </summary>
    [Column("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Patronymic of the renter
    /// </summary>
    [Column("middle_name")]
    public string? MiddleName { get; set; }

    /// <summary>
    /// Contact phone number 
    /// </summary>
    [Column("phone_number")]
    public required string PhoneNumber { get; set; }
}