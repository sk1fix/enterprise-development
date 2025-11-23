var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BikeRentalPoint_Api_Host>("bikerentalpoint-api-host");

builder.Build().Run();
