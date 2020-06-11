using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GpBooking.Startup))]
namespace GpBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
