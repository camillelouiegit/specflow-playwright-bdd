using SpecflowPlaywright.Drivers;
using Microsoft.Playwright;
using SpecflowPlaywright.Pages;

namespace SpecflowPlaywright.StepDefinitions
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly Driver _driver;
        private readonly HomePage _homePage;
        private readonly UserPage _userPage;

        public LoginSteps(Driver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver.Page);
            _userPage = new UserPage(_driver.Page);
        }

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        // For additional details on Playwright https://playwright.dev/docs

        [When(@"the user tries to login with username ""([^""]*)"" and password ""([^""]*)""")]
        public async Task WhenUserLogin(string username, string password)
        {
            await _homePage.UserLogin(username, password);
        }

        [Then(@"the user ""([^""]*)"" has successfully login")]
        public async Task ThenTheUserHasSuccessfullyLogin(string user)
        {
            await _userPage.VerifyUserPage(user);
        }

        [Then("the error message is displayed")]
        public async Task ThenVerifyLoginIsSuccessful()
        {
            await _homePage.VerifyErrorMessage();
        }
    }
}