using BoDi;
using Microsoft.Playwright;
using SpecflowBlaztorTest.Tests.Common;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests.Hooks
{
    [Binding]
    [Scope(Feature = "Counter")]
    public class CounterHooks: AbstractHooks
    {
        [BeforeScenario()]
        public async Task BeforeBasketScenario(IObjectContainer container)
        {
            await RegisterPlayWright<CounterPageContext>(container);
        }

        [AfterScenario]
        public override async Task AfterScenario(IObjectContainer container)
        {
            await base.AfterScenario(container);
        }
    }
}
