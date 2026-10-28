
using EduCap.Services;
using EduCap.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar registros para evitar errores de EventLog en Windows.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Agregar los servicios MVC.
builder.Services.AddControllersWithViews();

// Configurar la conexión a SQL Server mediante Entity Framework Core.
builder.Services.AddDbContext<EduCapDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Registrar el servicio de cursos.
builder.Services.AddScoped<ICursoService, CursoSqlService>();

var app = builder.Build();

// Configurar el manejo de errores y HTTPS.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Configurar los archivos estáticos.
app.MapStaticAssets();

// Configurar la ruta principal MVC.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Iniciar la aplicación.
app.Run();
