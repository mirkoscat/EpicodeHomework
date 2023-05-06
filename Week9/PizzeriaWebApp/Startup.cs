using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzeriaWebApp.Startup))]
namespace PizzeriaWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
