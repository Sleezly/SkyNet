using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SkyNet
{
    [DataContract]
    public class WeatherReport
    {
        [DataMember]
        public int Temperature;

        [DataMember]
        public string Summary;

        [DataMember]
        public string Icon;

        [DataMember]
        public IEnumerable<Daily> Daily;
    }
}
