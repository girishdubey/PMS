using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PMS_Web.Startup))]
namespace PMS_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
