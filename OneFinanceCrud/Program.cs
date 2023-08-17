using Microsoft.EntityFrameworkCore;
using OneFinanceCrud.Configration;
using OneFinanceCrud.Context;
using OneFinanceCrud.Repository;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string con = builder.Configuration.GetConnectionString("localConnection");
builder.Services.AddDbContext<ProductDbContext>(p => p.UseSqlServer(con));
builder.Services.AddScoped
    <ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped
    <IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(MapConfig));

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
