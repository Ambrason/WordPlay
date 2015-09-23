using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordPlay.Startup))]
namespace WordPlay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
