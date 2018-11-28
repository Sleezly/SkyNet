using System.Threading;
using Topshelf;

namespace SkyNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SkyNetService>(p =>
                {
                    p.ConstructUsing(name => new SkyNetService());
                    p.WhenStarted(tc => tc.Start());
                    p.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("SkyNet Service");
                x.SetDisplayName("SkyNet Service");
                x.SetServiceName("SkyNet Service");
            });
        }
    }
}
