namespace SkyNet
{
    public class SkyNetServiceContract : ISkyNetServiceContract
    {
        private static readonly SkyNetClient SkyNetClient = new SkyNetClient();

        /// <summary>
        /// Retrieval of the weather report.
        /// </summary>
        /// <returns></returns>
        public WeatherReport Get()
        {
            return SkyNetClient.GetWeatherReport();
        }
    }
}
