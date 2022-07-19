using FluentAssertions;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests
{
    [Binding]
    [Scope(Feature = "WeatherForecast")]
    public class WeatherForecastStepDefinitions
    {
        private readonly WeatherForecastFixture _fixture;

        public WeatherForecastStepDefinitions(WeatherForecastFixture fixture)
        {
            _fixture = fixture;
        }

        [Given(@"I am on any page in the application")]
        public async Task GivenIAmOnAnyPageInTheApplication()
        {
            await _fixture.NavigateHomeAsync();
        }

        [When(@"when I click on the weather forecast item in the left hand nav")]
        public async Task WhenWhenIClickOnTheWeatherForecastItemInTheLeftHandNav()
        {
            await _fixture.ClickWeatherForecastNavLinkAsync();
        }

        [Then(@"I am taken to the weather forecast page")]
        public async Task ThenIAmTakenToTheWeatherForecastPage()
        {
            var title = await _fixture.GetPageTitleAsync();

            _fixture.Page.Url.Should().Be(_fixture.PagePath);
        }

        [Given(@"I am on the weather forecast page")]
        public async Task GivenIAmOnTheWeatherForecastPage()
        {
            await _fixture.NavigateAsync();
        }

        [When(@"the page loads")]
        public void WhenThePageLoads()
        {
            //throw new PendingStepException();
        }

        [Then(@"I see a table of weather forecasts")]
        public async Task ThenISeeATableOfWeatherForecasts()
        {
            var table =  await _fixture.GetTableAsync();

            table.Should().NotBeNull();
        }
    }
}
