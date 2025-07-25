using DataAccess.Entities;
using DataAccess.Repositories.Abstraction;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Business.Services.Interface;
using Business.Services;
using Business.Mappings;

var builder = WebApplication.CreateBuilder(args);

// CORS 
builder.Services.AddCors();

// Add DbContext
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
