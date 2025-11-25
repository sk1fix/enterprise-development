namespace BikeRentalPoint.Application.Contracts.Renter;

/// <summary>
/// DTO for POST/PUT requests to renters
/// </summary>
/// <param name="LastName">Renter`s last name</param>
/// <param name="Name">Renter`s name</param>
/// <param name="MiddleName">Renter`s middle name</param>
/// <param name="PhoneNumber">Renter`s phone number</param>
public sealed record CreateRenterDto(string LastName, string Name, string? MiddleName, string PhoneNumber);
