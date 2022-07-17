Feature: Counter
	As a user
	I need a counter app
	Because I need to count stuff

Scenario: User should be navigated to the counter page using the left hand navigation
	Given I am on any page in the application
	When when I click on the counter item in the left hand nav
	Then I am taken to the counter page

Scenario: Counter should increase when button is clicked
	Given I am on the counter page
	When I click the button 1 times
	Then the current counter should be 1

Scenario: Counter should increase to 3 when the button is clicked 3 times
	Given I am on the counter page
	When I click the button 3 times
	Then the current counter should be 3