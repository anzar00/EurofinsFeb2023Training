using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnowledgeHubPortal.UI.Startup))]
namespace KnowledgeHubPortal.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
