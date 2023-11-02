using SpecflowPlaywright.Drivers;
using Microsoft.Playwright;
using SpecflowPlaywright.Pages;

namespace SpecflowPlaywright.StepDefinitions
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly Driver _driver;
        private readonly HomePage _homePage;
        private readonly UserPage _userPage;

        public CommonSteps(Driver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver.Page);
            _userPage = new UserPage(_driver.Page);
        }

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        // For additional details on Playwright https://playwright.dev/docs

        [Given("the user is in the homepage")]
        public async Task UserHomePage()
        {
             await _homePage.VerifyHomePage();  
        }

        [When(@"the user navigates to ""([^""]*)"" page")]
        public async Task WhenTheUserNavigatesToPage(string page)
        {
            await _homePage.NavigateTo(page);
        }

    }
}