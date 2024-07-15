using W7.D1.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ****** Registrazione dei servizi applicativi ******
builder.Services
    .AddTransient<IMyService, W7.D1.WebApp.Services.V2.MyService>()
    ;
// ****** Fine della registrazione dei servizi applicativi ******
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
    pattern: "{controller=Home}/{action=Index}/{id?}"
    //pattern: "{action=Index}/{controller=Home}/{id?}"
    //pattern: "{action=Index}/Ciao/{controller=Home}/{id?}"
    );

app.Run();
