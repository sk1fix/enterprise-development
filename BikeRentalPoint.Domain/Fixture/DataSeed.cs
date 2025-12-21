using BikeRentalPoint.Domain.Models;
using BikeRentalPoint.Shared.Enums;

namespace BikeRentalPoint.Domain.Fixture;

/// <summary>
/// Fixture data for unit-tests
/// </summary>
public class DataSeed
{
    /// <summary>
    /// List of bicycle models
    /// </summary>
    public List<Model> Models { get; } = [];

    /// <summary>
    /// List of bicycles
    /// </summary>
    public List<Bike> Bikes { get; } = [];

    /// <summary>
    /// List of renters
    /// </summary>
    public List<Renter> Renters { get; } = [];

    /// <summary>
    /// List of rents
    /// </summary>
    public List<Rent> Rents { get; } = [];

    /// <summary>
    /// Initializes test data
    /// </summary>
    public DataSeed()
    {
        Models.AddRange([
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111110"), WheelSize = 28, MaxPassengerWeight = 100, BikeWeight = 9, BrakeType = BrakeType.Disc, ModelYear = 2022, PricePerHour = 12, BikeType = BikeType.Road },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), WheelSize = 26, MaxPassengerWeight = 110, BikeWeight = 11, BrakeType = BrakeType.Rim, ModelYear = 2021, PricePerHour = 10, BikeType = BikeType.Mountain },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), WheelSize = 29, MaxPassengerWeight = 120, BikeWeight = 13, BrakeType = BrakeType.Disc, ModelYear = 2023, PricePerHour = 15, BikeType = BikeType.Mountain },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), WheelSize = 27.5, MaxPassengerWeight = 90, BikeWeight = 10, BrakeType = BrakeType.Rim, ModelYear = 2020, PricePerHour = 9, BikeType = BikeType.Hybrid },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111114"), WheelSize = 28, MaxPassengerWeight = 100, BikeWeight = 12, BrakeType = BrakeType.Drum, ModelYear = 2024, PricePerHour = 14, BikeType = BikeType.Road },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111115"), WheelSize = 24, MaxPassengerWeight = 80, BikeWeight = 8, BrakeType = BrakeType.Tape, ModelYear = 2019, PricePerHour = 8, BikeType = BikeType.Folding },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111116"), WheelSize = 26, MaxPassengerWeight = 100, BikeWeight = 14, BrakeType = BrakeType.Disc, ModelYear = 2024, PricePerHour = 16, BikeType = BikeType.Electric },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111117"), WheelSize = 29, MaxPassengerWeight = 130, BikeWeight = 15, BrakeType = BrakeType.RodActuated, ModelYear = 2023, PricePerHour = 13, BikeType = BikeType.Mountain },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111118"), WheelSize = 27, MaxPassengerWeight = 95, BikeWeight = 11, BrakeType = BrakeType.Rim, ModelYear = 2021, PricePerHour = 11, BikeType = BikeType.Hybrid },
            new Model { Id = Guid.Parse("11111111-1111-1111-1111-111111111119"), WheelSize = 28, MaxPassengerWeight = 120, BikeWeight = 12, BrakeType = BrakeType.Disc, ModelYear = 2025, PricePerHour = 17, BikeType = BikeType.Road }
        ]);

        Renters.AddRange([
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-11111111111a"), LastName = "Иванов", Name = "Иван", MiddleName = "Иванович", PhoneNumber = "111-111" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-11111111111b"), LastName = "Петров", Name = "Петр", MiddleName = "Петрович", PhoneNumber = "222-222" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-11111111111c"), LastName = "Сидоров", Name = "Сидор", MiddleName = "Сидорович", PhoneNumber = "333-333" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-11111111111d"), LastName = "Алексеев", Name = "Алексей", MiddleName = "Николаевич", PhoneNumber = "444-444" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-11111111111e"), LastName = "Васильев", Name = "Василий", MiddleName = "Павлович", PhoneNumber = "555-555" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-11111111111f"), LastName = "Кузнецов", Name = "Сергей", MiddleName = "Игоревич", PhoneNumber = "666-666" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-111111111120"), LastName = "Никитин", Name = "Никита", MiddleName = "Андреевич", PhoneNumber = "777-777" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-111111111121"), LastName = "Федоров", Name = "Федор", MiddleName = "Владимирович", PhoneNumber = "888-888" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-111111111122"), LastName = "Смирнов", Name = "Семен", MiddleName = "Валерьевич", PhoneNumber = "999-999" },
            new Renter { Id = Guid.Parse("11111111-1111-1111-1111-111111111123"), LastName = "Попов", Name = "Дмитрий", MiddleName = "Алексеевич", PhoneNumber = "000-000" }
        ]);

        Bikes.AddRange([
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-111111111124"), SerialNumber = "101", Color = "Red", ModelId = Models[0].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-111111111125"), SerialNumber = "102", Color = "Blue", ModelId = Models[1].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-111111111126"), SerialNumber = "103", Color = "Black", ModelId = Models[2].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-111111111127"), SerialNumber = "104", Color = "Green", ModelId = Models[3].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-111111111128"), SerialNumber = "105", Color = "White", ModelId = Models[4].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-111111111129"), SerialNumber = "106", Color = "Yellow", ModelId = Models[5].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-11111111112a"), SerialNumber = "107", Color = "Silver", ModelId = Models[6].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-11111111112b"), SerialNumber = "108", Color = "Gray", ModelId = Models[7].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-11111111112c"), SerialNumber = "109", Color = "Orange", ModelId = Models[8].Id },
            new Bike { Id = Guid.Parse("11111111-1111-1111-1111-11111111112d"), SerialNumber = "110", Color = "Purple", ModelId = Models[9].Id }
        ]);

        Rents.AddRange([
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-11111111112e"), StartTime = DateTime.Now.AddHours(-50), Duration = TimeSpan.FromHours(2), BikeId = Bikes[0].Id, RenterId = Renters[0].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-11111111112f"), StartTime = DateTime.Now.AddHours(-40), Duration = TimeSpan.FromHours(3), BikeId = Bikes[1].Id, RenterId = Renters[1].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111130"), StartTime = DateTime.Now.AddHours(-30), Duration = TimeSpan.FromHours(4), BikeId = Bikes[2].Id, RenterId = Renters[2].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111131"), StartTime = DateTime.Now.AddHours(-20), Duration = TimeSpan.FromHours(1.5), BikeId = Bikes[3].Id, RenterId = Renters[3].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111132"), StartTime = DateTime.Now.AddHours(-10), Duration = TimeSpan.FromHours(2.5), BikeId = Bikes[4].Id, RenterId = Renters[4].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111133"), StartTime = DateTime.Now.AddHours(-5), Duration = TimeSpan.FromHours(5), BikeId = Bikes[5].Id, RenterId = Renters[5].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111134"), StartTime = DateTime.Now.AddHours(-3), Duration = TimeSpan.FromHours(6), BikeId = Bikes[6].Id, RenterId = Renters[6].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111135"), StartTime = DateTime.Now.AddHours(-2), Duration = TimeSpan.FromHours(2.5), BikeId = Bikes[7].Id, RenterId = Renters[7].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111136"), StartTime = DateTime.Now.AddHours(-1), Duration = TimeSpan.FromHours(3.5), BikeId = Bikes[8].Id, RenterId = Renters[8].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111137"), StartTime = DateTime.Now.AddHours(-25), Duration = TimeSpan.FromHours(3), BikeId = Bikes[2].Id, RenterId = Renters[0].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111138"), StartTime = DateTime.Now.AddHours(-15), Duration = TimeSpan.FromHours(2), BikeId = Bikes[6].Id, RenterId = Renters[1].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-111111111139"), StartTime = DateTime.Now.AddHours(-12), Duration = TimeSpan.FromHours(5), BikeId = Bikes[7].Id, RenterId = Renters[3].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-11111111113a"), StartTime = DateTime.Now.AddHours(-8), Duration = TimeSpan.FromHours(4), BikeId = Bikes[4].Id, RenterId = Renters[5].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-11111111113b"), StartTime = DateTime.Now.AddHours(-6), Duration = TimeSpan.FromHours(2.5), BikeId = Bikes[5].Id, RenterId = Renters[7].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-11111111113c"), StartTime = DateTime.Now.AddHours(-4), Duration = TimeSpan.FromHours(3.5), BikeId = Bikes[3].Id, RenterId = Renters[8].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-11111111113d"), StartTime = DateTime.Now.AddHours(-1.5), Duration = TimeSpan.FromHours(2), BikeId = Bikes[9].Id, RenterId = Renters[0].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-11111111113e"), StartTime = DateTime.Now.AddHours(-0.5), Duration = TimeSpan.FromHours(3), BikeId = Bikes[7].Id, RenterId = Renters[2].Id },
            new Rent { Id = Guid.Parse("11111111-1111-1111-1111-11111111113f"), StartTime = DateTime.Now.AddHours(-0.2), Duration = TimeSpan.FromHours(2), BikeId = Bikes[5].Id, RenterId = Renters[4].Id }
        ]);
    }
}
