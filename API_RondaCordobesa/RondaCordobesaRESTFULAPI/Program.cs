using Microsoft.EntityFrameworkCore;
using RondaCordobesaRESTFULAPI.Models;
using RondaCordobesaRESTFULAPI.Repositories;
using RondaCordobesaRESTFULAPI.Repositories.Interfaces;
using RondaCordobesaRESTFULAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbRondacordobesaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
