using System;
using System.Security.Policy;
using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollProject1.Pages;
using ReqnrollProject1.Resources.Configuration;
using ReqnrollProject1.Utils;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class WrsLoginStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private readonly IPage _page;
        private readonly LoginPage loginPage;
        public WrsLoginStepDefinitions(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
            _page = _objectContainer.Resolve<IPage>();
            loginPage = _objectContainer.Resolve<LoginPage>();
        }

        [Given("I navigate to WRS")]
        public async Task GivenINavigateToWRS()
        {
            var url = Configuration.ReporterFrontendUrl.ToString();
            if (string.IsNullOrEmpty(url)) throw new Exception("URL is null or empty.");
            await _page.GotoAsync(url);
        }

        [When("I log in as manager on CMS Login page")]
        public void WhenILogInAsManagerOnCMSLoginPage()
        {
            throw new PendingStepException();
        }

        [Then("WRS Home page is displayed")]
        public void ThenWRSHomePageIsDisplayed()
        {
            throw new PendingStepException();
        }
    }
}
