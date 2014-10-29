using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NGDS.Web.Startup))]
namespace NGDS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
