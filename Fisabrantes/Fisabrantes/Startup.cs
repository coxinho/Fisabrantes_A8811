using System;
using Fisabrantes.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        // Em Startup iam criando a primeira função admin e criar um usuário Administrador padrão
        private void iniciaAplicacao()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // Criar a role 'Administrativo'
            if (!roleManager.RoleExists("Administrativo"))
            {
                var role = new IdentityRole();
                role.Name = "Administrativo";
                roleManager.Create(role);

                // criar um utilizador 'Administrativo'
                var User = new ApplicationUser();
                User.UserName = "pedro";
                User.Email = "pedro.f@gmail.com";
                User.Nome = "Pedro Ferreira";
                string UserPWD = "123pedro";
                var chkUser = userManager.Create(User, UserPWD);

                //Adicionar o Utilizador à respetiva Role-Administrativo-
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(User.Id, "Administrativo");
                }
            }

        }
    }
}
