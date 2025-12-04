using DirectoryService.Infrastructure;
using DirectoryService.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UsePresentation();

app.Run();
