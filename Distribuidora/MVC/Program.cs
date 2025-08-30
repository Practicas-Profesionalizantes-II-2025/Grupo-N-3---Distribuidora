using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.Data;
using MVC.ConfigAPI;
using NuGet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<MVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCContext")
        ?? throw new InvalidOperationException("Connection string 'MVCContext' not found.")));

// Configuración de ApiSettings
builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

// Registro del HttpClient con BaseAddress
builder.Services.AddHttpClient("API", client =>
{
    var baseUrl = builder.Configuration["ApiSettings:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "categorias",
    pattern: "{controller=Categorias}/{action=crearCategoria}/{id?}");

app.Run();
