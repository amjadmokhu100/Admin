using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using test3.Models;
using System;
using System.Linq;

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


            //var userEmp = new ApplicationUser();
            //userEmp.Email = 
            //userEmp.UserName = "Amjad";
            //var check2 = userManager.Create(user, "Aa@123456789");
            //if (check2.Succeeded)
            //{
            //    userManager.AddToRole(user.Id, "Admins");
            //}

        }

        //private void CreateUser(ApplicationDbContext context, string userName, string userEmail, string userPass, string userRole)
        //{
        //    if (context.Users.Any())
        //    {
        //        return;
        //    }
        //    var store = new UserStore<Users>(context);
        //    var manager = new UserManager<Users>(store)
        //    {
        //        PasswordValidator = new PasswordValidator
        //        {
        //            RequireNonLetterOrDigit = false,
        //            RequireDigit = false,
        //            RequireLowercase = false,
        //            RequireUppercase = false,
        //        }
        //    };

        //    var user = new Users
        //    {
        //        Id = user.
        //        Email = userEmail
        //    };

        //    manager.Create(User, userPass);
        //    manager.AddToRole(user.Id, userRole);
        //}



        //public static void CreateUserByRole(  ApplicationUser user, string password, ApplicationDbContext db)
        //{
        //    user.Id = Guid.NewGuid().ToString();

        //    var store = new UserStore<ApplicationUser>(db);
        //    var manager = new UserManager<ApplicationUser>(store);

        //    using (var dbContextTransaction = db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            manager.Create(user, password);
        //            db.SaveChanges();

        //            manager.AddToRole(user.Id, password);
        //            db.SaveChanges();

        //            dbContextTransaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            dbContextTransaction.Rollback();
        //        }
        //    }
        //}



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







