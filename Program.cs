using Microsoft.EntityFrameworkCore;
using Shop_API.Data;
using Shop_API.Models.Interfaces;
using Shop_API.Models.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDb")));
// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
