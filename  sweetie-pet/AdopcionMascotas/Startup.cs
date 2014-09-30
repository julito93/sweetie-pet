using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdopcionMascotas.Startup))]
namespace AdopcionMascotas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
