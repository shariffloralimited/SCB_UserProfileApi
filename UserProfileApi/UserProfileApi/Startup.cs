using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(UserProfileApi.Startup))]

namespace UserProfileApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
