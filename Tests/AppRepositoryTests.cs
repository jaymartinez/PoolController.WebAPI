using DeepEqual.Syntax;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PoolController.WebAPI.Models;
using PoolController.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;

namespace PoolController.WebAPI.Tests
{
    [TestFixture]
    public class AppRepositoryTests
    {
        Mock<ILogger<GpioService>> _loggerMock;
        IAppRepository _repo;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<GpioService>>();
            _repo = new AppRepository();
        }

        [Test]
        public void AppRepository_Constructor_Test()
        {
            Assert.IsNotNull(_repo);
            _repo.PoolPumpSchedule.ShouldDeepEqual(GetDefaultPoolSchedule());
            _repo.BoosterPumpSchedule.ShouldDeepEqual(GetDefaultBoosterSchedule());
            _repo.PoolLightSchedule.ShouldDeepEqual(GetDefaultPoolLightSchedule());
            _repo.SpaLightSchedule.ShouldDeepEqual(GetDefaultSpaLightSchedule());
            _repo.PoolPump.ShouldDeepEqual(new PiPin(PinType.PoolPump));
            _repo.SpaPump.ShouldDeepEqual(new PiPin(PinType.SpaPump));
            _repo.BoosterPump.ShouldDeepEqual(new PiPin(PinType.BoosterPump));
            _repo.PoolLight.ShouldDeepEqual(new PiPin(PinType.PoolLight));
            _repo.SpaLight.ShouldDeepEqual(new PiPin(PinType.SpaLight));
            _repo.GroundLights.ShouldDeepEqual(new PiPin(PinType.GroundLights));
            _repo.Heater.ShouldDeepEqual(new PiPin(PinType.Heater));
            Assert.AreEqual(7, _repo.AllPins.Count());
        }

        EquipmentSchedule GetDefaultPoolSchedule()
        {
            return new EquipmentSchedule
            {
                StartTime = EquipmentSchedule.DefaultPoolStart,
                EndTime = EquipmentSchedule.DefaultPoolEnd,
                IsActive = false,
                Type = ScheduleType.Pool
            };
        }

        EquipmentSchedule GetDefaultBoosterSchedule()
        {
            return new EquipmentSchedule
            {
                StartTime = EquipmentSchedule.DefaultBoosterStart,
                EndTime = EquipmentSchedule.DefaultBoosterEnd,
                IsActive = false,
                Type = ScheduleType.Booster
            };
        }
        EquipmentSchedule GetDefaultPoolLightSchedule()
        {
            return new EquipmentSchedule
            {
                StartTime = EquipmentSchedule.DefaultPoolLightStart,
                EndTime = EquipmentSchedule.DefaultPoolLightEnd,
                IsActive = true,
                Type = ScheduleType.PoolLight
            };
        }
        EquipmentSchedule GetDefaultSpaLightSchedule()
        {
            return new EquipmentSchedule
            {
                StartTime = EquipmentSchedule.DefaultSpaLightStart,
                EndTime = EquipmentSchedule.DefaultSpaLightEnd,
                IsActive = true,
                Type = ScheduleType.SpaLight
            };
        }

        public static IEnumerable<PiPin> GetAllTestPins(PinValue state)
        {
            return new List<PiPin>
            {
                new PiPin(PinType.PoolPump) { PinState = state, GpioPin1 = Pins.PoolPump_1, GpioPin2 = Pins.PoolPump_2 },
                new PiPin(PinType.SpaPump) { PinState = state, GpioPin1 = Pins.SpaPump_1, GpioPin2 = Pins.SpaPump_2},
                new PiPin(PinType.BoosterPump) { PinState = state, GpioPin1 = Pins.BoosterPump_1, GpioPin2 = Pins.BoosterPump_2},
                new PiPin(PinType.PoolLight) { PinState = state, GpioPin1 = Pins.PoolLight },
                new PiPin(PinType.SpaLight) { PinState = state, GpioPin1 = Pins.SpaLight },
                new PiPin(PinType.GroundLights) { PinState = state, GpioPin1 = Pins.GroundLights },
                new PiPin(PinType.Heater) { PinState = state, GpioPin1 = Pins.Heater },
            };
        }
    }
}
