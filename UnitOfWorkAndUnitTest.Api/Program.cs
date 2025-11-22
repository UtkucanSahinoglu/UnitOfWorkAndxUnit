using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkAndxUnit.Application;
using UnitOfWorkAndxUnit.Application.Interfaces;
using UnitOfWorkAndxUnit.Application.Services;
using UnitOfWorkAndxUnit.Domain.Interfaces;
using UnitOfWorkAndxUnit.Infrastructure.Data;
using UnitOfWorkAndxUnit.Infrastructure.UnitOfWork;
using UnitOfWorkAndxUnit.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddInfrastructureServices(
    builder.Configuration.GetConnectionString("DefaultConnection")!
);

builder.Services.AddApplicationServices();


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
