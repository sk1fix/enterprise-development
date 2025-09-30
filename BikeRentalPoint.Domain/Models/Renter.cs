namespace BikeRentalPoint.Domain.Models;

/// <summary>
/// Information about the bike renter
/// </summary>
public class Renter
{
    /// <summary>
    /// Unique identifier for the renter
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Last name of the renter
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// First name of the renter
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Patronymic of the renter
    /// </summary>
    public required string MiddleName { get; set; }

    /// <summary>
    /// Contact phone number 
    /// </summary>
    public required string PhoneNumber { get; set; }
}