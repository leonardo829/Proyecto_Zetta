using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Zetta.DB.Data.Entity; 
using AutoMapper;
using Proyecto_Zetta.Server.Repositorios;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//builder.Services.AddDbContext<Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=(localdb)\\MSSQLLocalDB;Database=Proyecto_ZETTA;Trusted_Connection=True")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>(op => op.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Proyecto_ZETTA;Trusted_Connection=True"));




    builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ISeguimientoRepositorio, SeguimientoRepositorio>();

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
