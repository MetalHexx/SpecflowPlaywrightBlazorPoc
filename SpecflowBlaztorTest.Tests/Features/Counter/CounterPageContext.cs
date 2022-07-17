using SpecflowBlaztorTest.Tests.Common;

namespace SpecflowBlaztorTest.Tests.PageObjects
{
    public class CounterPageContext : AbstractPageContext
    {
        public override string PagePath => PagePaths.Counter;
        public string HomePagePath => PagePaths.Home;
        public async Task NavigateHomeAsync() => await NavigateToPathAsync(HomePagePath);
        public async Task ClickIncrementButtonAsync() => await ClickByDataAttributeAsync("increment-count-button");
        public async Task<int> GetCounterValueAsync() => int.Parse(await Page.InnerTextAsync("#counter-value"));
        public async Task ClickCounterNavLinkAsync() => await Page.ClickAsync("#counter-nav-link");
        public async Task<string> GetPageTitleAsync() => await Page.InnerTextAsync("#counter-title");
    }
}
