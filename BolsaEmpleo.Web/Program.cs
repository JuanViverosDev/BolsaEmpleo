using BolsaEmpleo.Application.Common.Interfaces;
using BolsaEmpleo.Application.Service.Ciudadanos.Implementation;
using BolsaEmpleo.Application.Service.Ciudadanos.Interfaces;
using BolsaEmpleo.Application.Service.Vacantes.Implementation;
using BolsaEmpleo.Application.Service.Vacantes.Interfaces;
using BolsaEmpleo.Infrastructure.Context;
using BolsaEmpleo.Infrastructure.Persistence.Auth;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("SQLConnection");

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173", "https://bolsa-empleo.netlify.app");
            policy.AllowCredentials();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});
builder.Services.AddControllers();

builder.Services.AddDbContext<BolsaEmpleoDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

#region Services

builder.Services.AddScoped<ICiudadanoRepository, CiudadanoRepository>();
builder.Services.AddScoped<ICiudadanoService, CiudadanoService>();

builder.Services.AddScoped<IVacanteRepository, VacanteRepository>();
builder.Services.AddScoped<IVacanteService, VacanteService>();

#endregion Services

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();