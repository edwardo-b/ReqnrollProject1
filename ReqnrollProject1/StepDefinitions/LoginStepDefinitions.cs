using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private readonly IPage _page;
        private readonly IBrowser _browser;
        private readonly IPlaywright _playwright;

        public LoginStepDefinitions(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
            _page = _objectContainer.Resolve<IPage>();
            _browser = _objectContainer.Resolve<IBrowser>();
            _playwright = _objectContainer.Resolve<IPlaywright>();
        }
        [Given("I launch the application URL")]
        public async Task GivenILaunchTheApplicationURL()
        {
            await _page.GotoAsync("https://www.spicejet.com/"); // Replace with your application URL
            Console.WriteLine("Launching the application URL...");
        }

        [When("enter the username and password")]
        public void WhenEnterTheUsernameAndPassword()
        {
           Console.WriteLine("Entering the username and password...");
        }

        [Then("I click on the login button")]
        public void ThenIClickOnTheLoginButton()
        {
           Console.WriteLine("Clicking on the login button...");
        }

        [Then("I should see the home page")]
        public void ThenIShouldSeeTheHomePage()
        {
            Console.WriteLine("Verifying that the home page is displayed...");
        }
    }
}
