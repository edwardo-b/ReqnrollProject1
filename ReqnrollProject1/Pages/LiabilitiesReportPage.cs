using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    internal class LiabilitiesReportPage
    {
        private readonly IPage _page;
        public LiabilitiesReportPage(IPage page)
        {
           this. _page = page;
        }
        private ILocator liabilitiesHeader => _page.GetByText("Liability Report");

        public async Task verifyLiabiltiesRptDisplayed()
        {
            await Assertions.Expect(liabilitiesHeader).ToBeVisibleAsync();
        }
    }

   
}
