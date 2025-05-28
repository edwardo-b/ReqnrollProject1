using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollProject1.Resources.Configuration;
using ReqnrollProject1.Utils;
using RestSharp;
using System.Threading.Tasks;

namespace ReqnrollProject1.Hook
{
    [Binding]
    public sealed class Hooks
    {
        public readonly ScenarioContext _scenarioContext;
        public readonly IObjectContainer _objectContainer;
        private readonly RestClient _client;

        private static readonly string[] IgnoreDefaultArgsArray = { "--enable-automation" }; // Fix for CA1861

        public Hooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
            _client = new RestClient();
        }
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

        [BeforeScenario("@UI")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://go.reqnroll.net/doc-hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario("@UI", Order = 1)]
        public async Task FirstBeforeScenario()
        {
            var browserSetting = Configuration.GetBrowser;

            if (string.IsNullOrWhiteSpace(browserSetting))
                throw new InvalidOperationException("Browser configuration is missing. Please check your configuration file.");

            var browserType = browserSetting.ToLower();

            var playwright = await Playwright.CreateAsync();
            IBrowser browser;
            IBrowserContext context;
            IPage page;

            switch (browserType)
            {
                case "chrome":
                case "edge":
                    browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false,
                        SlowMo = 1000
                    });
                    break;

                case "firefox":
                    browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false,
                        SlowMo = 1000
                    });
                    break;

                case "webkit":
                    browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false,
                        SlowMo = 1000
                    });
                    break;

                default:
                    throw new InvalidOperationException($"Unsupported browser: {browserType}");
            }

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
                BypassCSP = true
            });

            page = await context.NewPageAsync();

            // Register for DI
            _objectContainer.RegisterInstanceAs(playwright);
            _objectContainer.RegisterInstanceAs(browser);
            _objectContainer.RegisterInstanceAs(context);
            _objectContainer.RegisterInstanceAs(page);
        }


        [AfterScenario("@UI")]
        public async Task AfterScenario()
        {
            // Clean up Playwright browser and instance after each UI scenario
            var browser = _objectContainer.Resolve<IBrowser>();
            var playwright = _objectContainer.Resolve<IPlaywright>();

            await browser.CloseAsync();
            playwright.Dispose(); // No await here, since Dispose() is not asynchronous
        }



        [BeforeScenario ("@API")]
        public void BeforeAPIScenario()
        {
            var client = new RestClient(ConfigReader.GetConfigAppSettingValue("baseRequestUrl"));
            _objectContainer.RegisterInstanceAs(client);
        }

        [AfterScenario("@API")]
        public void AfterAPIScenario()
        {
            if (_scenarioContext.TryGetValue("deleteResource", out var resourceObj) && resourceObj is string resource)
            {
                ApiUtils.SendDeleteRequest(resource);
            }
        }


    }
}