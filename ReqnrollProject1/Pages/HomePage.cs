using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    internal class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {  
            _page = page; 
        }

        private ILocator welcomeMsg => _page.GetByText("Welcome to Reporter");
        private ILocator liabilitiesBtn => _page.Locator("xpath=//*[contains(@href,'liability-report')]");
        private ILocator revenueBtn => _page.Locator("xpath=//*[contains(@href,'revenue-report')]");
        private ILocator significantEventBtn => _page.Locator("xpath=//*[contains(@href,'sample-report')]");
        private ILocator futureEventssBtn => _page.Locator("xpath=//*[contains(@href,'sample-report')]");
        private ILocator homeBtn => _page.GetByText("Home");



        public async Task clickLiabilitiesBtn()
        {
            await liabilitiesBtn.ClickAsync();
        }
        public async Task clickRevenueBtn()
        {
            await revenueBtn.ClickAsync();
        }
        public async Task clickSignificanEventsBtn()
        {
            await significantEventBtn.ClickAsync();
        }
        public async Task clickfutureEventsBtn()
        {
            await futureEventssBtn.ClickAsync();
        }
        public async Task cliclHome()
        {
            await homeBtn.ClickAsync();
        }
        public async Task isHomePageDisplayed()
        {
            await Assertions.Expect(welcomeMsg).ToBeVisibleAsync();
        }
    }
}
