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
        }

        [When("enter the phone number and password")]
        public async Task WhenEnterThePhoneNumberAndPassword()
        {
           await loginPage.enterPhoneNo();
           await loginPage.enterPassword();
        }

        [Then("I click on the login button")]
        public async Task ThenIClickOnTheLoginButton()
        {
         await loginPage.clickSubmitLogin();
        }

        [Then("I should see the home page")]
        public async Task ThenIShouldSeeTheHomePage()
        {
            await loginPage.assertLoginError();
        }
        [When("I select mobile option and choose region or {string} code")]
        public async Task WhenISelectMobileOptionAndChooseRegionOrCode(string country)
        {
            await loginPage.clickMobileRegOption();
            await loginPage.clickCountryCodeBtn();
            await loginPage.enterCountry(country);
            await loginPage.selectCountry(country);
        }
        [When("I click login button")]
        public async Task WhenIClickLoginButton()
        {
            await  loginPage.clickLoginBtn();
        }


    }
}
