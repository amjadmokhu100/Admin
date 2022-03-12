using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test3.Models;

namespace test3.Areas.Admin.Controllers
{
    public class ApplicationUsersController : Controller
    {
        public UserManager<ApplicationUser> MyUserManager { get; set; }
        private ApplicationUserManager _userManager { get; set; }
        private ApplicationDbContext db { get; set; }

        public ApplicationUsersController()
        {
            db = new ApplicationDbContext();
            MyUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Admin/ApplicationUsers
        public ActionResult Index()
        {
            List<ApplicationUsersViewModel> ClinetList = new List<ApplicationUsersViewModel>();
            //EmployeeLst = (from obj in db2.Employees
            //               select obj).ToList();
            var MyUsers_Roles = db.Roles.Where(x => x.Name == "Clinet").SelectMany(x => x.Users).ToList();
            List<ApplicationUser> myUsers = new List<ApplicationUser>();
            foreach (var item in MyUsers_Roles)
            {
                var theUser = MyUserManager.FindById(item.UserId);
                myUsers.Add(theUser);
            }

            foreach (var item in myUsers)
            {
                ApplicationUsersViewModel applicationUsersViewModel = new ApplicationUsersViewModel()
                {
                    Id = db.Users.First(x => x.Id == item.Id).Id,
                    UserName = item.UserName,
                    Email = item.Email,
                    IsActive = item.IsActive
                    //Employeekind = db.Employees.First(x => x.UsersId == item.Id).Employeekind
                    //Employeekind = item.Employees.First().Employeekind
                    ////Id = item.Id

                };
                //    byte empkind;
                //    var userRole= MyUserManager.getr

                ClinetList.Add(applicationUsersViewModel);
            }
            return View(ClinetList);
        }

    }
}