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
            // inicia os utilizadores
            iniciaAplicacao();
        }

        // Criar Roles e Utilizadores
        // Em Startup iam criando a primeira função admin e criar um usuário Administrador padrão
        private void iniciaAplicacao()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            string userPWD = "aBC_123";

            // criar a Role 'Médico'
            if (!roleManager.RoleExists("Medico"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Medico";
                roleManager.Create(role);

                // criar um utilizador 'Médico'
                string[] loginDosUtilizadores = { "fernando@gmail.com", "silvia@gmail.com", "fdias@gmail.com" };
                string[] nomeDosUtilizadores = { "Fernando Sousa", "Sílvia Marques", "Francisco Dias" };

                // cria os utilizadores
                for (int i = 0; i < loginDosUtilizadores.Length; i++)
                {
                    var user = new ApplicationUser();
                    user.UserName = loginDosUtilizadores[i];
                    user.Email = loginDosUtilizadores[i];
                    user.Nome = nomeDosUtilizadores[i];
                    user.EmailConfirmed = true;
                    var chkUser = userManager.Create(user, userPWD);

                    //Adicionar o Utilizador à respetiva Role-Medico-
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Medico");
                    }
                }
            }

            // Criar a role 'Terapeuta'
            if (!roleManager.RoleExists("Terapeuta"))
            {
                var role = new IdentityRole();
                role.Name = "Terapeuta";
                roleManager.Create(role);

                // criar  utilizadores 'Terapeuta'
                string[] loginDosUtilizadores = { "susana@gmail.com", "mgouveia@gmail.com", "celeste@gmail.com", "manlopes@gmail.com" };
                string[] nomeDosUtilizadores = { "Susana Pereira", "Maria Gouveia", "Celeste Gomes", "Manuel Lopes" };


                // cria os utilizadores
                for (int i = 0; i < loginDosUtilizadores.Length; i++)
                {
                    var user = new ApplicationUser();
                    user.UserName = loginDosUtilizadores[i];
                    user.Email = loginDosUtilizadores[i];
                    user.Nome = nomeDosUtilizadores[i];
                    user.EmailConfirmed = true;
                    var chkUser = userManager.Create(user, userPWD);

                    //Adicionar o Utilizador à respetiva Role-Terapeuta-
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Terapeuta");
                    }
                }
            }

            // Criar a role 'Administrativo'
            if (!roleManager.RoleExists("Administrativo"))
            {
                var role = new IdentityRole();
                role.Name = "Administrativo";
                roleManager.Create(role);

                // criar  utilizadores 'Administrativo'
                string[] loginDosUtilizadores = { "pedro.f@gmail.com", "lurdes@gmail.com", "santos@gmail.com" };
                string[] nomeDosUtilizadores = { "Pedro Ferreira", "Lurdes Fontes", "Vitor Santos" };


                // cria os utilizadores
                for (int i = 0; i < loginDosUtilizadores.Length; i++)
                {
                    var user = new ApplicationUser();
                    user.UserName = loginDosUtilizadores[i];
                    user.Email = loginDosUtilizadores[i];
                    user.Nome = nomeDosUtilizadores[i];
                    user.EmailConfirmed = true;
                    var chkUser = userManager.Create(user, userPWD);

                    //Adicionar o Utilizador à respetiva Role-Administrativo-
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Administrativo");
                    }
                }
            }

        }
    }
}
