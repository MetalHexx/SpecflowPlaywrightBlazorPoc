Feature: Home
	As a user
	I need a home page
	So I have a good place to start

Scenario: User should be navigated to the home page using the left hand navigation
	Given I am currently on the counter page
	When when I click on the home item in the left hand nav
	Then I am taken to the home page
