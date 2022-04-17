using PoolController.WebAPI.Controllers;
using PoolController.WebAPI.Services;
using System.Device.Gpio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILogger<MainController>, Logger<MainController>>();
builder.Services.AddSingleton<IGpioController, GpioControllerWrapper>();
builder.Services.AddScoped<IGpioService, GpioService>();
builder.Services.AddSingleton<IAppRepository, AppRepository>();
builder.Services.AddScoped<ILogger<AppRepository>, Logger<AppRepository>>();
builder.Services.AddHostedService<TimerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpLogging();

/*
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<TimerService>();
    })
    .Build();

await host.RunAsync();
*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();
