using Microsoft.Playwright;
using SpecflowBlaztorTest.Tests.Common;

namespace SpecflowBlaztorTest.Tests.PageObjects
{
    public class HomeFixture : PlaywrightFixture
    {
        public override string PagePath => PagePaths.Home;
        public const string CounterPagePath = PagePaths.Counter;
        public async Task ClickCounterNavLink() => await Page.ClickAsync("#counter-nav-link");
        public async Task ClickHomeNavLink() => await Page.ClickAsync("#home-nav-link");
        public async Task<string> GetCounterPageTitle() => await Page.InnerTextAsync("#counter-title");
        public async Task<string> GetHomePageTitle() => await Page.InnerTextAsync("#home-page-title");
    }
}
