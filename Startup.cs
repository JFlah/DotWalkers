using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotWalkersFinal.Startup))]
namespace DotWalkersFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
