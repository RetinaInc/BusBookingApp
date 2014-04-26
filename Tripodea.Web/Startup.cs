using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tripodea.Web.Startup))]
namespace Tripodea.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
