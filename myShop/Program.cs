
using Reposetories;
using Services;
using Microsoft.EntityFrameworkCore;
using Entities;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<_214416448WebApiContext>(options => options.UseSqlServer("Server=SRV2\\PUPILS;Database=214416448_webApi;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IUserReposetory,UserReposetory>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
