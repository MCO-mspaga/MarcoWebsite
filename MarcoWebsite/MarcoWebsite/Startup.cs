using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarcoWebsite.Startup))]
namespace MarcoWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
