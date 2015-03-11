using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCApplication.Startup))]
namespace MVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
