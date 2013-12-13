using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace LoggerSignalR.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
