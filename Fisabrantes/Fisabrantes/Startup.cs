using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fisabrantes.Startup))]
namespace Fisabrantes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


        //ver o código do e-learning, para criar Roles e Utilizadores



    }
}
