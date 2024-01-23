using BolsaEmpleo.Application.Common.Interfaces;
using BolsaEmpleo.Application.Service.Ciudadanos.Implementation;
using BolsaEmpleo.Application.Service.Ciudadanos.Interfaces;
using BolsaEmpleo.Infrastructure.Context;
using BolsaEmpleo.Infrastructure.Persistence.Auth;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("SQLConnection");

builder.Services.AddControllers();

builder.Services.AddDbContext<BolsaEmpleoDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

#region Services

builder.Services.AddScoped<ICiudadanoRepository, CiudadanoRepository>();
builder.Services.AddScoped<ICiudadanoService, CiudadanoService>();

#endregion Services

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();