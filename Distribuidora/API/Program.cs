using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using CDatos.Repositorios;
using CNegocio.Logica.ILogica;
using CNegocio.Logica;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// --- Servicios ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// --- Inyección de dependencias ---
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
builder.Services.AddScoped<IDistribuidorLogica, DistribuidorLogica>();
builder.Services.AddScoped<ISectorLogica, SectorLogica>();
builder.Services.AddScoped<ITipoDocLogica, TipoDocLogica>();

builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IDistribuidorRepositorio, DistribuidorRepositorio>();
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

var app = builder.Build();

// --- Middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// El orden importa: primero redirección, luego métricas, luego controladores
app.UseHttpsRedirection();

// Middleware Prometheus (mide peticiones y tiempos)
app.UseHttpMetrics();

app.UseAuthorization();

// Mapear controladores y endpoint de métricas
app.MapControllers();
app.MapMetrics(); // <- esto expone /metrics

app.Run();
