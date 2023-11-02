using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowPlaywright.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPlaywright.Pages
{
    public class HomePage
    {

        private IPage _page;
            public HomePage(IPage page) => _page = page;
            private ILocator HomeHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Jupiter Toys" });
            private ILocator LoginHeader => _page.GetByRole(AriaRole.Link, new() { Name = "Login" });
            private ILocator UsernameLogin => _page.Locator("#loginUserName");
            private ILocator PasswordLogin => _page.Locator("#loginPassword");
            private ILocator AgreeButton => _page.Locator("#agree");
            private ILocator LoginButton => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            private ILocator ErrorMessage => _page.GetByText("Your login details are incorrect");
            private ILocator LoginError => _page.Locator("#login-error");


        public async Task NavigateTo(string page)
        {
            await _page.WaitForLoadStateAsync();

            await _page.GetByRole(AriaRole.Link, new() { Name = page, Exact = true }).ClickAsync();
        }

        public async Task UserLogin(string username, string password) 
        {
            await _page.WaitForLoadStateAsync();
         
            await EnterLoginDetails(username,password);
        }

        public async Task EnterLoginDetails(string username, string password)
        {
            await UsernameLogin.FillAsync(username);
            
            await PasswordLogin.FillAsync(password);
                     
            await AgreeButton.ClickAsync(); 
         
            await LoginButton.ClickAsync();
        }

        public async Task VerifyHomePage()
        {
            await HomeHeading.IsVisibleAsync();
        }

        public async Task VerifyErrorMessage()
        {
            await _page.WaitForLoadStateAsync();

            await ErrorMessage.IsVisibleAsync();

            await Assertions.Expect(LoginError).ToHaveTextAsync("Your login details are incorrect");
        }


    }

    
}
