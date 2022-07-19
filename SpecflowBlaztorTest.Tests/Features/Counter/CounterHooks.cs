using BoDi;
using SpecflowBlaztorTest.Tests.Common;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests.Hooks
{
    [Binding]
    [Scope(Feature = "Counter")]
    public class CounterHooks: PlaywrightHooks
    {
        [BeforeScenario()]
        public async Task BeforeScenario(IObjectContainer container)
        {
            await RegisterPlayWright<CounterFixture>(container);
        }

        [AfterScenario]
        public override async Task AfterScenario(IObjectContainer container)
        {
            await base.AfterScenario(container);
        }
    }
}
