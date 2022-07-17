using Microsoft.Playwright;
using SpecflowBlaztorTest.Tests.Common;

namespace SpecflowBlaztorTest.Tests.PageObjects
{
    public class WeatherForecastPageContext : AbstractPageContext
    {
        public override string PagePath => "https://localhost:7264/fetchdata";
        public async Task<IElementHandle> GetTableAsync() => await Page.WaitForSelectorAsync("#table-weather-forecast");
        public async Task ClickWeatherForecastNavLinkAsync() => await Page.ClickAsync("#weather-forecast-nav-link");
        public async Task<string> GetPageTitleAsync() => await Page.InnerTextAsync("#weather-forecast-title");
    }
}
