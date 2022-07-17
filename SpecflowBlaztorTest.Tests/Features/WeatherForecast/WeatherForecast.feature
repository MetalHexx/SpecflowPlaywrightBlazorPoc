Feature: WeatherForecast
	As a user
	I need a weather forecast app
	So I know how to dress appropriately when I'm going outside

Scenario: User should be navigated to the weather forecast page using the left hand navigation
	Given I am on any page in the application
	When when I click on the weather forecast item in the left hand nav
	Then I am taken to the weather forecast page

Scenario: Weather forecast page should show a list of forecasts
	Given I am on the weather forecast page
	When the page loads
	Then I see a table of weather forecasts