using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DojoLoko.Startup))]
namespace DojoLoko
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
