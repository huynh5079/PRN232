using Lab02_ODataBookAPI.Data;
using Lab02_ODataBookAPI.Models;
using Lab02_ODataBookAPI.Service;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

//// Add DbContext
//builder.Services.AddDbContext<LibraryContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add EF Core InMemory DbContext
builder.Services.AddDbContext<LibraryContext>(opt =>
    opt.UseInMemoryDatabase("LibraryDb"));

// Add OData services with query options enabled
builder.Services.AddControllers()
    .AddOData(opt => opt
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(100)
        .SkipToken()
        .Count()
    );

// Add services to the container.
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IPressService, PressService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

// Map OData routes
app.MapControllers();

app.Run();

// EDM Model Builder method
IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();

    // Define entity sets
    odataBuilder.EntitySet<Book>("Books");
    odataBuilder.EntitySet<Press>("Presses");
    odataBuilder.EntitySet<Address>("Addresses");

    return odataBuilder.GetEdmModel();
}