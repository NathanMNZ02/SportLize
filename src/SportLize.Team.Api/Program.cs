using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SportLize.Team.Api.Team.Business;
using SportLize.Team.Api.Team.Business.Abstraction;
using SportLize.Team.Api.Team.Business.Kafka;
using SportLize.Team.Api.Team.Business.Kafka.MessageHandlers;
using SportLize.Team.Api.Team.Business.Mapper;
using SportLize.Team.Api.Team.Repository;
using SportLize.Team.Api.Team.Repository.Abstraction;

var builder = WebApplication.CreateBuilder(args);

string? dbHost = Environment.GetEnvironmentVariable("DB_HOST");
string? dbName = Environment.GetEnvironmentVariable("DB_NAME");
string? dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

builder.Services.AddDbContext<TeamDbContext>(options => options.UseSqlServer("name=ConnectionStrings:TeamDbContext",
    b => b.MigrationsAssembly("SportLize.Team.Api")));


builder.Services.AddControllers();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();

object value = builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddKafkaConsumerService<KafkaTopicsInput, MessageHandlerFactory>(builder.Configuration);

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
