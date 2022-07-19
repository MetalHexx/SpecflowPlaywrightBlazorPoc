using BoDi;
using SpecflowBlaztorTest.Tests.Common;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests.Features.Navigation
{
    [Binding]
    [Scope(Feature = "Home")]
    public class HomeHooks: PlaywrightHooks
    {
        [BeforeScenario()]
        public async Task BeforeScenario(IObjectContainer container)
        {
            await RegisterPlayWright<HomeFixture>(container);
        }

        [AfterScenario]
        public override async Task AfterScenario(IObjectContainer container)
        {
            await base.AfterScenario(container);
        }
    }
}
