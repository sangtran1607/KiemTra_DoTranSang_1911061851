using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KiemTra_DoTranSang_1911061851.Startup))]
namespace KiemTra_DoTranSang_1911061851
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
