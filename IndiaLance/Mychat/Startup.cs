using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Mychat.Startup))]
namespace Mychat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}