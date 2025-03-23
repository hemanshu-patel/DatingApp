using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Added CORS to make an Request from frontend with diffrent domain to backend has diffrent domain.
builder.Services.AddCors();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
//Add to configure the application to user angular website instead dotnet api(localhost:5000/5001)
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.MapControllers();

app.Run();
