using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigHubWithM.Startup))]
namespace GigHubWithM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
