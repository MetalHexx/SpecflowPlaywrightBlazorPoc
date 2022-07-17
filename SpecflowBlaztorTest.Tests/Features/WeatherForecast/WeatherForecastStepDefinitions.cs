using FluentAssertions;
using SpecflowBlaztorTest.Tests.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests
{
    [Binding]
    [Scope(Feature = "WeatherForecast")]
    public class WeatherForecastStepDefinitions
    {
        private readonly WeatherForecastPageContext _weatherContext;

        public WeatherForecastStepDefinitions(WeatherForecastPageContext weatherContext)
        {
            _weatherContext = weatherContext;
        }

        [Given(@"I am on any page in the application")]
        public async Task GivenIAmOnAnyPageInTheApplication()
        {
            await _weatherContext.NavigateHomeAsync();
        }

        [When(@"when I click on the weather forecast item in the left hand nav")]
        public async Task WhenWhenIClickOnTheWeatherForecastItemInTheLeftHandNav()
        {
            await _weatherContext.ClickWeatherForecastNavLinkAsync();
        }

        [Then(@"I am taken to the weather forecast page")]
        public async Task ThenIAmTakenToTheWeatherForecastPage()
        {
            var title = await _weatherContext.GetPageTitleAsync();

            _weatherContext.Page.Url.Should().Be(_weatherContext.PagePath);
        }

        [Given(@"I am on the weather forecast page")]
        public async Task GivenIAmOnTheWeatherForecastPage()
        {
            await _weatherContext.NavigateAsync();
        }

        [When(@"the page loads")]
        public void WhenThePageLoads()
        {
            //throw new PendingStepException();
        }

        [Then(@"I see a table of weather forecasts")]
        public async Task ThenISeeATableOfWeatherForecasts()
        {
            var table =  await _weatherContext.GetTableAsync();

            table.Should().NotBeNull();
        }
    }
}
