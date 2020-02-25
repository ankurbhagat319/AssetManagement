using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssetManagement.Startup))]
namespace AssetManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
