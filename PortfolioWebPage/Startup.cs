using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortfolioWebPage.Startup))]
namespace PortfolioWebPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
