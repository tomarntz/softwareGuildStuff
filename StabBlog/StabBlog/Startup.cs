using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StabBlog.Startup))]
namespace StabBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
