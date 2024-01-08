using Microsoft.EntityFrameworkCore;
using Server_WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injectar Conexion SQL
builder.Services.AddDbContext<DB_Context>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("RutaSQL"));
});

// Agregar CORS
builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy("NuevaPolitica", app =>
    {
        app
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Activar Politicas CORS
app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
