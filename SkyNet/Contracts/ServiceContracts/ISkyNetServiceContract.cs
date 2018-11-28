using System.ServiceModel;

namespace SkyNet
{
    [ServiceContract]
    public interface ISkyNetServiceContract
    {
        [OperationContract]
        WeatherReport Get();
    }
}
