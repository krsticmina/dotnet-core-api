using dotnet_core_api;
using dotnet_core_api.Data.DbContexts;
using dotnet_core_api.ExceptionHandling;
using dotnet_core_api.ExceptionHandling.Exceptions;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Repositories;
using dotnet_core_api.Services;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogDatabaseContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnectionString"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(
    endpoints => endpoints.MapControllers()
);

app.Run();
