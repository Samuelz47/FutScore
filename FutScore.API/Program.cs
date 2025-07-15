using FutScore.API.Endpoints;
using FutScore.Data;
using FutScore.Data.Migrations;
using FutScore.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FutScoreDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(DAL<>), typeof(DAL<>));                   //Linha para registrar DAL gen�rico
builder.Services.AddScoped<TimeRepository>();
builder.Services.AddScoped<CampeonatoRepository>();
builder.Services.AddScoped<JogadorRepository>();

var app = builder.Build();

app.AddEndpointsTimes();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();