global using Store.Inventory.Repositories.Config;
global using Store.Inventory.Services.Config;
global using Store.Inventory.Domain.Config;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddHttpContextAccessor();

var configuration = builder.Configuration;
var services = builder.Services;

//Register our custom services here.
RegisterServices.RegisterComponents(services, configuration);
RegisterRepositories.RegisterComponents(services, configuration);
RegisterDomainServices.RegisterComponents(services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();