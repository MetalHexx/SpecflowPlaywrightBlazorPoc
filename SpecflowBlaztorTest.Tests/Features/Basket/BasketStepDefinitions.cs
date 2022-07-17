using FluentAssertions;
using SpecflowBlazorTest.Services;
using System;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests
{
    [Binding]
    [Scope(Feature = "Basket")]
    public class BasketStepDefinitions
    {
        private IBasketService _basketService;
        private int _originalCount;
        
        [Given(@"I have an empty basket")]
        public void GivenIHaveAnEmptyBasket()
        {
            _basketService = new BasketService();
            _originalCount = _basketService.ItemCount;

            _originalCount.Should().Be(0);
        }

        [When(@"I add a new item to the basket")]
        public void WhenIAddANewItemToTheBasket()
        {
            _basketService.AddItem();
        }

        [Then(@"the basket count should increase by (.*)")]
        public void ThenTheBasketCountShouldIncreaseBy(int expectedIncrease)
        {
            var actualIncrease = expectedIncrease - _originalCount;
            actualIncrease.Should().Be(1);
        }

        [Then(@"the backet count should be (.*)")]
        public void ThenTheBacketCountShouldBe(int expectedCount)
        {
            _basketService.ItemCount.Should().Be(expectedCount);
        }
    }
}
