using SpecflowPlaywright.Drivers;
using Microsoft.Playwright;
using SpecflowPlaywright.Pages;
using System.Diagnostics;
using TechTalk.SpecFlow.Assist;

namespace SpecflowPlaywright.StepDefinitions
{
    [Binding]
    public sealed class ShopSteps
    {
        private readonly Driver _driver;
        private readonly HomePage _homePage;
        private readonly ShopPage _shopPage;

        public ShopSteps(Driver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver.Page);
            _shopPage = new ShopPage(_driver.Page);
        }

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        // For additional details on Playwright https://playwright.dev/docs


        [When(@"the user selects a product with specific price")]
        public async Task WhenTheUserSelectsAProductWithSpecificPrice(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            var product = data.Products;
            var price = data.Price.ToString();
            
            Console.WriteLine($"Price: {data.Price} Product: {data.Products}");
            await _shopPage.SelectItemByPrice(product, price);
        }

        [When(@"the user selects a product (.*) with specific price (.*)")]
        public async Task WhenTheUserSelectsAProductPRODUCTWithSpecificPrice(string product, string price)
        {
            await _shopPage.SelectItemByPrice(product, price);
        }

        [When(@"the user selects a product (.*) with star rating (.*)")]
        public async Task WhenTheUserSelectsAProductWithStarRatingAsync(string product, string rating)
        {
            await _shopPage.SelectItemByRating(product, rating);
        }


        [Then(@"the user is able to view Cart \((.*)\)")]
        public async Task ThenTheUserIsAbleToViewCartMenuDisplays(int count)
        {
            await _shopPage.VerifyCartCount(count);
        }



    }
}