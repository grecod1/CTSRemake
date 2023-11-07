using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helpline.Startup))]
namespace Helpline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
