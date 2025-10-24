using MVC.ConfigAPI;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

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

// 🔹 Habilitar sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // tiempo de expiración
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpMetrics();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapMetrics();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleados}/{action=Login}/{id?}");

app.Run();

