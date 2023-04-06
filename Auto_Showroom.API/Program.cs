using Auto_Showroom.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.Services.AddDbContext<TestDbContext>(p => p.UseSqlServer("Server =localhost, 1433; Database = testDB10; User Id =SA; Password =MyPass@word;Persist Security Info=False;Encrypt=False"));
app.MapGet("/", () => "Hello World!");

app.Run();