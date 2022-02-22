using WeatherApi.Controllers;
using WeatherApi.Models;
using Xunit;

namespace ProducerTests
{
    public class ProducerTests
    {
        [Fact]
        public void When_RequestingWeather_Then_GetOneWeatherInstance()
        {
            // Arrange
            WeatherForecastController sut = new();

            // Act
            WeatherForecast result = sut.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WeatherForecast>(result);
        }
    }
}
