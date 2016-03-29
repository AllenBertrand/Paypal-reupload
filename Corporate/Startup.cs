using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Corporate.Startup))]
namespace Corporate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
