using Code.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var Configuration  = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", false, true)
          .AddEnvironmentVariables()
          .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomerContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Code.Application")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllForTest",
                      builder =>
                      {
                          builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllForTest");

app.UseAuthorization();

app.MapControllers();

app.Run();
