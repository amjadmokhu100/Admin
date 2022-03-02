using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using test3.Models;

[assembly: OwinStartupAttribute(typeof(test3.Startup))]
namespace test3
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUser();
        }
        public void CreateUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "jad100@gmail.com";
            user.UserName = "Amjad";
            var check = userManager.Create(user, "Aa@123456789");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }
        }


        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            // check if role is existing
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Writer"))
            {
                role = new IdentityRole();

                role.Name = "Writer";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Profreader"))
            {
                role = new IdentityRole();

                role.Name = "Profreader";
                roleManager.Create(role);
            }
        }


    }
}







