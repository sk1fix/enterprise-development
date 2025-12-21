using BikeRentalPoint.Domain.Fixture;
using BikeRentalPoint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalPoint.Infrastructure.EfCore;

/// <summary>
/// EF Core database context for bike rental domain
/// </summary>
public class BikeRentalPointDbContext(DbContextOptions<BikeRentalPointDbContext> options, DataSeed seeder) : DbContext(options)
{
    /// <summary>
    /// Bicycles in the database
    /// </summary>
    public DbSet<Bike> Bikes { get; set; }

    /// <summary>
    /// Bicycle models in the database
    /// </summary>
    public DbSet<Model> Models { get; set; }

    /// <summary>
    /// Renters in the database
    /// </summary>
    public DbSet<Renter> Renters { get; set; }

    /// <summary>
    /// Rentals in the database
    /// </summary>
    public DbSet<Rent> Rents { get; set; }

    /// <summary>
    /// Configures entity relationships, keys, and constraints
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Model>(entity =>
        {
            entity.ToTable("model");
            entity.HasKey(m => m.Id);

            entity.Property(m => m.WheelSize)
                .HasColumnName("wheel_size");

            entity.Property(m => m.MaxPassengerWeight)
                .HasColumnName("max_passenger_weight");

            entity.Property(m => m.BikeWeight)
                .HasColumnName("bike_weight");

            entity.Property(m => m.BrakeType)
                .HasColumnName("brake_type")
                .HasConversion<int>()
                .IsRequired();

            entity.Property(m => m.ModelYear)
                .HasColumnName("model_year");

            entity.Property(m => m.PricePerHour)
                .HasColumnName("price_per_hour")
                .HasPrecision(10, 2)
                .IsRequired();

            entity.Property(m => m.BikeType)
                .HasColumnName("bike_type")
                .HasConversion<int>()
                .IsRequired();

            entity.HasMany<Bike>()
                .WithOne(b => b.Model)
                .HasForeignKey(b => b.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(seeder.Models);
        });

        modelBuilder.Entity<Bike>(entity =>
        {
            entity.ToTable("bike");
            entity.HasKey(b => b.Id);

            entity.Property(b => b.SerialNumber)
                .HasColumnName("serial_number")
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(b => b.Color)
                .HasColumnName("color")
                .HasMaxLength(30);

            entity.Property(b => b.ModelId)
                .HasColumnName("model_id")
                .IsRequired();

            entity.HasOne(b => b.Model)
                .WithMany()
                .HasForeignKey(b => b.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(seeder.Bikes);
        });

        modelBuilder.Entity<Renter>(entity =>
        {
            entity.ToTable("renter");
            entity.HasKey(r => r.Id);

            entity.Property(r => r.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(r => r.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(r => r.MiddleName)
                .HasColumnName("middle_name")
                .HasMaxLength(100);

            entity.Property(r => r.PhoneNumber)
                .HasColumnName("phone_number")
                .IsRequired()
                .HasMaxLength(20);

            entity.HasMany<Rent>()
                .WithOne(r => r.Renter)
                .HasForeignKey(r => r.RenterId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(seeder.Renters);
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.ToTable("rent");
            entity.HasKey(r => r.Id);

            entity.Property(r => r.StartTime)
                .HasColumnName("start_time")
                .IsRequired();

            entity.Property(r => r.Duration)
                .HasColumnName("duration")
                .IsRequired();

            entity.Property(r => r.BikeId)
                .HasColumnName("bike_id")
                .IsRequired();

            entity.Property(r => r.RenterId)
                .HasColumnName("renter_id")
                .IsRequired();

            entity.HasOne(r => r.Bike)
                .WithMany()
                .HasForeignKey(r => r.BikeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Renter)
                .WithMany()
                .HasForeignKey(r => r.RenterId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(seeder.Rents);
        });
    }
}