using API.Application.Core;
using API.Application.Products;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager _config = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(typeof(List.Handler).Assembly);

builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
