using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Living.Startup))]
namespace Living
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
