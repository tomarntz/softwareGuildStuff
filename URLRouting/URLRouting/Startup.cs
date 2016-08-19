using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(URLRouting.Startup))]
namespace URLRouting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
