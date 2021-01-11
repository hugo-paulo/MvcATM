using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcATM.Startup))]
namespace MvcATM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
