using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories;
using DataLayer.Services;
using Microsoft.OData.Edm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AssignmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories and Services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGenericRepository<SystemAccount>, GenericRepository<SystemAccount>>();
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IGenericRepository<NewsArticle>, GenericRepository<NewsArticle>>();
builder.Services.AddScoped<IGenericRepository<Tag>, GenericRepository<Tag>>();
builder.Services.AddScoped<IGenericRepository<NewsTag>, GenericRepository<NewsTag>>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();   
builder.Services.AddScoped<INewsArticleService, NewsArticleService>(); 
builder.Services.AddScoped<ITagService, TagService>();

// Configure JWT Authentication
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured.")))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers()
    .AddOData(opt =>
        opt.AddRouteComponents("odata", GetEdmModel()).Filter().Select().Expand().OrderBy().Count().SetMaxTop(100));

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseODataBatching();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<SystemAccount>("Accounts");
    builder.EntitySet<Category>("Categories");
    builder.EntitySet<NewsArticle>("NewsArticles");
    builder.EntitySet<Tag>("Tags");
    return builder.GetEdmModel();
}