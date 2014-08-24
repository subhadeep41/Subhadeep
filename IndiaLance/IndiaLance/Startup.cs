using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IndiaLance.Startup))]
namespace IndiaLance
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}