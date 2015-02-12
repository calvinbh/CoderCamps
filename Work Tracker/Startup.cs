using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Work_Tracker.Startup))]
namespace Work_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
