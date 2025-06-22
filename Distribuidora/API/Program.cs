using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using CDatos.Repositorios;
using CNegocio.Logica.ILogica;
using CNegocio.Logica;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// Registro de servicios de lógica
builder.Services.AddScoped<ICategoriaLogica, CategoriaLogica>();
builder.Services.AddScoped<ICiudadLogica, CiudadLogica>();
builder.Services.AddScoped<IClienteLogica, ClienteLogica>();
builder.Services.AddScoped<IEmpleadoLogica, EmpleadoLogica>();
builder.Services.AddScoped<IEstadoLogica, EstadoLogica>();
builder.Services.AddScoped<IOrdenDeCompraLogica, OrdenDeCompraLogica>();
builder.Services.AddScoped<IOrdenDeCompraProductoLogica, OrdenDeCompraProductoLogica>();
builder.Services.AddScoped<IOrdenDeVentaLogica, OrdenDeVentaLogica>();
builder.Services.AddScoped<IOrdenDeVentaProductoLogica, OrdenDeVentaProductoLogica>();
builder.Services.AddScoped<IPersonaLogica, PersonaLogica>();
builder.Services.AddScoped<IProductoLogica, ProductoLogica>();
builder.Services.AddScoped<IProveedorLogica, ProveedorLogica>();
builder.Services.AddScoped<ISectorLogica, SectorLogica>();

// Registro de repositorios
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<ICiudadRepositorio, CiudadRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();
builder.Services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
builder.Services.AddScoped<IOrdenDeCompraRepositorio, OrdenDeCompraRepositorio>();
builder.Services.AddScoped<IOrdenDeCompraProductoRepositorio, OrdenDeCompraProductoRepositorio>();
builder.Services.AddScoped<IOrdenDeVentaRepositorio, OrdenDeVentaRepositorio>();
builder.Services.AddScoped<IOrdenDeVentaProductoRepositorio, OrdenDeVentaProductoRepositorio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IProveedorRepositorio, ProveedorRepositorio>();
builder.Services.AddScoped<ISectorRepositorio, SectorRepositorio>();
builder.Services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();

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
