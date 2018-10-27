using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapWeb.Startup))]
namespace MapWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
