using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iReadABook.Startup))]
namespace iReadABook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
