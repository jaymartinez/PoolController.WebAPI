using PoolController.WebAPI.Controllers;
using PoolController.WebAPI.Services;
using System.Device.Gpio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILogger<MainController>, Logger<MainController>>();
builder.Services.AddSingleton<IGpioController, GpioControllerWrapper>();
builder.Services.AddScoped<IGpioService, GpioService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
