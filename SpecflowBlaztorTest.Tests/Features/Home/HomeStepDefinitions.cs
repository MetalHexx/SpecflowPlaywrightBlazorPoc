using FluentAssertions;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests
{
    [Binding]
    [Scope(Feature = "Home")]
    public class HomeStepDefinitions
    {
        private readonly HomeFixture _pageContext;

        public HomeStepDefinitions(HomeFixture pageContext)
        {
            _pageContext = pageContext;
        }

        [Given(@"I am currently on the counter page")]
        public async Task GivenIAmCurrentlyOnTheCounterPage()
        {
            await _pageContext.NavigateAsync();
            await _pageContext.ClickCounterNavLink();
            await _pageContext.GetCounterPageTitle();
        }


        [When(@"when I click on the home item in the left hand nav")]
        public async Task WhenWhenIClickOnTheHomeItemInTheLeftHandNav()
        {
            await _pageContext.ClickHomeNavLink();
        }

        [Then(@"I am taken to the home page")]
        public async Task ThenIAmTakenToTheHomePage()
        {
            var title = await _pageContext.GetHomePageTitle();

            _pageContext.Page.Url.Should().Be(_pageContext.PagePath);
        }
    }
}
