using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using WebApplication.Business.Services.ArticleClientService;
using WebApplication.Business.Services.ArticleStoreService;
using WebApplication.Business.Services.Auth;
using WebApplication.Business.Services.StoreService;
using WebApplication.Data.Context;
using WebApplication.Data.Repositories;
using WebApplication.Entities.Entities;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
var cors = "_cors";
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
                options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<Client>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: cors,
        pol =>
        {
            pol.WithOrigins("http://localhost:4200"); //Angular localhost 
            pol.AllowAnyMethod();
            pol.AllowAnyHeader();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddScoped<IGenericRepository<Store>, StoreRepository>();
builder.Services.AddScoped<IGenericRepository<ArticleStore>, ArticleStoreRepository>();
builder.Services.AddScoped<IGenericRepository<ArticleClient>, ArticleClientRepository>();
builder.Services.AddScoped<IStoreService,  StoreService>();
builder.Services.AddScoped<IArticleClientService, ArticleClientService>();
builder.Services.AddScoped<IArticleStoreService, ArticleStoreService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});




var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(cors);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
