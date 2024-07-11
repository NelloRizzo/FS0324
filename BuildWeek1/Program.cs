using BuildWeek1.BusinessLayer;
using BuildWeek1.BusinessLayer.V1;
using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Dao;
using BuildWeek1.DataLayer.Dao.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddHttpContextAccessor()
    .AddControllersWithViews();

// **********   Configurazione dei servizi di applicazione    **********
builder.Services
    // registrazione dei DAO e della classe che gestisce tutto il contesto dati
    // vedi classe DataLayer.RegisterDbContextHelpers
    .AddDbContext()

    // registrazione dei servizi applicativi
    // vedi classe BusinessLayer.RegisterServicesHelpers
    .AddTransient<IThumbnailService, ThumbnailService>()
    .AddTransient<IProductService, ProductService>()
    ;
// ********** Fine configurazione dei servizi di applicazione **********


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mappatura di aree applicative
app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
