using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    internal class SignificantEventsPage
    {
        private readonly IPage _page;
        public SignificantEventsPage(IPage page)
        {
            _page = page;
        }
        private ILocator significantEvtHeader => _page.GetByText("Sample Report");

        public async Task verifySignificanEvtPage()
        {
            await Assertions.Expect(significantEvtHeader).ToBeVisibleAsync();
        }
    }
}
