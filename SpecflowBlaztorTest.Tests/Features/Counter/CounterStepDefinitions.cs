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
        private readonly CounterPageContext _pageContext;
        private int _originalValue;
        public CounterStepDefinitions(CounterPageContext page)
        {
            _pageContext = page;
        }

        [Given(@"I am on any page in the application")]
        public async Task GivenIAmOnAnyPageInTheApplication()
        {
            await _pageContext.NavigateHomeAsync();
        }

        [When(@"when I click on the counter item in the left hand nav")]
        public async Task WhenWhenIClickOnTheCounterItemInTheLeftHandNav()
        {
            await _pageContext.ClickCounterNavLinkAsync();
        }

        [Then(@"I am taken to the counter page")]
        public async Task ThenIAmTakenToTheCounterPage()
        {
            var title = await _pageContext.GetPageTitleAsync();

            _pageContext.Page.Url.Should().Be(_pageContext.PagePath);
        }

        [Given(@"I am on the counter page")]
        public async Task GivenIAmOnTheCounterPage()
        {
            await _pageContext.NavigateAsync();
        }

        [When(@"I click the button (.*) times")]
        public async Task WhenIClickTheButtonTimes(int timesToClick)
        {
            _originalValue = await _pageContext.GetCounterValueAsync();

            for (int i = 0; i < timesToClick; i++)
            {
                await _pageContext.ClickIncrementButtonAsync();
            }
        }


        [Then(@"the current counter should increase by (.*)")]
        public async void ThenTheCurrentCounterShouldIncreaseBy(int expectedIncrease)
        {
            var actualCounterValue = await _pageContext.GetCounterValueAsync();
            var actualIncrease = actualCounterValue - _originalValue;

            actualIncrease.Should().Be(expectedIncrease);
        }

        [Then(@"the current counter should be (.*)")]
        public async Task ThenTheCurrentCounterShouldBe(int expectedValue)
        {
            var actualCounterValue = await _pageContext.GetCounterValueAsync();

            actualCounterValue.Should().Be(expectedValue);
        }
    }
}
