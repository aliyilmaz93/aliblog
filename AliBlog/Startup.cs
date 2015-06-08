using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AliBlog.Startup))]
namespace AliBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
