using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Globalization;
using W8.Services.V1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ***** Configurazione dei servizi di applicazione *****

// configurazione della "localizzazione"
// ogni Culture rappresenta uno specifico linguaggio identificato da una stringa language-specialization
// en è l'inglese generico
// en-US è l'inglese americano
// it è l'italiano generico
// it-IT è l'italiano d'Italia
builder.Services.Configure<RequestLocalizationOptions>(opt => {
    // le diverse culture sono specificate dall'oggetto CultureInfo che contiene informazioni utili per la gestione
    // di tutti i dati "localizzati" (formati delle date, nomi dei mesi ecc.)
    var supportedCultures = new[] { new CultureInfo("it"), new CultureInfo("en") };

    // lingua di default
    opt.DefaultRequestCulture = new RequestCulture(supportedCultures[0], supportedCultures[0]);
    // lingue supportate per i messaggi
    opt.SupportedCultures = supportedCultures;
    // lingue supportate per l'interfaccia utente
    opt.SupportedUICultures = supportedCultures;

    // definisco la mia logica di scelta della lingua
    opt.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context => {
        var lang =
            context.Request.Query["lang"].FirstOrDefault() // legge un parametro di query string
            ??
            context.Request.Headers.AcceptLanguage.ToString().Split(',').FirstOrDefault() // legge lo header della request
            ??
            supportedCultures[0].Name; // per default prende la prima voce nell'array delle cultures supportate

        // per memorizzare la lingua usata ho scelto di usare la TempData
        // accede al servizio di gestione dei TempData (dati persistenti durante tutta la durata della richiesta)
        var factory = context.RequestServices.GetService<ITempDataDictionaryFactory>();
        // questa variabile è la TempData che troviamo nei controller e nelle viste
        var tempData = factory?.GetTempData(context);
        // aggiungo o modifico la chiave che userò per settare la lingua nell'HTML
        if (tempData?.ContainsKey("Language") ?? false) tempData["Language"] = lang; else tempData?.Add("Language", lang);

        // qui invece imposto la lingua dell'applicazione
        return await Task.FromResult(new ProviderCultureResult(lang));
    }));
});

builder.Services
    // configura le opzioni per trasferire la posizione del file di popolamento delle città
    .Configure<CityServiceOptions>(opt => {
        opt.SourceFile = Path.Combine(builder.Environment.WebRootPath, builder.Configuration["CityService:SourceFile"]!);
    })
    .AddDataLayer()
    .AddDbContext()
    .AddServices()
    ;
// ***** Fine della configurazione dei servizi di applicazione *****

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRequestLocalization();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
