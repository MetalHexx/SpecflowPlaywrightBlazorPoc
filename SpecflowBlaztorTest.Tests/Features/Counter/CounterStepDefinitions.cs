using FluentAssertions;
using SpecflowBlaztorTest.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests
{
    [Binding]
    [Scope(Feature = "Counter")]
    public class CounterStepDefinitions
    {
        private readonly CounterFixture _fixture;

        public CounterStepDefinitions(CounterFixture fixture)
        {
            _fixture = fixture;
        }

        [Given(@"I am on any page in the application")]
        public async Task GivenIAmOnAnyPageInTheApplication()
        {
            await _fixture.NavigateHomeAsync();
        }

        [When(@"when I click on the counter item in the left hand nav")]
        public async Task WhenWhenIClickOnTheCounterItemInTheLeftHandNav()
        {
            await _fixture.ClickCounterNavLinkAsync();
        }

        [Then(@"I am taken to the counter page")]
        public async Task ThenIAmTakenToTheCounterPage()
        {
            var _ = await _fixture.GetPageTitleAsync(); //TODO: await page load -- figure out a better way to do this

            _fixture.Page.Url.Should().Be(_fixture.PagePath);
        }

        [Given(@"I am on the counter page")]
        public async Task GivenIAmOnTheCounterPage()
        {
            await _fixture.NavigateAsync();
        }

        [When(@"I click the button (.*) times")]
        public async Task WhenIClickTheButtonTimes(int timesToClick)
        {
            for (int i = 0; i < timesToClick; i++)
            {
                await _fixture.ClickIncrementButtonAsync();
            }
        }

        [Then(@"the current counter should be (.*)")]
        public async Task ThenTheCurrentCounterShouldBe(int expectedValue)
        {
            var actualCounterValue = await _fixture.GetCounterValueAsync();

            actualCounterValue.Should().Be(expectedValue);
        }
    }
}
