using BuildingBlocks.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarterWithAssemblies(typeof(Program).Assembly);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("PostgreSQLConnection")!);
}).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

// Make Mapster to map properties by ignoring cases.
TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);
app.Run();
