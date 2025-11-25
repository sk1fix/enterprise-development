using BikeRentalPoint.Application;
using BikeRentalPoint.Application.Contracts;
using BikeRentalPoint.Application.Contracts.Analytics;
using BikeRentalPoint.Application.Contracts.Bike;
using BikeRentalPoint.Application.Contracts.Model;
using BikeRentalPoint.Application.Contracts.Rent;
using BikeRentalPoint.Application.Contracts.Renter;
using BikeRentalPoint.Application.Services;
using BikeRentalPoint.Domain;
using BikeRentalPoint.Domain.Fixture;
using BikeRentalPoint.Domain.Models;
using BikeRentalPoint.Infrastructure.EfCore;
using BikeRentalPoint.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(a => a.GetName().Name!.StartsWith("BikeRentalPoint"))
        .Distinct();

    foreach (var assembly in assemblies)
    {
        var xmlFile = $"{assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);
    }
    c.UseInlineDefinitionsForEnums();
});

builder.Services.AddAutoMapper(typeof(BikeRentalProfile));


builder.Services.AddSingleton<DataSeed>();

builder.AddMySqlDbContext<BikeRentalPointDbContext>(connectionName: "DefaultConnection", configureDbContextOptions: builder => builder.UseLazyLoadingProxies());

builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddScoped<IRepository<Bike, Guid>, BikeEfCoreRepository>();
builder.Services.AddScoped<IRepository<Model, Guid>, ModelEfCoreRepository>();
builder.Services.AddScoped<IRepository<Renter, Guid>, RenterEfCoreRepository>();
builder.Services.AddScoped<IRepository<Rent, Guid>, RentEfCoreRepository>();

builder.Services.AddScoped<IBikeService, BikeService>();
builder.Services.AddScoped<IApplicationService<ModelDto, CreateModelDto, Guid>, ModelService>();
builder.Services.AddScoped<IApplicationService<RenterDto, CreateRenterDto, Guid>, RenterService>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BikeRentalPointDbContext>();
    await context.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();