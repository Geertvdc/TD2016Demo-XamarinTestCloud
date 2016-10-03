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
		}

		[When("I have entered Amsterdam as the location")]
		public void GiveInIHaveEnteredAmsterdamAsALocation()
		{
			app.Tap(x => x.Marked("LocationEntry"));

			app.ClearText(x => x.Marked("LocationEntry"));
			app.EnterText(x => x.Marked("LocationEntry"), "Amsterdam");
		}

		[When("I set the Imperial switch to Off")]
		public void ISetTheImperialSwitchToOff()
		{
			app.Tap(x => x.Marked("ImperialSwitch"));
		}

		[When("I press the Get Weather button")]
		public void IPressTheGetWeatherButton()
		{
			app.Tap(x => x.Marked("GetWeatherButton"));
		}

		[Then("the weather for Amsterdam should be shown in Celsius")]
		public void TheWeatherForAmsterdamShouldBeShownInCelcius()
		{
			app.WaitForNoElement(x => x.Marked("ActivityIndicator"));
			var temperatureLabel = app.WaitForElement(x => x.Marked("TemperatureLabel"));

			var labelText = temperatureLabel[0].Text;
			Assert.IsNotNullOrEmpty(labelText);
			Assert.AreEqual(labelText.Substring(labelText.Length - 1), "C");
		}
	}
}
