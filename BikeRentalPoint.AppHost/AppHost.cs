var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql-bikerentalpoint")
    .AddDatabase("BikeRentalPointDb");

builder.AddProject<Projects.BikeRentalPoint_Api_Host>("api")
    .WithReference(mysql, "DefaultConnection")
    .WaitFor(mysql);

builder.Build().Run();