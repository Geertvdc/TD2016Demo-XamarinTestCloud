Feature: Getting the weather forecast
	In order to get weather
	As a weather enthousiast from europe
	I want to be told the weather of a certain location in Celcius
	
@mytag
Scenario: Get forecast for manually added location
	Given I opened the app
	When I have entered Amsterdam as a location
	And I set the Imperial switch to Off
	And I press the Get Weather button
	Then the weather for Amsterdam should be shown in Celcius
	