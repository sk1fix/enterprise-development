using BikeRentalPoint.Shared.Enums;

namespace BikeRentalPoint.Application.Contracts.Model;

/// <summary>
/// Represents data for creating or updating a bicycle model
/// </summary>
/// <param name="WheelSize">Diameter of the wheels in inches</param>
/// <param name="MaxPassengerWeight">Maximum allowed passenger weight in kilograms</param>
/// <param name="BikeWeight">Weight of the bicycle in kilograms</param>
/// <param name="BrakeType">Type of braking system</param>
/// <param name="ModelYear">Year when the model was released</param>
/// <param name="PricePerHour">Rental cost per hour in local currency</param>
/// <param name="BikeType">Category classification of the bicycle</param>
public sealed record CreateModelDto(double? WheelSize, double? MaxPassengerWeight, double? BikeWeight, BrakeType BrakeType, int? ModelYear, decimal PricePerHour, BikeType BikeType);