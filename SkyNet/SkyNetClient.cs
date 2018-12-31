using DarkSky.Models;
using DarkSky.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkyNet
{
    public class SkyNetClient 
    {
        private readonly static TimeSpan PollingDurationDelay = TimeSpan.FromMinutes(8);

        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
       
        private DarkSkyService DarkSkyService = new DarkSkyService(Secrets.DarkSkyApiKey);

        private WeatherReport WeatherReport = null;

        public SkyNetClient()
        {
            Task.Run(() => PeriodicDarkSkyUpdateThread(cancellationTokenSource.Token), cancellationTokenSource.Token);
        }

        public WeatherReport GetWeatherReport()
        {
            while (null == WeatherReport)
            {
                Task.Delay(TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();
            }

            return WeatherReport;
        }

        private async Task PeriodicDarkSkyUpdateThread(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await GetWeatherForecast();

                await Task.Delay(PollingDurationDelay);
            }
        }

        private async Task GetWeatherForecast()
        {
            try
            {
                DarkSkyResponse darkSkyResponse = await DarkSkyService.GetForecast(Secrets.GeoLocation.Latitude, Secrets.GeoLocation.Longitude);

                if (darkSkyResponse.IsSuccessStatus)
                {
                    WeatherReport = new WeatherReport()
                    {
                        Temperature = Convert.ToInt16(darkSkyResponse.Response.Currently.Temperature.GetValueOrDefault()),
                        Icon = darkSkyResponse.Response.Currently.Icon.ToIconName(),
                        Summary = darkSkyResponse.Response.Daily.Summary,

                        Daily = darkSkyResponse.Response.Daily.Data.Select(x => new Daily()
                        {
                            High = Convert.ToInt16(x.TemperatureHigh.GetValueOrDefault()),
                            Low = Convert.ToInt16(x.TemperatureLow.GetValueOrDefault()),
                            Percipitation = Convert.ToInt16(x.PrecipProbability.GetValueOrDefault() * 100),
                            Icon = x.Icon.ToIconName(),
                        }),
                    };

                    Debug.WriteLine($"{WeatherReport.Temperature} {WeatherReport.Icon} {WeatherReport.Summary}");
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"{exception.Message} {exception.Source}");
            }
        }
    }
}
