public class TravelAdvisorService
{
    private readonly ICountryInfoService _countryInfoService;
    private readonly INotificationService _notificationService;

    public TravelAdvisorService(ICountryInfoService countryInfoService, INotificationService notificationService)
    {
        _countryInfoService = countryInfoService;
        _notificationService = notificationService;
    }

    public void ProvideTravelAdvice(string userId, string countryCode)
    {
        var countryInfo = _countryInfoService.GetCountryInfo(countryCode);
        var message = $"Travel Advice for {countryCode}: {countryInfo.TravelRestrictions}. Vaccinations: {countryInfo.VaccinationRequirements}.";
        
        _notificationService.SendNotification(userId, message);
    }
}
