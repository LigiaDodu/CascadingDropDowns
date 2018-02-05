using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecondaryLevelFilters.Startup))]
namespace SecondaryLevelFilters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
