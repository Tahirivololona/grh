using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GRH_UI.Startup))]
namespace GRH_UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
