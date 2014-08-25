using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineDoctorsAppointmentApp.Startup))]
namespace OnlineDoctorsAppointmentApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
