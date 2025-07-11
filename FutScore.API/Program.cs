using FutScore.API.Endpoints;
using FutScore.Data;
using FutScore.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FutScoreDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(DAL<>), typeof(DAL<>));                   //Linha para registrar DAL genérico
builder.Services.AddScoped<TimeRepository>();
builder.Services.AddScoped<CampeonatoRepository>();

var app = builder.Build();

app.AddEndpointsTimes();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();