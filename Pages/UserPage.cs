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
    public class UserPage
    {
  
        private IPage _page;
            public UserPage(IPage page) => _page = page;
            private ILocator LogOutButton => _page.Locator("text=Logout");
     

        public async Task VerifyUserPage(string user)
        {
            await _page.Locator("text=" + user).ClickAsync();

            await _page.Locator("text=Welcome " + user).IsVisibleAsync();

            await LogOutButton.IsVisibleAsync();
    
        }

     

    }

    
}
