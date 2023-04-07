using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Infrastructure;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar.Validator;
using Auto_Showroom.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(typeof(CreateMovieHandler));


var app = builder.Build();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<GetCarByIDQuery>, CarValidator>();

builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer("Server =localhost, 1433; Database = testDB10; User Id =SA; Password =MyPass@word;Persist Security Info=False;Encrypt=False"));
app.MapGet("/", () => "Hello World!");

app.Run();