using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace MyWeather.BDD
{
	[Binding]
	public class ForecastSteps
	{
		readonly IApp app;

		public ForecastSteps()
		{ 
			app = FeatureContext.Current.Get<IApp>("App");
		}

		[Given(@"I opened the app")]
		public void IOpenedTheApp()
		{
			app.Screenshot("First screen.");
		}

		[When("I have entered Amsterdam as a location")]
		public void GiveInIHaveEnteredAmsterdamAsALocation()
		{
			app.Tap(x => x.Marked("LocationEntry"));
			app.Screenshot("Location Entry Tapped");

			app.ClearText(x => x.Marked("LocationEntry"));
			app.EnterText(x => x.Marked("LocationEntry"), "Amsterdam");
			app.Screenshot("Location Amsterdam entered");
		}

		[When("I set the Imperial switch to Off")]
		public void ISetTheImperialSwitchToOff()
		{
			app.Tap(x => x.Marked("ImperialSwitch"));
			app.Screenshot("Location Entry Tapped");
		}

		[When("I press the Get Weather button")]
		public void IPressTheGetWeatherButton()
		{
			app.Tap(x => x.Marked("GetWeatherButton"));
			app.Screenshot("Get Weather Button Tapped");
		}

		[Then("the weather for Amsterdam should be shown in Celcius")]
		public void TheWeatherForAmsterdamShouldBeShownInCelcius()
		{
			app.WaitForNoElement(x => x.Marked("ActivityIndicator"));
			var temperatureLabel = app.WaitForElement(x => x.Marked("TemperatureLabel"));
			app.Screenshot("Temperature retreived");

			var labelText = temperatureLabel[0].Text;
			Assert.IsNotNullOrEmpty(labelText);
			Assert.AreEqual(labelText.Substring(labelText.Length - 1), "C");
		}



		[Given("I have entered (.*) into the calculator")]
		public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
		{
			// TODO: implement arrange (recondition) logic
			// For storing and retrieving scenario-specific data, 
			// the instance fields of the class or the
			//     ScenarioContext.Current
			// collection can be used.
			// To use the multiline text or the table argument of the scenario,
			// additional string/Table parameters can be defined on the step definition
			// method. 

			ScenarioContext.Current.Pending();
		}

		[When("I press add")]
		public void WhenIPressAdd()
		{
			// TODO: implement act (action) logic

			ScenarioContext.Current.Pending();
		}

		[Then("the result should be (.*) on the screen")]
		public void ThenTheResultShouldBe(int result)
		{
			// TODO: implement assert (verification) logic

			ScenarioContext.Current.Pending();
		}
	}
}
