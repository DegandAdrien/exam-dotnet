var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("user", secret: true, value:"user");
var password = builder.AddParameter("password", secret: true, value:"password");

var postgres = builder.AddPostgres("postgres", username, password, 5432)
    .WithLifetime(ContainerLifetime.Persistent);

var postgresdb = postgres.AddDatabase("postgresdb");

var apiService = builder.AddProject<Projects.AspireApp_ApiService>("apiservice")
    .WithReference(postgresdb)
    .WaitFor(postgresdb)
    .WithHttpHealthCheck("/health");


builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
