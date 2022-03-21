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
    public class GpioServiceTests
    {
        Mock<IGpioController> _gpioMock;
        Mock<ILogger<GpioService>> _loggerMock;
        Mock<IAppRepository> _repoMock;
        IGpioService _service;

        [SetUp]
        public void Setup()
        {
            _gpioMock = new Mock<IGpioController>();
            _loggerMock = new Mock<ILogger<GpioService>>();
            _repoMock = new Mock<IAppRepository>();
            _service = new GpioService(_loggerMock.Object, _gpioMock.Object, _repoMock.Object);
        }

        [Test]
        public void ToggleTest_PoolPump_High()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.Low));
            _gpioMock.Setup(_ => _.Read(Pins.PoolPump_1)).Returns(PinValue.Low);
            _gpioMock.Setup(_ => _.Read(Pins.PoolPump_2)).Returns(PinValue.Low);

            // Act
            var result = _service.Toggle(PinType.PoolPump);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.PoolPump_1, PinValue.High), Times.Once);
            _gpioMock.Verify(_ => _.Write(Pins.PoolPump_2, PinValue.High), Times.Once);
        }

        [Test]
        public void ToggleTest_BoosterPump_High()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.Low));
            _gpioMock.Setup(_ => _.Read(Pins.BoosterPump_1)).Returns(PinValue.Low);
            _gpioMock.Setup(_ => _.Read(Pins.BoosterPump_2)).Returns(PinValue.Low);

            // Act
            var result = _service.Toggle(PinType.BoosterPump);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.BoosterPump_1, PinValue.High), Times.Once);
            _gpioMock.Verify(_ => _.Write(Pins.BoosterPump_2, PinValue.High), Times.Once);
        }

        [Test]
        public void ToggleTest_SpaPump_High()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.Low));
            _gpioMock.Setup(_ => _.Read(Pins.SpaPump_1)).Returns(PinValue.Low);
            _gpioMock.Setup(_ => _.Read(Pins.SpaPump_2)).Returns(PinValue.Low);

            // Act
            var result = _service.Toggle(PinType.SpaPump);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.SpaPump_1, PinValue.High), Times.Once);
            _gpioMock.Verify(_ => _.Write(Pins.SpaPump_2, PinValue.High), Times.Once);
        }

        [Test]
        public void ToggleTest_PoolLight_High()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.Low));
            _gpioMock.Setup(_ => _.Read(Pins.PoolLight)).Returns(PinValue.Low);

            // Act
            var result = _service.Toggle(PinType.PoolLight);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.PoolLight, PinValue.High), Times.Once);
        }

        [Test]
        public void ToggleTest_SpaLight_High()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.Low));
            _gpioMock.Setup(_ => _.Read(Pins.SpaLight)).Returns(PinValue.Low);

            // Act
            var result = _service.Toggle(PinType.SpaLight);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.SpaLight, PinValue.High), Times.Once);
        }

        [Test]
        public void ToggleTest_Heater_High()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.Low));
            _gpioMock.Setup(_ => _.Read(Pins.Heater)).Returns(PinValue.Low);

            // Act
            var result = _service.Toggle(PinType.Heater);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.Heater, PinValue.High), Times.Once);
        }

        [Test]
        public void ToggleTest_GroundLights_High()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.Low));
            _gpioMock.Setup(_ => _.Read(Pins.GroundLights)).Returns(PinValue.Low);

            // Act
            var result = _service.Toggle(PinType.GroundLights);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.GroundLights, PinValue.High), Times.Once);
        }

        [Test]
        public void ToggleTest_PoolPump_Low()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.High));
            _gpioMock.Setup(_ => _.Read(Pins.PoolPump_1)).Returns(PinValue.High);
            _gpioMock.Setup(_ => _.Read(Pins.PoolPump_2)).Returns(PinValue.High);

            // Act
            var result = _service.Toggle(PinType.PoolPump);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.PoolPump_1, PinValue.Low), Times.Once);
            _gpioMock.Verify(_ => _.Write(Pins.PoolPump_2, PinValue.Low), Times.Once);
        }

        [Test]
        public void ToggleTest_BoosterPump_Low()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.High));
            _gpioMock.Setup(_ => _.Read(Pins.BoosterPump_1)).Returns(PinValue.High);
            _gpioMock.Setup(_ => _.Read(Pins.BoosterPump_2)).Returns(PinValue.High);

            // Act
            var result = _service.Toggle(PinType.BoosterPump);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.BoosterPump_1, PinValue.Low), Times.Once);
            _gpioMock.Verify(_ => _.Write(Pins.BoosterPump_2, PinValue.Low), Times.Once);
        }

        [Test]
        public void ToggleTest_SpaPump_Low()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.High));
            _gpioMock.Setup(_ => _.Read(Pins.SpaPump_1)).Returns(PinValue.High);
            _gpioMock.Setup(_ => _.Read(Pins.SpaPump_2)).Returns(PinValue.High);

            // Act
            var result = _service.Toggle(PinType.SpaPump);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.SpaPump_1, PinValue.Low), Times.Once);
            _gpioMock.Verify(_ => _.Write(Pins.SpaPump_2, PinValue.Low), Times.Once);
        }

        [Test]
        public void ToggleTest_PoolLight_Low()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.High));
            _gpioMock.Setup(_ => _.Read(Pins.PoolLight)).Returns(PinValue.High);

            // Act
            var result = _service.Toggle(PinType.PoolLight);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.PoolLight, PinValue.Low), Times.Once);
        }

        [Test]
        public void ToggleTest_SpaLight_Low()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.High));
            _gpioMock.Setup(_ => _.Read(Pins.SpaLight)).Returns(PinValue.High);

            // Act
            var result = _service.Toggle(PinType.SpaLight);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.SpaLight, PinValue.Low), Times.Once);
        }

        [Test]
        public void ToggleTest_Heater_Low()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.High));
            _gpioMock.Setup(_ => _.Read(Pins.Heater)).Returns(PinValue.High);

            // Act
            var result = _service.Toggle(PinType.Heater);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.Heater, PinValue.Low), Times.Once);
        }

        [Test]
        public void ToggleTest_GroundLights_Low()
        {
            // Arrange
            _repoMock.SetupGet(_ => _.AllPins).Returns(AppRepositoryTests.GetAllTestPins(PinValue.High));
            _gpioMock.Setup(_ => _.Read(Pins.GroundLights)).Returns(PinValue.High);

            // Act
            var result = _service.Toggle(PinType.GroundLights);

            // Assert
            _gpioMock.Verify(_ => _.Write(Pins.GroundLights, PinValue.Low), Times.Once);
        }

        [Test]
        public void GetAllStatusesTest_High()
        {
            // Arrange
            var testValue = PinValue.High;
            _repoMock.SetupGet(_ => _.PoolPump).Returns(new PiPin(PinType.PoolPump) { PinState = testValue });
            _repoMock.SetupGet(_ => _.SpaPump).Returns(new PiPin(PinType.SpaPump) { PinState = testValue });
            _repoMock.SetupGet(_ => _.BoosterPump).Returns(new PiPin(PinType.BoosterPump) { PinState = testValue });
            _repoMock.SetupGet(_ => _.PoolLight).Returns(new PiPin(PinType.PoolLight) { PinState = testValue });
            _repoMock.SetupGet(_ => _.SpaLight).Returns(new PiPin(PinType.SpaLight) { PinState = testValue });
            _repoMock.SetupGet(_ => _.GroundLights).Returns(new PiPin(PinType.GroundLights) { PinState = testValue });
            _repoMock.SetupGet(_ => _.Heater).Returns(new PiPin(PinType.Heater) { PinState = testValue});

            var expected = new List<PiPin>
            {
                new PiPin(PinType.PoolPump) { PinState = testValue },
                new PiPin(PinType.SpaPump) { PinState = testValue },
                new PiPin(PinType.BoosterPump) { PinState = testValue },
                new PiPin(PinType.PoolLight) { PinState = testValue },
                new PiPin(PinType.SpaLight) { PinState =  testValue },
                new PiPin(PinType.GroundLights) { PinState =  testValue },
                new PiPin(PinType.Heater) { PinState = testValue }
            };

            // Act
            var result = _service.GetAllStatuses();

            // Assert
            result.ShouldDeepEqual(expected);
        }

        [Test]
        public void GetScheduleTest_PoolPump()
        {
            // Arrange
            var schedule = new EquipmentSchedule
            {
                StartTime = new TimeSpan(11, 30, 0),
                EndTime = new TimeSpan(16, 30, 0),
                IsActive = true,
                Type = ScheduleType.Pool
            };

            _repoMock.SetupGet(_ => _.PoolPumpSchedule).Returns(schedule);

            // Act
            var result = _service.GetSchedule(ScheduleType.Pool);

            // Assert
            result.ShouldDeepEqual(schedule);
        }

        [Test]
        public void GetScheduleTest_BoosterPump()
        {
            // Arrange
            var schedule = new EquipmentSchedule
            {
                StartTime = new TimeSpan(11, 30, 0),
                EndTime = new TimeSpan(16, 30, 0),
                IsActive = true,
                Type = ScheduleType.Booster
            };

            _repoMock.SetupGet(_ => _.BoosterPumpSchedule).Returns(schedule);

            // Act
            var result = _service.GetSchedule(ScheduleType.Booster);

            // Assert
            result.ShouldDeepEqual(schedule);
        }

        [Test]
        public void GetScheduleTest_PoolLight()
        {
            // Arrange
            var schedule = new EquipmentSchedule
            {
                StartTime = new TimeSpan(11, 30, 0),
                EndTime = new TimeSpan(16, 30, 0),
                IsActive = true,
                Type = ScheduleType.PoolLight
            };

            _repoMock.SetupGet(_ => _.PoolLightSchedule).Returns(schedule);

            // Act
            var result = _service.GetSchedule(ScheduleType.PoolLight);

            // Assert
            result.ShouldDeepEqual(schedule);
        }

        [Test]
        public void GetScheduleTest_SpaLight()
        {
            // Arrange
            var schedule = new EquipmentSchedule
            {
                StartTime = new TimeSpan(11, 30, 0),
                EndTime = new TimeSpan(16, 30, 0),
                IsActive = true,
                Type = ScheduleType.SpaLight
            };

            _repoMock.SetupGet(_ => _.SpaLightSchedule).Returns(schedule);

            // Act
            var result = _service.GetSchedule(ScheduleType.SpaLight);

            // Assert
            result.ShouldDeepEqual(schedule);
        }

        [Test]
        public void GetEquipmentStatus_PoolPump()
        {
            var allPins = AppRepositoryTests.GetAllTestPins(PinValue.Low);
            _repoMock.SetupGet(_ => _.AllPins).Returns(allPins);
            _service.GetEquipmentStatus(PinType.PoolPump).ShouldDeepEqual(allPins.FirstOrDefault(_ => _.PinType == PinType.PoolPump));
        }
        [Test]
        public void GetEquipmentStatus_SpaPump()
        {
            var allPins = AppRepositoryTests.GetAllTestPins(PinValue.Low);
            _repoMock.SetupGet(_ => _.AllPins).Returns(allPins);
            _service.GetEquipmentStatus(PinType.SpaPump).ShouldDeepEqual(allPins.FirstOrDefault(_ => _.PinType == PinType.SpaPump));
        }
        [Test]
        public void GetEquipmentStatus_PoolLight()
        {
            var allPins = AppRepositoryTests.GetAllTestPins(PinValue.Low);
            _repoMock.SetupGet(_ => _.AllPins).Returns(allPins);
            _service.GetEquipmentStatus(PinType.PoolLight).ShouldDeepEqual(allPins.FirstOrDefault(_ => _.PinType == PinType.PoolLight));
        }
        [Test]
        public void GetEquipmentStatus_SpaLight()
        {
            var allPins = AppRepositoryTests.GetAllTestPins(PinValue.Low);
            _repoMock.SetupGet(_ => _.AllPins).Returns(allPins);
            _service.GetEquipmentStatus(PinType.SpaLight).ShouldDeepEqual(allPins.FirstOrDefault(_ => _.PinType == PinType.SpaLight));
        }
        [Test]
        public void GetEquipmentStatus_GroundLights()
        {
            var allPins = AppRepositoryTests.GetAllTestPins(PinValue.Low);
            _repoMock.SetupGet(_ => _.AllPins).Returns(allPins);
            _service.GetEquipmentStatus(PinType.GroundLights).ShouldDeepEqual(allPins.FirstOrDefault(_ => _.PinType == PinType.GroundLights));
        }
        [Test]
        public void GetEquipmentStatus_Heater()
        {
            var allPins = AppRepositoryTests.GetAllTestPins(PinValue.Low);
            _repoMock.SetupGet(_ => _.AllPins).Returns(allPins);
            _service.GetEquipmentStatus(PinType.Heater).ShouldDeepEqual(allPins.FirstOrDefault(_ => _.PinType == PinType.Heater));
        }
        [Test]
        public void GetEquipmentStatus_Pool()
        {
            var allPins = AppRepositoryTests.GetAllTestPins(PinValue.Low);
            _repoMock.SetupGet(_ => _.AllPins).Returns(allPins);
            _service.GetEquipmentStatus(PinType.PoolPump).ShouldDeepEqual(allPins.FirstOrDefault(_ => _.PinType == PinType.PoolPump));
        }
    }
}
