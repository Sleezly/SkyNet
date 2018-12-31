namespace SkyNet.Utilities
{
    public class GeoLocation
    {
        public double Longitude { get; }

        public double Latitude { get; }

        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
