namespace BikeRentalPoint.Application.Contracts.Renter;

/// <summary>
/// DTO for GET requests to renters
/// </summary>
/// <param name="Id">The renter`s ID</param>
/// <param name="LastName"> Renter`s last name</param>
/// <param name="Name">Renter`s name</param>
/// <param name="MiddleName">Renter`s middle name</param>
/// <param name="PhoneNumber">Renter`s phone number</param>
public sealed record RenterDto(Guid Id, string LastName, string Name, string? MiddleName, string PhoneNumber);
