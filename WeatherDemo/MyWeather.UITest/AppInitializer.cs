﻿using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MyWeather.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            var apkpath = "../../../MyWeather.Droid/bin/Release/MyWeather.Droid-Signed.apk";
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    //.Debug()
                    .ApkFile(apkpath)
                    .StartApp();
            }

            //var appBundle = "../../../MyWeather.iOS/bin/iPhone/Release/MyWeatheriOS.app";
			var appName = "com.xpirit.weatherdemo";
            return ConfigureApp
                .iOS
                //.AppBundle(appBundle)
                .InstalledApp(appName)
                .StartApp();
        }
    }
}

