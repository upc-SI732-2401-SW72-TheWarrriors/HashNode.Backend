using HashNode.API.ConferenceManagement.Application.Internal.Services;
using HashNode.API.ConferenceManagement.Application.Internal.Services.CommandServices;
using HashNode.API.ConferenceManagement.Application.Internal.Services.Factories;
using HashNode.API.ConferenceManagement.Application.Internal.Services.QueryServices;
using HashNode.API.ConferenceManagement.Application.Internal.Services.QueryServices.Facades;
using HashNode.API.ConferenceManagement.Domain.Repositories;
using HashNode.API.ConferenceManagement.Domain.Services;
using HashNode.API.ConferenceManagement.Infrastructure.Persistence.Repositories;
using HashNode.API.ConferenceManagement.Presentation.Rest.Mapping;
using HashNode.API.ConferenceManagement.Presentation.Rest.Services;
using HashNode.API.Shared.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "HashDev API Rest", Version = "v1" });
    options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IConferenceService, ConferenceServiceImpl>();
builder.Services.AddScoped<IConferenceQueryService, ConferenceQueryServiceImpl>();
builder.Services.AddScoped<IConferenceCommandService, ConferenceCommandServiceImpl>();
builder.Services.AddScoped<IConferenceCommandFactory, ConferenceFactory>();
builder.Services.AddScoped<IConferenceRepository, ConferenceRepository>();
builder.Services.AddScoped<IConferenceQueryFacade, ConferenceQueryFacade>();

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ModelToResourceProfile)
    );

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
{
    context.Database.EnsureCreated();
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

public partial class Program { }