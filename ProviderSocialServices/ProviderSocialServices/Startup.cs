using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProviderSocialServices.Startup))]
namespace ProviderSocialServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
