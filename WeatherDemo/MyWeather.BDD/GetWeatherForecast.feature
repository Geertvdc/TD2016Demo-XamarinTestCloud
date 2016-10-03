Feature: Getting the weather forecast
	In order to get weather
	As a weather enthusiast from europe
	I want to be told the weather of a certain location in Celsius

Scenario: Get forecast for manually added location
	Given I opened the app
	When I have entered Amsterdam as the location
	When I set the Imperial switch to Off
	When I press the Get Weather button
	Then the weather for Amsterdam should be shown in Celsius