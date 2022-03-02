﻿
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using test3;
using test3.Data;
using test3.Models;

namespace test3.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db;
        PaperHelpDbEntities db2 = new PaperHelpDbEntities();
        public EmployeeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
            //EmployeeLst = (from obj in db2.Employees
            //               select obj).ToList();

            foreach (var item in db2.AspNetUsers)
            {
                EmployeeModel employeeModel = new EmployeeModel() {
                    UserId = item.Id, UserName = item.UserName, Email = item.Email, Employeekind = item.Employees.First().Employeekind


                };
                EmployeeList.Add(employeeModel);
            }
            return View(EmployeeList);
        }
      
        public EmployeeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {


            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(db.Roles.Where(a=>!a.Name.Contains("Admins")).ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    this.UserManager.AddToRole(user.Id, model.Roles);
                    byte epKind;
                    if (model.Roles == "Writer")
                    {
                        epKind = (byte)EmployeeKind.writer;
                    }
                    else
                    {
                        epKind = (byte)EmployeeKind.profreader;


                    }
                    var employee = new Employee { Employeekind = epKind, UserId = user.Id};
                    db2.Employees.Add(employee);
                    db2.SaveChanges();
                   
                    return RedirectToAction("Index", "Employee");
                }
                ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name");

                //AddErrors(result);
                ModelState.AddModelError("error1", result.Errors.First().ToString());
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //private void AddErrors(IdentityResult result)
        //{
        //    throw new NotImplementeredException();
        //}

        //[HttpPost]
        //public ActionResult Create(Employee employee)
        //{
        //    db2.Employees.Add(employee);
        //    db2.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult GetDetails(int id)
        //{
        //    Employee obj = db2.Employees.Find(id);
        //obj = (from data in myDB.Employees
        //       where data.EmployeeID == id
        //       select data
        //     ).FirstOrDefault();

        //    return View("Details", obj);
        //}

        //public ActionResult DeleteEmployee(int id)
        //{
        //    Employee obj = db2.Employees.Find(id);
        //obj = (from data in myDB.Employees
        //       where data.EmployeeID == id
        //       select data).FirstOrDefault();

        //db2.Employees.Remove(obj);
        //db2.SaveChanges();

        //return RedirectToAction("Index");
    }

    }
