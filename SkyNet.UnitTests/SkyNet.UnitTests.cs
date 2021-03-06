﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SkyNet.UnitTests
{
    [TestClass]
    public class SkyNetTests
    {
        [TestMethod]
        public void BVT()
        {
            SkyNetClient skyNetClient = new SkyNetClient();

            WeatherReport weatherReport = skyNetClient.GetWeatherReport();

            Assert.IsNotNull(weatherReport);
            Assert.IsNotNull(weatherReport.Daily);
            Assert.IsFalse(string.IsNullOrEmpty(weatherReport.Icon));
            Assert.IsFalse(string.IsNullOrEmpty(weatherReport.Summary));
        }
    }
}
