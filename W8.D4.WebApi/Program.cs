using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using W8.D4.WebApi.DataLayer;
using W8.D4.WebApi.DataLayer.Dao;
using W8.D4.WebApi.DataLayer.Dao.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string issuer = builder.Configuration["Jwt:Issuer"]!;
string audience = builder.Configuration["Jwt:Audience"]!;
string key = builder.Configuration["Jwt:Key"]!;

builder.Services
    // aggiunge le opzioni di autenticazione per JWT
    .AddAuthentication(opt => {
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    // configura il gestore del token
    .AddJwtBearer(opt => {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            // imposta la chiave di codifica/decodifica
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
        };
    });
builder.Services.AddAuthorization();

// registrazione dei servizi DAO
builder.Services
    .AddScoped<IArticleDao, ArticleDao>()
    .AddScoped<ICommentDao, CommentDao>()
    .AddScoped<IAuthorDao, AuthorDao>()
    // registrazione del datacontext 
    .AddScoped<DataContext>()
    ;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
