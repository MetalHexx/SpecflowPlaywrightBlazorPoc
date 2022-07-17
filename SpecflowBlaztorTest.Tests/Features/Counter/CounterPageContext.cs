using Microsoft.Playwright;
using SpecflowBlaztorTest.Tests.Common;

namespace SpecflowBlaztorTest.Tests.PageObjects
{
    public class CounterPageContext : AbstractPageContext
    {
        public override string PagePath => "https://localhost:7264/counter";
        public async Task ClickIncrementButtonAsync() => await Page.ClickAsync("#increment-count-button");
        public async Task<int> GetCounterValueAsync() => int.Parse(await Page.InnerTextAsync("#counter-value"));
        public async Task ClickCounterNavLinkAsync() => await Page.ClickAsync("#counter-nav-link");
        public async Task<string> GetPageTitleAsync() => await Page.InnerTextAsync("#counter-title");
    }
}
