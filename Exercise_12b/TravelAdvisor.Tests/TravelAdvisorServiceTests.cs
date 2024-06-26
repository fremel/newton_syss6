using Moq;

[TestClass]
public class TravelAdvisorServiceTests
{
    [TestMethod]
    public void ProvideTravelAdvice_SendsCorrectNotification()
    {
        // Arrange
        var mockCountryInfoService = new Mock<ICountryInfoService>();
        var mockNotificationService = new Mock<INotificationService>();
        var countryCode = "SE";
        var userId = "user123";
        var countryInfo = new CountryInfo
        {
            CountryCode = countryCode,
            TravelRestrictions = "No restrictions",
            VaccinationRequirements = "None"
        };
        mockCountryInfoService.Setup(x => x.GetCountryInfo(countryCode)).Returns(countryInfo);

        var service = new TravelAdvisorService(mockCountryInfoService.Object, mockNotificationService.Object);
        var expectedMessage = $"Travel Advice for SE: No restrictions. Vaccinations: None.";

        // Act
        service.ProvideTravelAdvice(userId, countryCode);

        // Assert
        //mockNotificationService.VerifyNoOtherCalls();
        mockNotificationService.Verify(x => x.SendNotification(userId, It.Is<string>(msg => msg == expectedMessage)), Times.Once);
    }

    [TestMethod]
    public void ProvideTravelAdvice_NiceErrorHandlingWhenCountryCodeDoesNotExist() 
    {
        // Arrange
        var mockCountryInfoService = new Mock<ICountryInfoService>();
        var mockNotificationService = new Mock<INotificationService>();
        var service = new TravelAdvisorService(mockCountryInfoService.Object, mockNotificationService.Object);
        
        // Act
        string countryCode = "SRB";
        string userId = "2";
        service.ProvideTravelAdvice(userId, countryCode);

        // Assert
        var expectedMessage = $"No country info found for country code {countryCode}";
        mockNotificationService.Verify(ns => ns.SendNotification(userId, It.Is<string>(msg => msg == expectedMessage)));
    } 
}