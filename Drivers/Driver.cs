using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecflowPlaywright.Drivers
{
    public class Driver : IDisposable
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly Task<IPage> _page;

        private IBrowser? _browser;

        public Driver(ISpecFlowOutputHelper specFlowOutputHelper) {
            _specFlowOutputHelper = specFlowOutputHelper;
            _page = InitializePlaywright();
        }

        public IPage Page => _page.Result;
        
        private async Task<IPage> InitializePlaywright()
        {
            //Playwright
            var playwright = await Playwright.CreateAsync();
     
            //Browser
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new[] {"--start-maximized"},
            });

            _specFlowOutputHelper.WriteLine("Browser launched.");
            //Page
            return await _browser.NewPageAsync();
        }

        public void Dispose()
        {

            _browser?.CloseAsync();
            _specFlowOutputHelper.WriteLine("Browser Closed.");
        }
    }
}
