using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exam16._17.Startup))]
namespace Exam16._17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
