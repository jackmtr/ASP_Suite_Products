using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuiteProducts.Startup))]
namespace SuiteProducts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
