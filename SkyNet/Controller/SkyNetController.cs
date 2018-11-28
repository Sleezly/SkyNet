using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace SkyNet
{
    public class SkyNetController : ApiController
    {
        private static SkyNetServiceContract skyNetServiceContract = new SkyNetServiceContract();

        [Route("api/skynet")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new ObjectContent<WeatherReport>(skyNetServiceContract.Get(), new JsonMediaTypeFormatter(), "application/json")
            };

            return response;
        }
    }
}
