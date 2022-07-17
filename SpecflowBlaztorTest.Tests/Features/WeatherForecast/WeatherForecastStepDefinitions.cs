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
        private readonly WeatherForecastPageContext _pageContext;
        public WeatherForecastStepDefinitions(WeatherForecastPageContext pageContext)
        {
            _pageContext = pageContext;
        }

        [Given(@"I am on any page in the application")]
        public async Task GivenIAmOnAnyPageInTheApplication()
        {
            await _pageContext.NavigateHomeAsync();
        }

        [When(@"when I click on the weather forecast item in the left hand nav")]
        public async Task WhenWhenIClickOnTheWeatherForecastItemInTheLeftHandNav()
        {
            await _pageContext.ClickWeatherForecastNavLinkAsync();
        }

        [Then(@"I am taken to the weather forecast page")]
        public async Task ThenIAmTakenToTheWeatherForecastPage()
        {
            var title = await _pageContext.GetPageTitleAsync();

            _pageContext.Page.Url.Should().Be(_pageContext.PagePath);
        }

        [Given(@"I am on the weather forecast page")]
        public async Task GivenIAmOnTheWeatherForecastPage()
        {
            await _pageContext.NavigateAsync();
        }

        [When(@"the page loads")]
        public void WhenThePageLoads()
        {
            //throw new PendingStepException();
        }

        [Then(@"I see a table of weather forecasts")]
        public async Task ThenISeeATableOfWeatherForecasts()
        {
            var table =  await _pageContext.GetTableAsync();

            table.Should().NotBeNull();
        }
    }
}
