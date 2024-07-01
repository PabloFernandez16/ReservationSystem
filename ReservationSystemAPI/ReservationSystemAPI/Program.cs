using Microsoft.EntityFrameworkCore;
using ReservationSystemAPI.Models;
using ReservationSystemAPI.Models.DTOs;
using ReservationSystemAPI.Repositories;
using ReservationSystemAPI.Services;
using WSVenta.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBReservationSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conecction")));



builder.Services.AddScoped<IBaseRepository<Guide, GuideDTO>, GuideService>();
builder.Services.AddScoped<IBaseRepository<Lenguage, LanguageDTO>, LanguageService>();


//********automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
