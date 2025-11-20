using BikeRentalPoint.Domain.Models;

namespace BikeRentalPoint.Application.Contracts.Model;

/// <summary>
/// 
/// </summary>
/// <param name="WheelSize"></param>
/// <param name="MaxPassengerWeight"></param>
/// <param name="BikeWeight"></param>
/// <param name="BrakeType"></param>
/// <param name="ModelYear"></param>
/// <param name="PricePerHour"></param>
/// <param name="BikeType"></param>
public sealed record CreateModelDto(double WheelSize, double MaxPassengerWeight, double BikeWeight, BrakeType BrakeType, int ModelYear, decimal PricePerHour, BikeType BikeType);
