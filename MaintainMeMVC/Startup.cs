using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaintainMeMVC.Startup))]
namespace MaintainMeMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
