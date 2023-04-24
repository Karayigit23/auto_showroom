using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Infrastructure;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;
using Auto_Showroom.Infrastructure.Repositories;
using Auto_Showroom.Middlewares;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddMediatR(typeof(CreateCarCommand));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddSwaggerDocument(p=>p.PostProcess=(o => { o.Info.Title = "Auto_Showroom";}));


builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(builder.Configuration.GetValue<string>("sqlConnection")));

builder.Services.AddControllers();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<AppDbContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
}

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi3();

app.MapGet("/", () => "Hello World");

app.Run();