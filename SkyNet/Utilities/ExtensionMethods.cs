using DarkSky.Models;

namespace SkyNet
{
    public static class ExtensionMethods
    {
        public static string ToIconName(this Icon icon)
        {
            switch (icon)
            {
                case Icon.ClearDay:
                    return "weather-sunny";

                case Icon.ClearNight:
                    return "weather-night";

                case Icon.Cloudy:
                    return "weather-cloudy";

                case Icon.Rain:
                    return "weather-pouring";

                case Icon.Sleet:
                    return "weather-snowy-rainy";

                case Icon.Snow:
                    return "weather-snowy";

                case Icon.Wind:
                    return "weather-windy";

                case Icon.Fog:
                    return "weather-fog";

                case Icon.PartlyCloudyDay:
                    return "weather-partly-cloudy";

                case Icon.PartlyCloudyNight:
                    return "weather-night-partly-cloudy";
                    
                default:
                    return "error";
            }
        }
    }
}
