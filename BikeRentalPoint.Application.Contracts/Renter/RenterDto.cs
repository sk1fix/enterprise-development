namespace BikeRentalPoint.Application.Contracts.Renter;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="LastName"></param>
/// <param name="Name"></param>
/// <param name="MiddleName"></param>
/// <param name="PhoneNumber"></param>
public sealed record RenterDto(Guid Id, string LastName, string Name, string MiddleName, string PhoneNumber);
