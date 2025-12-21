using BikeRentalPoint.Application.Contracts.Rent;
using BikeRentalPoint.Generator.Kafka.Host;
using BikeRentalPoint.Generator.Kafka.Host.Interfaces;
using BikeRentalPoint.Generator.Kafka.Host.Serializers;

var builder = WebApplication.CreateBuilder(args);

builder.AddKafkaProducer<Guid, IList<CreateRentDto>>(
    "bike-rental-point-kafka",
    kafkaBuilder =>
    {
        kafkaBuilder.SetKeySerializer(new BikeRentalPointKeySerializer());
        kafkaBuilder.SetValueSerializer(new BikeRentalPointValueSerializer());
    });

builder.AddServiceDefaults();

builder.Services.AddScoped<IProducerService, BikeRentalPointKafkaProducer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
    .Where(a => a.GetName().Name!.StartsWith("BikeRentalPoint"))
    .Distinct();

    foreach (var assembly in assemblies)
    {
        var xmlFile = $"{assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();