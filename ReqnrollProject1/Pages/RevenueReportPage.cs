using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    internal class RevenueReportPage
    {
        private readonly IPage _page;

        public RevenueReportPage(IPage page)
        {
            this._page = page;
        }
        private ILocator revenueReportHeader => _page.Locator("xpath = //*[contains(text(),'Revenue Report Summary')]");


        public async Task verifyRevenuePage()
        {
            await Assertions.Expect(revenueReportHeader).ToBeVisibleAsync();
        }
    }
}
