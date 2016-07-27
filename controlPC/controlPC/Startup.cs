using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(controlPC.Startup))]
namespace controlPC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
