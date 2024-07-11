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
    // poiché arrivano chiamate da parte dei client per il recupero delle immagini,
    // i DAO sono legati alla singola richiesta, in maniera da poter effettuare contemporaneamente
    // chiamate diverse allo stesso database (in regime di concorrenza, la connessione sarebbe inutilizzabile
    // con l'inizializzazione Singleton, perché unica e acceduta contemporaneamente da più parti)
    .AddScoped<ICartItemDao, SqlCartItemDao>()
    .AddScoped<IImageDao, SqlImageDao>()
    .AddScoped<IProductDao, SqlProductDao>()

    // la classe DbContext consente di gestire tramite un unico oggetto tutti i DAO
    .AddScoped<DbContext>()

    // esempio di registrazione di un servizio
    .AddTransient<IThumbnailService, ThumbnailService>()
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
