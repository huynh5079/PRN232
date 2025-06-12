using BusinessLayer.Profiles;
using BusinessLayer.Repositories;
using BusinessLayer.Services;
using DataLayer.Data;
using DataLayer.Entities; 
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

// Only Courses.
ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Courses>("Courses");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SP25PEDBContext>(options =>
    options.UseSqlServer(connectionString));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add repo 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// Add serv
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();

// Controllers
builder.Services.AddControllers().AddOData(options => options
    .Select() 
    .Filter() 
    .OrderBy()
    .Expand()
    .Count()
    .SetMaxTop(null) 
    .AddRouteComponents("odata", modelBuilder.GetEdmModel())
);

// Learn more about configuring Swagger/OpenAPI
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

app.MapControllers();

app.Run();
