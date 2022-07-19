Feature: Basket
	When an item is added to the basket
	The basket item count should increase

Scenario: Basket count should increase when an item is added
	Given I have an empty basket
	When I add a new item to the basket
	Then the backet count should be 1