using FiscalCodeWebApi.DataLayer;
using FiscalCodeWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddTransient<IFiscalCodeService, FiscalCodeService>()
    .AddDbContext<AppDataContext>(opt => {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"));
        opt.EnableSensitiveDataLogging();
    })
    ;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
