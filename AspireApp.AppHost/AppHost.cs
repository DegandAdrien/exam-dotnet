var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .AddDatabase("AspireAppDb");


var apiService = builder.AddProject<Projects.AspireApp_ApiService>("apiservice")
    .WithReference(postgres)
    .WaitFor(postgres)
    .WithHttpHealthCheck("/health");


builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
