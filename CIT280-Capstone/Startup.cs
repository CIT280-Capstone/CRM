using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIT280_Capstone.Startup))]
namespace CIT280_Capstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
