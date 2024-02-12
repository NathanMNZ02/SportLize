using Microsoft.EntityFrameworkCore;
using SportLize.Profile.Api.Profile.ClientHttp;
using SportLize.Profile.Api.Profile.ClientHttp.Abstraction;
using SportLize.Talk.Api.Talk.Business;
using SportLize.Talk.Api.Talk.Business.Abstraction;
using SportLize.Talk.Api.Talk.Business.Mapper;
using SportLize.Talk.Api.Talk.Repository;
using SportLize.Talk.Api.Talk.Repository.Abstraction;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TalkDbContext>(options => options.UseSqlServer("name=ConnectionStrings:TalkDbContext",
    b => b.MigrationsAssembly("SportLize.Talk.Api")));

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();

object value = builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddHttpClient<IClientHttp, ClientHttp>("ProfileClientHttp", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("ProfileClientHttp:BaseAddress").Value);
})
.ConfigurePrimaryHttpMessageHandler(() => /*Problemi con la verifica del certificato SSL (Ok in debug, no in pubblicazione) */
{
    var handler = new HttpClientHandler();
    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
    return handler;
});

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
