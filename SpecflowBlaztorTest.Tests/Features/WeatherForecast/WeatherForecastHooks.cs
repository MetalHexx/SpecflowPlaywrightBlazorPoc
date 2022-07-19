using BoDi;
using Microsoft.Playwright;
using SpecflowBlaztorTest.Tests.Common;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests.Hooks
{
    [Binding]
    [Scope(Feature = "WeatherForecast")]
    public class WeatherForecastHooks: PlaywrightHooks
    {
        [BeforeScenario()]
        public async Task BeforeScenario(IObjectContainer container)
        {
            await RegisterPlayWright<WeatherForecastFixture>(container);
        }

        [AfterScenario]
        public override async Task AfterScenario(IObjectContainer container)
        {
            await base.AfterScenario(container);
        }
    }
}
