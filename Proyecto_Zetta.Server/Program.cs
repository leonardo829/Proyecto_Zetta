using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Proyecto_zetta.client.Servicios;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.Server.Repositorios;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddRazorPages();
builder.Services.AddScoped<IHttpServicio, HttpServicio>();
builder.Services.AddHttpClient();

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

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();

