using Domain.Models;
using Domain.Models.Database;
using Infra.CrossCutting;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var contextOptions = new DbContextOptionsBuilder<SqlDbContext>();
DatabaseConfig.ConfigureDatabases(builder.Services ,builder.Configuration);
builder.Services.AddSingleton<JwtSecret>(new JwtSecret { Key = Environment.GetEnvironmentVariable("jwtSecurityKey") , Issuer = Environment.GetEnvironmentVariable("jwtIssuer") });
IoC.ConfigureServices(builder.Services);
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

