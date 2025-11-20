namespace BikeRentalPoint.Application.Contracts.Renter;

/// <summary>
/// 
/// </summary>
/// <param name="LastName"></param>
/// <param name="Name"></param>
/// <param name="MiddleName"></param>
/// <param name="PhoneNumber"></param>
public sealed record CreateRenterDto(string LastName, string Name, string? MiddleName, string PhoneNumber);
