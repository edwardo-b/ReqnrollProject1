using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollProject1.Pages;
using System;
using System.Threading.Tasks;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class HomePageStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private readonly IPage _page;
        private readonly HomePage homePage;
        private readonly LiabilitiesReportPage liabilitiesReportPage;
        private readonly RevenueReportPage revenueReportPage;
        private readonly SignificantEventsPage significantEventsPage;
        private readonly FutureEventsPage futureEventsPage;
        public HomePageStepDefinitions(ScenarioContext scenarioContext, IObjectContainer objectContainer, IPage page)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
            _page = page;
            homePage= _objectContainer.Resolve<HomePage>();
            liabilitiesReportPage=_objectContainer.Resolve<LiabilitiesReportPage>();
            revenueReportPage=_objectContainer.Resolve<RevenueReportPage>();
            significantEventsPage=_objectContainer.Resolve<SignificantEventsPage>();
            futureEventsPage =_objectContainer.Resolve<FutureEventsPage>(); 


        }

        [When("I click on the Liabilities Report")]
        public async Task WhenIClickOnTheLiabilitiesReport()
        {
            await homePage.clickLiabilitiesBtn();
        }

        [Then("the Liabilities page is opened")]
        public async Task ThenTheLiabilitiesPageIsOpened()
        {
            await liabilitiesReportPage.verifyLiabiltiesRptDisplayed();
        }

        [When("I click on the Revenue Report")]
        public async Task WhenIClickOnTheRevenueReport()
        {
            await homePage.clickRevenueBtn();
        }

        [Then("the Revenue page is opened")]
        public async Task ThenTheRevenuePageIsOpened()
        {
            await revenueReportPage.verifyRevenuePage();
        }

        [When("I click on Significant Events")]
        public async Task WhenIClickOnSignificantEvents()
        {
            await homePage.clickSignificanEventsBtn();
        }

        [Then("the Significant Events page is opened")]
        public async Task ThenTheSignificantEventsPageIsOpened()
        {
            await significantEventsPage.verifySignificanEvtPage();
        }

        [When("I click on Future Events")]
        public async Task WhenIClickOnFutureEvents()
        {
            await homePage.clickfutureEventsBtn();
        }

        [Then("the Future Events page is opened")]
        public async Task ThenTheFutureEventsPageIsOpened()
        {
            await futureEventsPage.verifyFutureEventsPage();
        }
        [When("I click home button")]
        public async Task WhenIClickHomeButton()
        {
            await homePage.clickHome();
        }

        [When("WRS Home page is displayed")]
        public async Task WhenWRSHomePageIsDisplayed()
        {
            await homePage.isHomePageDisplayed();
        }

    }
}
