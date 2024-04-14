using EcommerceB.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;

using EcommerceB.Repositorio.Contrato;
using EcommerceB.Repositorio.Implementacion;
using EcommerceB.Utilidades;
using EcommerceB.Servicio.Contrato;
using EcommerceB.Servicio.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlazorEcommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

//Inyeccion de Dependencias - Repositorio
builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

//Inyeccion de Dependencias - AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Inyeccion de Dependencias - Servicios
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
