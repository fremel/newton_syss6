using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

[TestClass]
public class UnitTest1 : PageTest
{
    [TestMethod]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }

    [TestMethod]
    public async Task TestingToMakeAGoogleSearch()
    {
        await Page.GotoAsync("https://sl.se");

        Playwright.Selectors.SetTestIdAttribute("data-test-id");

        // Choose origin
        await Page.GetByTestId("travel-planner-typeahead-origin-input").FillAsync("Gärdet");
        await Page.GetByTestId("travel-planner-typeahead-origin-result-0").ClickAsync();

        // Choose destination
        await Page.GetByTestId("travel-planner-typeahead-destination-input").FillAsync("Gamla Stan");
        await Page.GetByTestId("travel-planner-typeahead-destination-result-0").ClickAsync();

        // Search
        await Page.GetByTestId("button-search-trip-button").ClickAsync();

        // Open first search result
        await Page.GetByTestId("fold-travel-result-trip").First.ClickAsync();

        // Assert
        await Expect(Page.GetByText("Prisinformation och enkelbiljetter")).ToBeVisibleAsync();
    }
}