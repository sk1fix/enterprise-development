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
            new Model { WheelSize = 28, MaxPassengerWeight = 100, BikeWeight = 9, BrakeType = BrakeType.Disc, ModelYear = 2022, PricePerHour = 12, BikeType = BikeType.Road },
            new Model { WheelSize = 26, MaxPassengerWeight = 110, BikeWeight = 11, BrakeType = BrakeType.Rim, ModelYear = 2021, PricePerHour = 10, BikeType = BikeType.Mountain },
            new Model { WheelSize = 29, MaxPassengerWeight = 120, BikeWeight = 13, BrakeType = BrakeType.Disc, ModelYear = 2023, PricePerHour = 15, BikeType = BikeType.Mountain },
            new Model { WheelSize = 27.5, MaxPassengerWeight = 90, BikeWeight = 10, BrakeType = BrakeType.Rim, ModelYear = 2020, PricePerHour = 9, BikeType = BikeType.Hybrid },
            new Model { WheelSize = 28, MaxPassengerWeight = 100, BikeWeight = 12, BrakeType = BrakeType.Drum, ModelYear = 2024, PricePerHour = 14, BikeType = BikeType.Road },
            new Model { WheelSize = 24, MaxPassengerWeight = 80, BikeWeight = 8, BrakeType = BrakeType.Tape, ModelYear = 2019, PricePerHour = 8, BikeType = BikeType.Folding },
            new Model { WheelSize = 26, MaxPassengerWeight = 100, BikeWeight = 14, BrakeType = BrakeType.Disc, ModelYear = 2024, PricePerHour = 16, BikeType = BikeType.Electric },
            new Model { WheelSize = 29, MaxPassengerWeight = 130, BikeWeight = 15, BrakeType = BrakeType.RodActuated, ModelYear = 2023, PricePerHour = 13, BikeType = BikeType.Mountain },
            new Model { WheelSize = 27, MaxPassengerWeight = 95, BikeWeight = 11, BrakeType = BrakeType.Rim, ModelYear = 2021, PricePerHour = 11, BikeType = BikeType.Hybrid },
            new Model { WheelSize = 28, MaxPassengerWeight = 120, BikeWeight = 12, BrakeType = BrakeType.Disc, ModelYear = 2025, PricePerHour = 17, BikeType = BikeType.Road }
        ]);

        Renters.AddRange([
            new Renter { LastName = "Иванов", Name = "Иван", MiddleName = "Иванович", PhoneNumber = "111-111" },
            new Renter { LastName = "Петров", Name = "Петр", MiddleName = "Петрович", PhoneNumber = "222-222" },
            new Renter { LastName = "Сидоров", Name = "Сидор", MiddleName = "Сидорович", PhoneNumber = "333-333" },
            new Renter { LastName = "Алексеев", Name = "Алексей", MiddleName = "Николаевич", PhoneNumber = "444-444" },
            new Renter { LastName = "Васильев", Name = "Василий", MiddleName = "Павлович", PhoneNumber = "555-555" },
            new Renter { LastName = "Кузнецов", Name = "Сергей", MiddleName = "Игоревич", PhoneNumber = "666-666" },
            new Renter { LastName = "Никитин", Name = "Никита", MiddleName = "Андреевич", PhoneNumber = "777-777" },
            new Renter { LastName = "Федоров", Name = "Федор", MiddleName = "Владимирович", PhoneNumber = "888-888" },
            new Renter { LastName = "Смирнов", Name = "Семен", MiddleName = "Валерьевич", PhoneNumber = "999-999" },
            new Renter { LastName = "Попов", Name = "Дмитрий", MiddleName = "Алексеевич", PhoneNumber = "000-000" }
        ]);

        Bikes.AddRange([
            new Bike { SerialNumber = "101", Color = "Red", ModelId = Models[0].Id },
            new Bike { SerialNumber = "102", Color = "Blue", ModelId = Models[1].Id },
            new Bike { SerialNumber = "103", Color = "Black", ModelId = Models[2].Id },
            new Bike { SerialNumber = "104", Color = "Green", ModelId = Models[3].Id },
            new Bike { SerialNumber = "105", Color = "White", ModelId = Models[4].Id },
            new Bike { SerialNumber = "106", Color = "Yellow", ModelId = Models[5].Id },
            new Bike { SerialNumber = "107", Color = "Silver", ModelId = Models[6].Id },
            new Bike { SerialNumber = "108", Color = "Gray", ModelId = Models[7].Id },
            new Bike { SerialNumber = "109", Color = "Orange", ModelId = Models[8].Id },
            new Bike { SerialNumber = "110", Color = "Purple", ModelId = Models[9].Id }
        ]);

        Rents.AddRange([
            new Rent { StartTime = DateTime.Now.AddHours(-50), Duration = TimeSpan.FromHours(2), BikeId = Bikes[0].Id, RenterId = Renters[0].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-40), Duration = TimeSpan.FromHours(3), BikeId = Bikes[1].Id, RenterId = Renters[1].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-30), Duration = TimeSpan.FromHours(4), BikeId = Bikes[2].Id, RenterId = Renters[2].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-20), Duration = TimeSpan.FromHours(1.5), BikeId = Bikes[3].Id, RenterId = Renters[3].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-10), Duration = TimeSpan.FromHours(2.5), BikeId = Bikes[4].Id, RenterId = Renters[4].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-5), Duration = TimeSpan.FromHours(5), BikeId = Bikes[5].Id, RenterId = Renters[5].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-3), Duration = TimeSpan.FromHours(6), BikeId = Bikes[6].Id, RenterId = Renters[6].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-2), Duration = TimeSpan.FromHours(2.5), BikeId = Bikes[7].Id, RenterId = Renters[7].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-1), Duration = TimeSpan.FromHours(3.5), BikeId = Bikes[8].Id, RenterId = Renters[8].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-25), Duration = TimeSpan.FromHours(3), BikeId = Bikes[2].Id, RenterId = Renters[0].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-15), Duration = TimeSpan.FromHours(2), BikeId = Bikes[6].Id, RenterId = Renters[1].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-12), Duration = TimeSpan.FromHours(5), BikeId = Bikes[7].Id, RenterId = Renters[3].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-8), Duration = TimeSpan.FromHours(4), BikeId = Bikes[4].Id, RenterId = Renters[5].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-6), Duration = TimeSpan.FromHours(2.5), BikeId = Bikes[5].Id, RenterId = Renters[7].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-4), Duration = TimeSpan.FromHours(3.5), BikeId = Bikes[3].Id, RenterId = Renters[8].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-1.5), Duration = TimeSpan.FromHours(2), BikeId = Bikes[9].Id, RenterId = Renters[0].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-0.5), Duration = TimeSpan.FromHours(3), BikeId = Bikes[7].Id, RenterId = Renters[2].Id },
            new Rent { StartTime = DateTime.Now.AddHours(-0.2), Duration = TimeSpan.FromHours(2), BikeId = Bikes[5].Id, RenterId = Renters[4].Id }
        ]);
    }
}
