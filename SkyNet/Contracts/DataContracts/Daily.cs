using System.Runtime.Serialization;

namespace SkyNet
{
    [DataContract]
    public class Daily
    {
        [DataMember]
        public int High;

        [DataMember]
        public int Low;

        [DataMember]
        public int Percipitation;

        [DataMember]
        public string Icon;
    }
}
