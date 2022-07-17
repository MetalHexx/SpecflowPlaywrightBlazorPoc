using Microsoft.Playwright;
using SpecflowBlaztorTest.Tests.Common;

namespace SpecflowBlaztorTest.Tests.PageObjects
{
    public class HomePageContext : AbstractPageContext
    {
        public override string PagePath => "https://localhost:7264/";
        public const string CounterPagePath = "https://localhost:7264/counter";

        public async Task ClickCounterNavLink() => await Page.ClickAsync("#counter-nav-link");
        public async Task ClickHomeNavLink() => await Page.ClickAsync("#home-nav-link");
        public async Task<string> GetCounterPageTitle() => await Page.InnerTextAsync("#counter-title");
        public async Task<string> GetHomePageTitle() => await Page.InnerTextAsync("#home-page-title");
    }
}
