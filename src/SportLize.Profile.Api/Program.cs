using Microsoft.EntityFrameworkCore;
using SportLize.Profile.Api.Profile.Business;
using SportLize.Profile.Api.Profile.Business.Abstraction;
using SportLize.Profile.Api.Profile.ClientHttp;
using SportLize.Profile.Api.Profile.ClientHttp.Abstraction;
using SportLize.Profile.Api.Profile.Repository;
using SportLize.Profile.Api.Profile.Repository.Abstraction;

var builder = WebApplication.CreateBuilder(args);

string? dbHost = Environment.GetEnvironmentVariable("DB_HOST");
string? dbName = Environment.GetEnvironmentVariable("DB_NAME");
string? dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

builder.Services.AddDbContext<ProfileDbContext>(options =>
    options.UseNpgsql($"Host={dbHost};Database={dbName};Username=postgres;Password={dbPassword}"));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();