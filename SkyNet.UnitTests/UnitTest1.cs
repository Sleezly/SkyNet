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

            skyNetClient.GetWeatherReport();
        }
    }
}
