using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(R2D2.WebClient.Startup))]
namespace R2D2.WebClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
