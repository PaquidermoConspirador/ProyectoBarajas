using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Metro2018.Web.Startup))]
namespace Metro2018.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureDI(app);
        }
    }
}