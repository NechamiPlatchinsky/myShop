
using Reposetories;
using Services;
using Microsoft.EntityFrameworkCore;
using Entities;
using NLog.Web;
using myShop;

var builder = WebApplication.CreateBuilder(args);
string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

string ConnectionString;

if (environment == "Home")
{
    ConnectionString = builder.Configuration.GetConnectionString("HomeConnection");
}
else if (environment == "School")
{
    ConnectionString = builder.Configuration.GetConnectionString("SchoolConnection");
}
else
{
    throw new Exception("Unknown environment");
}
//Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
//builder.Services.AddDbContext<_214416448WebApiContext>(options => options.UseSqlServer("Server=SRV2\\PUPILS;Database=214416448_webApi;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddDbContext<_214416448WebApiContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IUserReposetory,UserReposetory>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductReposetory, ProductReposetory>();
builder.Services.AddScoped<ICategoryReposetory, CategoryReposetory>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IOrderReposetory, OrderReposetory>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseNLog();
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseRatingMiddleware();
app.UseAddRatingMiddleware();
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseErrorHandlingMiddleware();

app.UseStaticFiles();

app.UseAuthorization();


app.MapControllers();

app.Run();