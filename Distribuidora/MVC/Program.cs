using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCContext") ?? throw new InvalidOperationException("Connection string 'MVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",

    pattern: "{controller=OrdenCompra}/{action=IndexCompra}/{id?}");

app.MapControllerRoute(
    name: "ordenCompraProducto",
    pattern: "{controller=OrdenCompraProducto}/{action=PagPrincipalCompraProd}/{id?}");

app.MapControllerRoute(
    name: "categorias",
    pattern: "{controller=Categorias}/{action=PagInicioCategoria}/{id?}");

app.MapControllerRoute(
    name: "cliente",
    pattern: "{controller=Cliente}/{action=IndexClien}/{id?}");

app.MapControllerRoute(
    name: "factura",
    pattern: "{controller=FacturaCabecera}/{action=IndexF}/{id?}");

app.MapControllerRoute(
    name: "ordenVenta",
    pattern: "{controller=OrdenVenta}/{action=PagPrincOrdenVenta}/{id?}");








app.Run();
