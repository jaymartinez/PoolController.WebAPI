using PoolController.WebAPI.Models;
using System.Device.Gpio;

namespace PoolController.WebAPI.Services
{
    public class TimerService : BackgroundService, IDisposable
    {
        readonly ILogger<TimerService> _logger;
        readonly IGpioService _gpioService;
        readonly IAppRepository _appRepository;

        Timer _timer = null!;

        public TimerService(
            ILogger<TimerService> logger, 
            IGpioService gpioService,
            IAppRepository appRepository)
        {
            _logger = logger;
            _gpioService = gpioService;
            _appRepository = appRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);

                var now = DateTimeOffset.Now;

                // Grab anything that has a schedule enabled
                var pool = _gpioService.GetPool();
                var booster = _gpioService.GetBooster();
                var spa = _gpioService.GetSpa();

                try
                {
                    if (pool.Schedule.IsActive)
                    {
                        if (pool.Schedule.StartTime.Hours == now.Hour
                            && pool.Schedule.StartTime.Minutes == now.Minute)
                        {
                            // The pool and booster operate on two pins so make sure they are both in sync.
                            // Also if it's already on no need to keep writing to it
                            if (_gpioService.Read(Pins.PoolPump_1) == PinValue.High
                                && _gpioService.Read(Pins.PoolPump_2) == PinValue.High)
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool is already on so timer ignored.");
                            }
                            else
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool timer triggered [ON].");
                                /*
                                if (_gpioService.Toggle(PinType.PoolPump))
                                {
                                    _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool timer active.");
                                }
                                */
                            }

                        }
                        else if (pool.Schedule.EndTime.Hours == now.Hour 
                            && pool.Schedule.EndTime.Minutes == now.Minute)
                        {
                            if (_gpioService.Read(Pins.PoolPump_1) == PinValue.Low
                                && _gpioService.Read(Pins.PoolPump_2) == PinValue.Low)
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool is already off so timer ignored.");
                            }
                            else
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool timer triggered [OFF].");
                                /*
                                if (_gpioService.Toggle(PinType.PoolPump))
                                {
                                    _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool timer active.");
                                }
                                */
                            }

                        }
                    }

                    if (booster.Schedule.IsActive)
                    {
                        if (booster.Schedule.StartTime.Hours == now.Hour 
                            && booster.Schedule.StartTime.Minutes == now.Minute)
                        {
                            if (_gpioService.Read(Pins.BoosterPump_1) == PinValue.High
                                && _gpioService.Read(Pins.BoosterPump_2) == PinValue.High)
                            {
                                // already on
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Booster is already on so timer ignored.");
                            }
                            else
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Booster timer triggered [ON].");
                            }
                        }
                        else if (booster.Schedule.EndTime.Hours == now.Hour 
                            && booster.Schedule.EndTime.Minutes == now.Minute)
                        {
                            if (_gpioService.Read(Pins.BoosterPump_1) == PinValue.Low
                                && _gpioService.Read(Pins.BoosterPump_2) == PinValue.Low)
                            {
                                // already off
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Booster is already OFF so timer ignored.");
                            }
                            else
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Booster timer triggered [OFF].");
                            }
                        }
                    }

                    if (spa.Light.Schedule.IsActive)
                    {
                        if (spa.Light.Schedule.StartTime.Hours == now.Hour
                            && spa.Light.Schedule.StartTime.Minutes == now.Minute)
                        {
                            if (_gpioService.Read(Pins.SpaLight) == PinValue.High)
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Spa Light is already ON so timer ignored.");
                            }
                            else
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Spa Light timer triggered [ON]");
                            }
                        }
                        else if (spa.Light.Schedule.EndTime.Hours == now.Hour
                            && spa.Light.Schedule.EndTime.Minutes == now.Minute)
                        {
                            if (_gpioService.Read(Pins.SpaLight) == PinValue.Low)
                            {
                                // already off
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Booster is already off so timer ignored.");
                            }
                            else
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Spa Light timer triggered [OFF]");
                            }

                        }

                    }

                    if (pool.Light.Schedule.IsActive)
                    {
                        if (pool.Light.Schedule.StartTime.Hours == now.Hour
                            && pool.Light.Schedule.StartTime.Minutes == now.Minute)
                        {
                            if (_gpioService.Read(Pins.PoolLight) == PinValue.High)
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool Light is already ON so timer ignored.");
                            }
                            else
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool Light timer triggered [ON]");
                            }
                        }
                        else if (pool.Light.Schedule.EndTime.Hours == now.Hour
                            && pool.Light.Schedule.EndTime.Minutes == now.Minute)
                        {
                            if (_gpioService.Read(Pins.PoolLight) == PinValue.Low)
                            {
                                // already off
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool Light is already off so timer ignored.");
                            }
                            else
                            {
                                _logger.LogInformation($"[BackgroundService.ExecuteAsync] {now} - Pool Light timer triggered [OFF]");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception was thrown while handling background service: " + ex.Message);
                }
            }
        }

        #region Commented out code
        //int executionCount = 0;

        //public Task StartAsync(CancellationToken stoppingToken)
        //{
        //    _logger.LogInformation("Timed Hosted Service running.");

        //    _timer = new Timer(DoWork, null, TimeSpan.Zero,
        //        TimeSpan.FromSeconds(5));

        //    return Task.CompletedTask;
        //}

        //private void DoWork(object? state)
        //{
        //    var count = Interlocked.Increment(ref executionCount);

        //    _logger.LogInformation(
        //        "Timed Hosted Service is working. Count: {Count}", count);
        //}

        //public Task StopAsync(CancellationToken stoppingToken)
        //{
        //    _logger.LogInformation("Timed Hosted Service is stopping.");

        //    _timer?.Change(Timeout.Infinite, 0);

        //    return Task.CompletedTask;
        //}
        #endregion
    }
}
