using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ARSM___Avtobusi_R.S.Makedonija.Startup))]
namespace ARSM___Avtobusi_R.S.Makedonija
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
