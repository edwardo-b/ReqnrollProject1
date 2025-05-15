using System;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollProject1.Pages;
using ReqnrollProject1.Utils;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private readonly IPage _page;
        private readonly ConfigReader configReader;
        private readonly LoginPage loginPage;

        public LoginStepDefinitions(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
            configReader = new ConfigReader();
            _page = _objectContainer.Resolve<IPage>();
            loginPage = _objectContainer.Resolve<LoginPage>();
            
        }
        [Given("I launch the application URL")]
        public async Task GivenILaunchTheApplicationURL()
        {
            await _page.GotoAsync(ConfigReader.GetTestDataValue("AppUrl")); // Replace with your application URL
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
