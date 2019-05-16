using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SkyNet.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
