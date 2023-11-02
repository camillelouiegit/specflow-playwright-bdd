using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SpecflowPlaywright.Drivers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPlaywright.Pages
{
    public class ShopPage
    {
      
        private IPage _page;
        public ShopPage(IPage page) {

            _page = page;

        } 
        private string HandMadeDoll = "product-1";
        private string StuffFrog = "product-2";
        private string FluffyBunny = "product-4";
        private string SmileyBear = "product-5";
        private string FunnyCow = "product-6";
        private string ValentineBear = "product-7";
        private string SmileyFace = "product-8";

        private ILocator ProductPrice(string product, string price) =>
            _page.Locator("//li[@id='"+product+"']//descendant::span[text()='$" + price + "']//following-sibling::a");

        private ILocator ProductRating(string product, string rating) =>
            _page.Locator("//span[@class='star-level rate-"+rating+"']//ancestor::li[@id='"+product+"']//following-sibling::a");

        private ILocator CartCount(int count) =>
            _page.GetByRole(AriaRole.Link, new() { Name = "Cart (" + count + ")" });

        public async Task SelectItemByPrice(string product, string price) {

            if (product == "Handmade Doll" && price == "9.99")
            {
                await ProductPrice(HandMadeDoll, price).ClickAsync();
            }
            else if (product == "Stuffed Frog" && price == "10.99")
            {
                await ProductPrice(StuffFrog, price).ClickAsync();
            }
            else if (product == "Fluffy Bunny" && price == "8.99")
            {
                await ProductPrice(FluffyBunny, price).ClickAsync();
            }
            else if (product == "Smiley Bear" && price == "13.99")
            {
                await ProductPrice(SmileyBear, price).ClickAsync();
            }
            else if (product == "Funny Cow" && price == "9.99")
            {
                await ProductPrice(FunnyCow, price).ClickAsync();
            }
            else if (product == "Valentine Bear" && price == "13.99")
            {
                await ProductPrice(ValentineBear, price).ClickAsync();
            }
            else if (product == "Smiley Face" && price == "8.99")
            {
                await ProductPrice(SmileyFace, price).ClickAsync();
            }
           
            else {
                throw new Exception($"{product} with ${price} price does not exist.");
            }
       
          }

        public async Task SelectItemByRating(string product, string rating)
        {
            if (product == "Stuffed Frog" && rating == "5")
            {
                await ProductRating(StuffFrog, rating).ClickAsync();
            }
            else if (product == "Smiley Face" && rating == "5")
            {
                await ProductRating(SmileyFace, rating).ClickAsync();
            }
            else
            {
                throw new Exception("Star rating " + rating + " is not in the list.");
            }
        }

            public async Task VerifyCartCount(int count){
            await Assertions.Expect(CartCount(count)).ToBeVisibleAsync();
        }


    }


    
}
