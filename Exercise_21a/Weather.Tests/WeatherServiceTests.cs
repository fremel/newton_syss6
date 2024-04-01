using System.Net;
using Moq;
using Moq.Protected;

[TestClass]
public class WeatherServiceTests
{
    [TestMethod]
    public async Task GetWeather_ShouldReturnFormattedWeather()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
            ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.AbsoluteUri == "https://api.weather.com/weather/NewYork"),
            // ItExpr.IsAny<HttpRequestMessage>()
            // ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post)
            ItExpr.IsAny<CancellationToken>())
             .ReturnsAsync(new HttpResponseMessage
             {
                 StatusCode = HttpStatusCode.OK,
                 Content = new StringContent("{\"temperature\": 20, \"city\": \"New York\"}")
             });

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://api.weather.com/")
        };

        var weatherService = new WeatherService(httpClient);

        // Act
        var weatherData = await weatherService.GetWeather("NewYork");

        // Assert
        Assert.AreEqual("NewYork weather: Temperature is 20°C", weatherData);
    }
}
