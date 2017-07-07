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
                var User = new ApplicationUser();
                User.UserName = "fernando@gmail.com"; // login
                User.Email = "fernando@gmail.com";
                User.Nome = "Fernando Sousa";

                var chkUser = userManager.Create(User, userPWD);
                //Adicionar o Utilizador à respetiva Role-Medico-
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(User.Id, "Medico");
                }
            }

            // Criar a role 'Terapeuta'
            if (!roleManager.RoleExists("Terapeuta"))
            {
                var role = new IdentityRole();
                role.Name = "Terapeuta";
                roleManager.Create(role);

                // criar um utilizador 'Terapeuta'
                var User = new ApplicationUser();
                User.UserName = "susana@gmail.com"; // login
                User.Email = "susana@gmail.com";
                User.Nome = "Susana Pereira";

                var chkUser = userManager.Create(User, userPWD);
                //Adicionar o Utilizador à respetiva Role-Terapeuta-
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(User.Id, "Terapeuta");
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

                    //Adicionar o Utilizador à respetiva Role-Dono-
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Administrativo");
                    }
                }
            }

        }
    }
}
