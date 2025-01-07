using Microsoft.EntityFrameworkCore;
using RetailManager.Api.Data;
using RetailManager.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var useLocalConnection = builder.Configuration.GetValue<bool>("UseLocalConnection");
var connectionString = useLocalConnection 
    ? builder.Configuration.GetConnectionString("LocalConnection") 
    : builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RetailManagerDbContext>(o => 
    o.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IItemRepository, ItemRepository>();

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