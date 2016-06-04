using System.Web.Http;
using Microsoft.Owin;
using OverwatchSynergy.Api;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace OverwatchSynergy.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
            app.UseWebApi(config);
        }
    }
}