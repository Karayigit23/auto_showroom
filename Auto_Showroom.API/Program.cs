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

builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddMediatR(typeof(CreateCarCommand));
builder.Services.AddMediatR(typeof(DeleteCarQuery));
builder.Services.AddMediatR(typeof(UpdateCarQuery));
builder.Services.AddMediatR(typeof(GetAllCarQuery));
builder.Services.AddMediatR(typeof(GetCarByIDQuery));



var app = builder.Build();

builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddScoped<IValidator<>, CarValidator>();

builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer("Server =localhost, 1433; Database = testDB10; User Id =SA; Password =MyPass@word;Persist Security Info=False;Encrypt=False"));
app.MapGet("/", () => "Hello World!");

app.Run();