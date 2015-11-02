using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iCalendarMVC.Startup))]
namespace iCalendarMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
