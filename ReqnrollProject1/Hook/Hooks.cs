using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;
using System.Threading.Tasks;

namespace ReqnrollProject1.Hook
{
    [Binding]
    public sealed class Hooks
    {
        public readonly ScenarioContext _scenarioContext;
        public readonly IObjectContainer _objectContainer;

        private static readonly string[] IgnoreDefaultArgsArray = { "--enable-automation" }; // Fix for CA1861

        public Hooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://go.reqnroll.net/doc-hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario(Order = 1)]
        public async Task FirstBeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                BypassCSP = true,
            });
            var page = await context.NewPageAsync();

            _objectContainer.RegisterInstanceAs<IPage>(page);
            _objectContainer.RegisterInstanceAs<IBrowser>(browser);
            _objectContainer.RegisterInstanceAs<IPlaywright>(playwright);
            _objectContainer.RegisterInstanceAs<IBrowserContext>(context);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}