using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISSU.Startup))]
namespace ISSU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
