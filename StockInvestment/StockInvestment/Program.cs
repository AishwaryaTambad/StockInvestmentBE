//using StockInvestment.Models;
//using StockInvestment.Services;

using Microsoft.EntityFrameworkCore;
using StockInvestment.Models;
using StockInvestment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<StudentDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<StockInvestmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<RepositoryStudent, StudentServices>();
builder.Services.AddScoped<IRepositoryUsers, UsersServices>();
builder.Services.AddScoped<IRepositoryStock, StockServices>();
builder.Services.AddScoped<IRepositoryStockPrice, StockPriceServices>();
////builder.Services.AddDbContext<StudentContext>(RepositoryStudent,StudentServices);
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
