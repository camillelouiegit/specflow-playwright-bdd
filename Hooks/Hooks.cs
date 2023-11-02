using Microsoft.Playwright;
using SpecflowPlaywright.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecflowPlaywright.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly Driver _driver;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public Hooks(Driver driver, ISpecFlowOutputHelper specFlowOutputHelper) {
            _driver = driver;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        // [BeforeStep("@tag")]
        [BeforeStep]
        public void BeforeStep()
        {
            Console.WriteLine("This is executed after each step.");
        }

        // [AfterStep("@tag")]
        [AfterStep]
        public async Task TakeScreenShotAfterLoginScenarios()
        {
            var filename = Path.GetRandomFileName();

            await _driver.Page.ScreenshotAsync(new PageScreenshotOptions { Path = "../../../Report/" + filename + ".jpg" });

            _specFlowOutputHelper.AddAttachment(filename+".jpg");

            _specFlowOutputHelper.WriteLine("Screenshot successful - saved in Report/.");

        }

        // [BeforeScenario("@tag")]
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver.Page.GotoAsync("https://jupiter2.cloud.planittesting.com/#/home");
            Console.WriteLine("***********************************");
            Console.WriteLine("*            Start Test           *");
            Console.WriteLine("***********************************");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("*            End Test             *");
            Console.WriteLine("***********************************");
        }


    }
}