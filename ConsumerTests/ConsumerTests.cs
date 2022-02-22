using InfinitePing.Services;
using InfinitePing.Models;
using System.Threading.Tasks;
using Xunit;
using System;

namespace ConsumerTests
{
    public class ConsumerTests
    {
        [Theory]
        [InlineData("test")]
        [InlineData("TeSt")]
        public void When_CorrectEnvironmentNameRepresentingTest_Then_CorrectConsumerService(string environment)
        {
            // Arrange
            Settings settings = new()
            {
                PingPort = 0,
                Pause = 0,
                DeploymentStatus = environment,
                URL = null,
                CallDestination = null
            };

            // Act
            var sut = PingServiceFactory.generatePingService(settings);

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<PingNothing>(sut);
        }

        [Theory]
        [InlineData("prod")]
        [InlineData("PROd")]
        public void When_CorrectEnvironmentNameRepresentingProd_Then_CorrectConsumerService(string environment)
        {
            // Arrange
            Settings settings = new()
            {
                PingPort = 0,
                Pause = 0,
                DeploymentStatus = environment,
                URL = null,
                CallDestination = null
            };

            // Act
            var sut = PingServiceFactory.generatePingService(settings);

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<PingApi>(sut);
        }

        [Theory]
        [InlineData("asd")]
        [InlineData("#45")]
        public void When_IncorrectEnvironmentNameRepresentingSystem_Then_ThrowException(string environment)
        {
            // Arrange
            Settings settings = new()
            {
                PingPort = 0,
                Pause = 0,
                DeploymentStatus = environment,
                URL = null,
                CallDestination = null
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => PingServiceFactory.generatePingService(settings));
        }

        [Fact]
        public async void When_PingIt_Then_ReceiveMessageAsync()
        {
            // Arrange
            IPingService sut = new PingNothing();
            Settings settings = new() {
                PingPort = 0,
                Pause = 0,
                DeploymentStatus = "Test"
            };

            // Act
            var results = sut.PingIt(settings);
            await results;

            // Assert
            Assert.NotNull(results);
            Assert.IsType<string>(results.Result);
        }
    }
}
