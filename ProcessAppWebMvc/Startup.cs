using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProcessAppWebMvc.Startup))]
namespace ProcessAppWebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
