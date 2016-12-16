using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facebook_OpenID.Startup))]
namespace Facebook_OpenID
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
