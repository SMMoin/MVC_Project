using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcProject_Moin.Startup))]
namespace MvcProject_Moin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
