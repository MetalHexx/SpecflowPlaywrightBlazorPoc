using FluentAssertions;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests
{
    [Binding]
    [Scope(Feature = "Home")]
    public class HomeStepDefinitions
    {
        private readonly HomeFixture _fixture;

        public HomeStepDefinitions(HomeFixture fixture)
        {
            _fixture = fixture;
        }

        [Given(@"I am currently on the counter page")]
        public async Task GivenIAmCurrentlyOnTheCounterPage()
        {
            await _fixture.NavigateAsync();
            await _fixture.ClickCounterNavLink();
            await _fixture.GetCounterPageTitle();
        }


        [When(@"when I click on the home item in the left hand nav")]
        public async Task WhenWhenIClickOnTheHomeItemInTheLeftHandNav()
        {
            await _fixture.ClickHomeNavLink();
        }

        [Then(@"I am taken to the home page")]
        public async Task ThenIAmTakenToTheHomePage()
        {
            var title = await _fixture.GetHomePageTitle();

            _fixture.Page.Url.Should().Be(_fixture.PagePath);
        }
    }
}
