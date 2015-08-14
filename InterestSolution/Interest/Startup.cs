using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Interest.Startup))]
namespace Interest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
