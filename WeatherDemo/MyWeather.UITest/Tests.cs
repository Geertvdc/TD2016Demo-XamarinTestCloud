using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Diagnostics;

namespace MyWeather.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void CheckWeatherAmsterdamMetric()
        {
            app.Screenshot("First screen.");

            app.Tap(x => x.Marked("LocationEntry"));
            app.Screenshot("Location Entry Tapped");

            app.ClearText(x => x.Marked("LocationEntry"));     
            app.EnterText(x => x.Marked("LocationEntry"), "Amsterdam");
            app.Screenshot("Location Amsterdam entered");

            app.Tap(x => x.Marked("ImperialSwitch"));
            app.Screenshot("Location Entry Tapped");

            app.Tap(x => x.Marked("GetWeatherButton"));
            app.Screenshot("Get Weather Button Tapped");

            app.WaitForNoElement(x => x.Marked("ActivityIndicator"));
            var temperatureLabel = app.WaitForElement(x => x.Marked("TemperatureLabel"));   
            app.Screenshot("Temperature retreived");

            var labelText = temperatureLabel[0].Text;
            Assert.IsNotNullOrEmpty(labelText);
            Assert.AreEqual(labelText.Substring(labelText.Length - 1), "C");
        }

        [Test]
        public void CheckWeatherAmsterdamImperial()
        {
            app.Screenshot("First screen.");

            app.Tap(x => x.Marked("LocationEntry"));
            app.Screenshot("Location Entry Tapped");

            app.ClearText(x => x.Marked("LocationEntry"));
            app.EnterText(x => x.Marked("LocationEntry"), "Amsterdam");
            app.Screenshot("Location Amsterdam entered");

            app.Tap(x => x.Marked("GetWeatherButton"));
            app.Screenshot("Get Weather Button Tapped");

            app.WaitForNoElement(x => x.Marked("ActivityIndicator"));
            var temperatureLabel = app.WaitForElement(x => x.Marked("TemperatureLabel"));
            app.Screenshot("Temperature retreived");

            var labelText = temperatureLabel[0].Text;
            Assert.IsNotNullOrEmpty(labelText);
            Assert.AreEqual(labelText.Substring(labelText.Length - 1), "F");
        }

        [Test]
        public void CheckWeatherNonExistingPlaceGivesErrorMessage()
        {
            app.Screenshot("First screen.");

            app.Tap(x => x.Marked("LocationEntry"));
            app.Screenshot("Location Entry Tapped");

            app.ClearText(x => x.Marked("LocationEntry"));
            app.EnterText(x => x.Marked("LocationEntry"), "thisplacedoesnotexist");
			app.Screenshot("Unknown Location entered");
            app.Tap(x => x.Marked("ImperialSwitch"));
            app.Screenshot("Location Entry Tapped");

            app.Tap(x => x.Marked("GetWeatherButton"));
            app.Screenshot("Get Weather Button Tapped");

            var temperatureLabel = app.WaitForElement(x => x.Marked("TemperatureLabel").Text("Unable to get Weather"));
            app.Screenshot("Error message shown");

            var labelText = temperatureLabel[0].Text;
            Assert.IsNotNullOrEmpty(labelText);
            Assert.AreEqual(labelText, "Unable to get Weather");
        }

        [Test]
        public void ForeCastOverViewShownAfterSearch()
        {
            app.Screenshot("First screen.");

            app.Tap(x => x.Marked("LocationEntry"));
            app.Screenshot("Location Entry Tapped");

            app.ClearText(x => x.Marked("LocationEntry"));
            app.EnterText(x => x.Marked("LocationEntry"), "Amsterdam");
            app.Screenshot("Location Amsterdam entered");

            app.Tap(x => x.Marked("GetWeatherButton"));
            app.Screenshot("Get Weather Button Tapped");

            app.WaitForNoElement(x => x.Marked("ActivityIndicator"));
            app.Screenshot("Weather retrieved");

            app.Tap(x => x.Marked("Forecast"));
            app.Screenshot("Forecast overview");
        }

	}
}

