using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blood_Page.Startup))]
namespace Blood_Page
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
