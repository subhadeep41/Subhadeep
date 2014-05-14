using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatRoomApplication.Startup))]
namespace ChatRoomApplication
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}