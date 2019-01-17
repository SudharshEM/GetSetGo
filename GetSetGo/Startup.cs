using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetSetGo.Startup))]
namespace GetSetGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
