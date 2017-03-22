using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularProj.Startup))]
namespace AngularProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
