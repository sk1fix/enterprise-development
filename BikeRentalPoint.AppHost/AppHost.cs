var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql-bikerentalpoint")
    .AddDatabase("BikeRentalPointDb");

var apiHost = builder.AddProject<Projects.BikeRentalPoint_Api_Host>("api")
    .WithReference(mysql, "DefaultConnection")
    .WaitFor(mysql);

var kafka = builder.AddKafka("bike-rental-point-kafka")
    .WithKafkaUI();

var seedBikes = builder.AddParameter("BikeIds");
var seedRenters = builder.AddParameter("RenterIds");

var kafkaTopic = builder.AddParameter("KafkaTopic");
builder.AddProject<Projects.BikeRentalPoint_Generator_Kafka_Host>("bike-rental-point-generator-kafka-host")
    .WithReference(kafka)
    .WaitFor(kafka)
    .WithEnvironment("Kafka:TopicName", kafkaTopic)
    .WithEnvironment("BikeIds", seedBikes)
    .WithEnvironment("RenterIds", seedRenters);

apiHost.WithEnvironment("Kafka:TopicName", kafkaTopic)
    .WithReference(kafka)
    .WaitFor(kafka);

builder.Build().Run();