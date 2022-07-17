using BoDi;
using Microsoft.Playwright;
using SpecflowBlaztorTest.Tests.Common;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests.Features.Navigation
{
    [Binding]
    [Scope(Feature = "Home")]
    public class HomeHooks: AbstractHooks
    {
        [BeforeScenario()]
        public async Task BeforeBasketScenario(IObjectContainer container)
        {
            await base.RegisterPlayWright<HomePageContext>(container);
        }

        [AfterScenario]
        public override async Task AfterScenario(IObjectContainer container)
        {
            await base.AfterScenario(container);
        }
    }
}
