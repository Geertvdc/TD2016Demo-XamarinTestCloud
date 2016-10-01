using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MyWeather.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
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
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }


        [Test]
        public void NewTest1()
        {
            app.Tap(x => x.Class("SwitchCompat"));
            app.Tap(x => x.Text("amsterdam"));
        }

        [Test]
        public void NewTest2()
        {
            app.Tap(x => x.Text("Seattle,WA"));
            app.ClearText(x => x.Class("EntryEditText").Text("Seattle,WA"));
            app.EnterText(x => x.Class("EntryEditText"), "amsterdam");
            app.PressEnter();
            app.Tap(x => x.Class("SwitchCompat"));
            app.Tap(x => x.Text("Get Weather"));
            
            
            app.Screenshot("ScreenshotEvent");
            
        }

        [Test]
        public void NewTest3()
        {
            app.Tap(x => x.Text("Seattle,WA"));
            app.Tap(x => x.Text("Seattle,WA"));
            app.ClearText(x => x.Class("EntryEditText").Text("Seattle,WA"));
            app.EnterText(x => x.Class("EntryEditText"), "Amsterdam");
            app.PressEnter();
            app.Tap(x => x.Class("SwitchCompat"));
            app.Tap(x => x.Text("Get Weather"));
            app.WaitForElement(x => x.Marked("ConditionLabel"));
            app.WaitForElement(x => x.Marked("TempLabel"));
            app.Tap(x => x.Text("Amsterdam"));
            app.ClearText(x => x.Class("EntryEditText").Text("Amsterdam"));
            app.EnterText(x => x.Class("EntryEditText"), "blablabla");
            app.Tap(x => x.Text("Get Weather"));
        }


    }
}

