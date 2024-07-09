using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Dao;
using BuildWeek1.DataLayer.Dao.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// **********   Configurazione dei servizi di applicazione    **********
builder.Services
    // i DAO possono, in questo contesto, essere tranquillamente configurati come singleton
    // perché non sono legati ad uno specifico utente
    .AddSingleton<ICartItemDao, SqlCartItemDao>()
    .AddSingleton<IImageDao, SqlImageDao>()
    .AddSingleton<IProductDao, SqlProductDao>()

    // la classe DbContext consente di gestire tramite un unico oggetto tutti i DAO
    .AddSingleton<DbContext>()
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
