using FITYOU.DATA.Contexts;
using FITYOU.RestApi.Installer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//trate de obtener el conectionString por las enviaroment y me daba una advertencia de que podria venir nula.
//var FityouConection = Environment.GetEnvironmentVariable("FityouConection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FitYouDB2Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("FityouConection")));
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
