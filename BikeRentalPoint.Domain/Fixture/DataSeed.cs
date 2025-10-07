using BikeRentalPoint.Domain.Models;

namespace BikeRentalPoint.Domain.Fixture;

/// <summary>
/// Provides methods for generating source data for a bike rental point
/// </summary>
public static class DataSeed
{
    /// <summary>
    /// Generates seed data for models
    /// </summary>
    public static List<Model> GetModels() => new()
        {
            new Model { WheelSize = 28, MaxPassengerWeight = 100, BikeWeight = 9, BrakeType = BrakeType.Disc, ModelYear = 2022, PricePerHour = 12, BikeType = BikeType.Road },
            new Model { WheelSize = 26, MaxPassengerWeight = 110, BikeWeight = 11, BrakeType = BrakeType.Rim, ModelYear = 2021, PricePerHour = 10, BikeType = BikeType.Mountain },
            new Model { WheelSize = 29, MaxPassengerWeight = 120, BikeWeight = 13, BrakeType = BrakeType.Disc, ModelYear = 2023, PricePerHour = 15, BikeType = BikeType.Mountain },
            new Model { WheelSize = 27.5f, MaxPassengerWeight = 90, BikeWeight = 10, BrakeType = BrakeType.Rim, ModelYear = 2020, PricePerHour = 9, BikeType = BikeType.Hybrid },
            new Model { WheelSize = 28, MaxPassengerWeight = 100, BikeWeight = 12, BrakeType = BrakeType.Drum, ModelYear = 2024, PricePerHour = 14, BikeType = BikeType.Road },
            new Model { WheelSize = 24, MaxPassengerWeight = 80, BikeWeight = 8, BrakeType = BrakeType.Tape, ModelYear = 2019, PricePerHour = 8, BikeType = BikeType.Folding },
            new Model { WheelSize = 26, MaxPassengerWeight = 100, BikeWeight = 14, BrakeType = BrakeType.Disc, ModelYear = 2024, PricePerHour = 16, BikeType = BikeType.Electric },
            new Model { WheelSize = 29, MaxPassengerWeight = 130, BikeWeight = 15, BrakeType = BrakeType.RodActuated, ModelYear = 2023, PricePerHour = 13, BikeType = BikeType.Mountain },
            new Model { WheelSize = 27, MaxPassengerWeight = 95, BikeWeight = 11, BrakeType = BrakeType.Rim, ModelYear = 2021, PricePerHour = 11, BikeType = BikeType.Hybrid },
            new Model { WheelSize = 28, MaxPassengerWeight = 120, BikeWeight = 12, BrakeType = BrakeType.Disc, ModelYear = 2025, PricePerHour = 17, BikeType = BikeType.Road }
        };

    /// <summary>
    /// Generates seed data for renters
    /// </summary>
    public static List<Renter> GetRenters() => new()
        {
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
        };

    /// <summary>
    /// Generates seed data for bikes
    /// </summary>
    public static List<Bike> GetBikes(List<Model> models) => new()
        {
            new Bike { SerialNumber = 101, Color = "Red", Model = models[0] },
            new Bike { SerialNumber = 102, Color = "Blue", Model = models[1] },
            new Bike { SerialNumber = 103, Color = "Black", Model = models[2] },
            new Bike { SerialNumber = 104, Color = "Green", Model = models[3] },
            new Bike { SerialNumber = 105, Color = "White", Model = models[4] },
            new Bike { SerialNumber = 106, Color = "Yellow", Model = models[5] },
            new Bike { SerialNumber = 107, Color = "Silver", Model = models[6] },
            new Bike { SerialNumber = 108, Color = "Gray", Model = models[7] },
            new Bike { SerialNumber = 109, Color = "Orange", Model = models[8] },
            new Bike { SerialNumber = 110, Color = "Purple", Model = models[9] }
        };

    /// <summary>
    /// Generates seed data for rents
    /// </summary>
    public static List<Rent> GetRents(List<Bike> bikes, List<Renter> renters) => new()
        {
            new Rent { StartTime = DateTime.Now.AddHours(-50), Duration = 2, Bike = bikes[0], Renter = renters[0] },
            new Rent { StartTime = DateTime.Now.AddHours(-40), Duration = 3, Bike = bikes[1], Renter = renters[1] },
            new Rent { StartTime = DateTime.Now.AddHours(-30), Duration = 4, Bike = bikes[2], Renter = renters[2] },
            new Rent { StartTime = DateTime.Now.AddHours(-20), Duration = 1.5m, Bike = bikes[3], Renter = renters[3] },
            new Rent { StartTime = DateTime.Now.AddHours(-10), Duration = 2.5m, Bike = bikes[4], Renter = renters[4] },
            new Rent { StartTime = DateTime.Now.AddHours(-5), Duration = 5, Bike = bikes[5], Renter = renters[5] },
            new Rent { StartTime = DateTime.Now.AddHours(-3), Duration = 6, Bike = bikes[6], Renter = renters[6] },
            new Rent { StartTime = DateTime.Now.AddHours(-2), Duration = 2.5m, Bike = bikes[7], Renter = renters[7] },
            new Rent { StartTime = DateTime.Now.AddHours(-1), Duration = 3.5m, Bike = bikes[8], Renter = renters[8] },
            new Rent { StartTime = DateTime.Now.AddMinutes(-30), Duration = 4.5m, Bike = bikes[9], Renter = renters[9] },
            new Rent { StartTime = DateTime.Now.AddHours(-25), Duration = 3, Bike = bikes[2], Renter = renters[0] },
            new Rent { StartTime = DateTime.Now.AddHours(-15), Duration = 2, Bike = bikes[6], Renter = renters[1] },
            new Rent { StartTime = DateTime.Now.AddHours(-12), Duration = 5, Bike = bikes[7], Renter = renters[3] },
            new Rent { StartTime = DateTime.Now.AddHours(-8), Duration = 4, Bike = bikes[4], Renter = renters[5] },
            new Rent { StartTime = DateTime.Now.AddHours(-6), Duration = 2.5m, Bike = bikes[5], Renter = renters[7] },
            new Rent { StartTime = DateTime.Now.AddHours(-4), Duration = 3.5m, Bike = bikes[3], Renter = renters[8] },
            new Rent { StartTime = DateTime.Now.AddHours(-2.5), Duration = 1.5m, Bike = bikes[8], Renter = renters[9] },
            new Rent { StartTime = DateTime.Now.AddHours(-1.5), Duration = 2, Bike = bikes[9], Renter = renters[0] },
            new Rent { StartTime = DateTime.Now.AddHours(-0.5), Duration = 3, Bike = bikes[7], Renter = renters[2] },
            new Rent { StartTime = DateTime.Now.AddHours(-0.2), Duration = 2, Bike = bikes[5], Renter = renters[4] }
        };
}

