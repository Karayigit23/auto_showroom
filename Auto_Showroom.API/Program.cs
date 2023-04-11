using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Infrastructure;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;
using Auto_Showroom.Infrastructure.Repositories;

using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddMediatR(typeof(CreateCarCommand));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer("Server =localhost, 1433; Database = testDB10; User Id =SA; Password =MyPass@word;Persist Security Info=False;Encrypt=False"));

builder.Services.AddControllers();
var app = builder.Build();
app.UseAuthorization();


app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();