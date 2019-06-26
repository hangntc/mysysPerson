using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTotNghiep.Startup))]
namespace WebTotNghiep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
