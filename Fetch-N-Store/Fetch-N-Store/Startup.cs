using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fetch_N_Store.Startup))]
namespace Fetch_N_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
