using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using W7.D3.BusinessLayer;
using W7.D3.BusinessLayer.PasswordEncoder;
using W7.D3.DataLayer;
using W7.D3.DataLayer.SqlServer;
using W7.D3.WebAuthenticationSample;
using W7.D3.WebAuthenticationSample.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt => opt.LoginPath = "/Account/Login")
    ;

builder.Services
    .AddAuthorization(opt => {
        opt.AddPolicy(Policies.LoggedIn, cfg => cfg.RequireAuthenticatedUser());
        opt.AddPolicy(Policies.IsAdmin, cfg => cfg.RequireRole("admin"));
        opt.AddPolicy(Policies.AgeRequirements, cfg => {
            cfg.AddRequirements(new MinimumAgeRequirement(18));
        });
    });

builder.Services
    .RegisterDAOs()
    .AddScoped<DbContext>()
    .AddScoped<IAccountService, AccountService>()
    .AddScoped<IPasswordEncoder, NoOpPasswordEncoder>()
    .AddControllersWithViews();

builder.Services
    .AddSingleton<IAuthorizationHandler, MinimumAgeHandler>()
    ;

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
