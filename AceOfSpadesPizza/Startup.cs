using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AceOfSpadesPizza.Startup))]
namespace AceOfSpadesPizza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
