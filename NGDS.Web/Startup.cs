using System.Data.Entity;
using Microsoft.Owin;
using NGDS.Web.DataContexts;
using NGDS.Web.Migrations;
using Owin;

[assembly: OwinStartupAttribute(typeof(NGDS.Web.Startup))]
namespace NGDS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DrinksDb, Configuration>());
            ConfigureAuth(app);
        }
    }
}
