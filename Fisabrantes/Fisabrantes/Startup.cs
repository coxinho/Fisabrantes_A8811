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
        private void iniciaAplicacao()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Médico'
            if (!roleManager.RoleExists("Médico"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Médico";
                roleManager.Create(role);

                // criar um utilizador 'Médico'
                var User = new ApplicationUser();
                User.UserName = "fernando@a.aa";
                User.Email = "fernando@a.aa";
                User.Nome = "Fernando Sousa";
                string UserPWD = "sousa";
                var chkUser = userManager.Create(User, UserPWD);

            }

            // Criar a role 'Terapeuta'
            if (!roleManager.RoleExists("Terapeuta"))
            {
                var role = new IdentityRole();
                role.Name = "Terapeuta";
                roleManager.Create(role);

                // criar um utilizador 'Terapeuta'
                var User = new ApplicationUser();
                User.UserName = "gouveia@a.aa";
                User.Email = "gouveia@a.aa";
                User.Nome = "Maria Gouveia";
                string UserPWD = "336622";
                var chkUser = userManager.Create(User, UserPWD);
            }

            // Criar a role 'Administrativo'
            if (!roleManager.RoleExists("Administrativo"))
            {
                var role = new IdentityRole();
                role.Name = "Administrativo";
                roleManager.Create(role);

                // criar um utilizador 'Administrativo'
                var User = new ApplicationUser();
                User.UserName = "pedro.f@a.aa";
                User.Email = "pedro.f@a.aa";
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
