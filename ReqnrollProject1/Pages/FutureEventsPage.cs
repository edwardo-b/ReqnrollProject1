using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Pages
{
    internal class FutureEventsPage
    {
        private readonly IPage _page;
        public FutureEventsPage(IPage page)
        {
            _page = page;
        }

        private ILocator futureEventsHeader => _page.GetByText("Sample Report");

        public async Task verifyFutureEventsPage()
        {
            await Assertions.Expect(futureEventsHeader).ToBeVisibleAsync();
        }
    }
}
