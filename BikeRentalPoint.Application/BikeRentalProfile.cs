using AutoMapper;
using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Application.Contracts.Rent;
using BikeRentalPoint.Application.Contracts.Renter;
using BikeRentalPoint.Domain.Models;

namespace BikeRentalPoint.Application;

/// <summary>
/// AutoMapper profile for mapping between domain models and DTOs
/// </summary>
public class BikeRentalProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the BikeRentalProfile class
    /// </summary>
    public BikeRentalProfile()
    {
        CreateMap<Model, ModelDto>();
        CreateMap<CreateModelDto, Model>();

        CreateMap<Bike, BikeDto>();
        CreateMap<CreateBikeDto, Bike>();

        CreateMap<Renter, RenterDto>();
        CreateMap<CreateRenterDto, Renter>();

        CreateMap<Rent, RentDto>();
        CreateMap<CreateRentDto, Rent>();
    }
}