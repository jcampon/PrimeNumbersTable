using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimeNumbersTable.Web.Startup))]
namespace PrimeNumbersTable.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
