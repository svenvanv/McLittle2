using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(McLittle.Startup))]
namespace McLittle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
