using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hierarchy.Startup))]
namespace Hierarchy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
