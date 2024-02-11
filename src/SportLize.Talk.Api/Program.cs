using Microsoft.EntityFrameworkCore;
using SportLize.Talk.Api.Talk.Business;
using SportLize.Talk.Api.Talk.Business.Abstraction;
using SportLize.Talk.Api.Talk.Business.Kafka;
using SportLize.Talk.Api.Talk.Business.Kafka.MessageHandlers;
using SportLize.Talk.Api.Talk.Business.Mapper;
using SportLize.Talk.Api.Talk.Repository;
using SportLize.Talk.Api.Talk.Repository.Abstraction;

var builder = WebApplication.CreateBuilder(args);

string? dbHost = Environment.GetEnvironmentVariable("DB_HOST");
string? dbName = Environment.GetEnvironmentVariable("DB_NAME");
string? dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

builder.Services.AddDbContext<TalkDbContext>(options => options.UseSqlServer("name=ConnectionStrings:TalkDbContext",
    b => b.MigrationsAssembly("SportLize.Talk.Api")));

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
