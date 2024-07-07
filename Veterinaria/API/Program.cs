using API.Services.Implementations;
using API.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion para el API

builder.Services.AddDbContext<VeterinariaProContext>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();


//Mascotas
builder.Services.AddScoped<IMascotaDAL, MascotaDALImpl>();
builder.Services.AddScoped<IMascotaService, MascotaService>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
