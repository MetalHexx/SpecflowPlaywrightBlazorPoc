using FluentAssertions;
using SpecflowBlaztorTest.Tests.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests
{
    [Binding]
    [Scope(Feature = "Counter")]
    public class CounterStepDefinitions
    {
        private readonly CounterFixture _counterContext;
        private int _originalValue;
        public CounterStepDefinitions(CounterFixture counterContext)
        {
            _counterContext = counterContext;
        }

        [Given(@"I am on any page in the application")]
        public async Task GivenIAmOnAnyPageInTheApplication()
        {
            await _counterContext.NavigateHomeAsync();
        }

        [When(@"when I click on the counter item in the left hand nav")]
        public async Task WhenWhenIClickOnTheCounterItemInTheLeftHandNav()
        {
            await _counterContext.ClickCounterNavLinkAsync();
        }

        [Then(@"I am taken to the counter page")]
        public async Task ThenIAmTakenToTheCounterPage()
        {
            var title = await _counterContext.GetPageTitleAsync();

            _counterContext.Page.Url.Should().Be(_counterContext.PagePath);
        }

        [Given(@"I am on the counter page")]
        public async Task GivenIAmOnTheCounterPage()
        {
            await _counterContext.NavigateAsync();
        }

        [When(@"I click the button (.*) times")]
        public async Task WhenIClickTheButtonTimes(int timesToClick)
        {
            _originalValue = await _counterContext.GetCounterValueAsync();

            for (int i = 0; i < timesToClick; i++)
            {
                await _counterContext.ClickIncrementButtonAsync();
            }
        }

        [Then(@"the current counter should be (.*)")]
        public async Task ThenTheCurrentCounterShouldBe(int expectedValue)
        {
            var actualCounterValue = await _counterContext.GetCounterValueAsync();

            actualCounterValue.Should().Be(expectedValue);
        }
    }
}
