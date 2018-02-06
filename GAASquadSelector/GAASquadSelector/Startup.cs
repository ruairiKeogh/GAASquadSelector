using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAASquadSelector.Startup))]
namespace GAASquadSelector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
