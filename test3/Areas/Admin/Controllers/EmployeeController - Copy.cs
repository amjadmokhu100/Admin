//using AutoMapper;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using test3;
//using test3.Models;
//using test3.Services;

//namespace test3.Areas.Admin.Controllers
//{

//    public class EmployeeController : Controller

//    {
//        private readonly IMapper mapper;
//        private readonly EmployeeService employeeService;


//        public UserManager<ApplicationUser> MyUserManager { get; set; }
//        // GET: Employee
//        private ApplicationSignInManager _signInManager;
//        private ApplicationUserManager _userManager { get; set; }
//        private ApplicationDbContext db { get; set; }
//        //ApplicationDbContext db2 = new ApplicationDbContext();
//        public EmployeeController()
//        {
//            mapper = AutoMapperConfig.Mapper;
//            employeeService = new EmployeeService();

//            db = new ApplicationDbContext();
//            MyUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
//        }
//        public ActionResult Index()
//        {
//            List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
//            //EmployeeLst = (from obj in db2.Employees
//            //               select obj).ToList();
//            var MyUsers_Roles = db.Roles.Where(x => x.Name == "Writer" || x.Name == "Profreader").SelectMany(x => x.Users).ToList();
//            List<ApplicationUser> myUsers = new List<ApplicationUser>();
//            foreach (var item in MyUsers_Roles)
//            {
//                var theUser = MyUserManager.FindById(item.UserId);
//                myUsers.Add(theUser);
//            }

//            foreach (var item in myUsers)
//            {
//                EmployeeModel employeeModel = new EmployeeModel()
//                {
//                    Id = db.Employees.First(x => x.UsersId == item.Id).Id,
//                    UsersId = item.Id,
//                    UserName = item.UserName,
//                    Email = item.Email,
//                    Employeekind = db.Employees.First(x => x.UsersId == item.Id).Employeekind
//                    //Employeekind = item.Employees.First().Employeekind
//                    ////Id = item.Id

//                };

//                //    byte empkind;
//                //    var userRole= MyUserManager.getr

//                EmployeeList.Add(employeeModel);
//            }
//            return View(EmployeeList);
//        }


//        public EmployeeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
//        {


//            UserManager = userManager;
//            SignInManager = signInManager;
//        }

//        public ApplicationSignInManager SignInManager
//        {
//            get
//            {
//                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
//            }
//            private set
//            {
//                _signInManager = value;
//            }
//        }

//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }
//        [HttpGet]
//        [AllowAnonymous]
//        public ActionResult Create()
//        {
//            ViewBag.Roles = new SelectList(db.Roles.Where(a => !a.Name.Contains("Admins") && !a.Name.Contains("Clinet")).ToList(), "Name", "Name");
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create(EmployeeModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
//                var result = await UserManager.CreateAsync(user, model.Password);
//                if (result.Succeeded)
//                {
//                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

//                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
//                    // Send an email with this link
//                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
//                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
//                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
//                    this.UserManager.AddToRole(user.Id, model.Roles);
//                    byte epKind;
//                    if (model.Roles == "Writer")
//                    {
//                        epKind = (byte)EmployeeKind.writer;
//                    }
//                    else if (model.Roles == "Profreader")
//                    {
//                        epKind = (byte)EmployeeKind.Profreader;


//                    }
//                    else
//                    {
//                        epKind = (byte)EmployeeKind.Admins;

//                    }

//                    var employee = new Employee { Employeekind = epKind, UsersId = user.Id };
//                    db.Employees.Add(employee);


//                    db.SaveChanges();

//                    return RedirectToAction("Index", "Employee");
//                }
//                ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name");

//                //AddErrors(result);
//                ModelState.AddModelError("error1", result.Errors.First().ToString());
//            }

//            // If we got this far, something failed, redisplay form
//            return View(model);
//        }

//        //private void AddErrors(IdentityResult result)
//        //{
//        //    throw new NotImplementeredException();
//        //}



//        //public ActionResult GetDetails(int id)
//        //{
//        //    Employee obj = db2.Employees.Find(id);
//        //obj = (from data in myDB.Employees
//        //       where data.EmployeeID == id
//        //       select data
//        //     ).FirstOrDefault();

//        //    return View("Details", obj);
//        //}

//        //public ActionResult DeleteEmployee(int id)
//        //{
//        //     Employee obj = db.Employees.Find(id);
//        //    obj = (from data in db.Employees
//        //          where data.Id == id
//        //         select data).FirstOrDefault();

//        //   db.Employees.Remove();
//        //  db.SaveChanges();

//        //    return RedirectToAction("Index");
//        //}

//        //[HttpGet]
//        //  public ActionResult Edit(int? Id)
//        //  {
//        //      ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name");
//        //      if (Id == null)
//        //      {
//        //          return HttpNotFound();
//        //      }
//        //      var currentEmployeeData = employeeService.Get(Id.Value);

//        //      EmployeeModel employeeModel = new EmployeeModel()
//        //      {
//        //          Id = currentEmployeeData.Id,
//        //          UsersId = currentEmployeeData.UsersId,
//        //          Employeekind = currentEmployeeData.Employeekind,
//        //          Email = currentEmployeeData.Users.Email,
//        //          UserName = currentEmployeeData.Users.UserName

//        //      };

//        //      return View(employeeModel);
//        //  }


//        //[HttpPost]
//        //public async Task<ActionResult> Edit(EmployeeModel Emodel)
//        //{
//        //    //ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name");
//        //    //if (ModelState.IsValid)
//        //    //{

//        //    if (ModelState.IsValid)
//        //    {
//        //        ApplicationUser emp_user = db.Users.Find(Emodel.UsersId);
//        //        emp_user.Email = Emodel.Email;
//        //        emp_user.UserName = Emodel.UserName;
//        //        this.UserManager.AddToRole(emp_user.Id, Emodel.Roles);
//        //        byte epKind;
//        //        if (Emodel.Roles == "Writer")
//        //        {
//        //            epKind = (byte)EmployeeKind.writer;
//        //        }
//        //        else if (Emodel.Roles == "Profreader")
//        //        {
//        //            epKind = (byte)EmployeeKind.Profreader;


//        //        }
//        //        else
//        //        {
//        //            epKind = (byte)EmployeeKind.Admins;
//        //        }


//        //        emp_user.Id = Emodel.UsersId;
//        //        var mm = UserManager.Update(emp_user);
//        //        db.SaveChanges();

//        //        return RedirectToAction("Index", "Employee");
//        //    }
//        //    ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name");

//        //    //AddErrors(result);
//        //    //  ModelState.AddModelError("error1", Emodel.Errors.First().ToString());


//        //    // If we got this far, something failed, redisplay form

//        //    return View(Emodel);

//        //}


//        //public ActionResult Edit(EmployeeModel data)
//        //{

//        //    try
//        //    {
//        //        if (ModelState.IsValid)
//        //        {

//        //            var employee = mapper.Map<Employee>(data);
//        //            int result = employeeService.Update(employee);
//        //            if (result >= 1)
//        //            {
//        //                return RedirectToAction("Index");
//        //            }
//        //            ViewBag.Message = "An error occurred!";
//        //        }
//        //        return View(data);

//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ViewBag.Message = ex.Message;
//        //        return View(data);
//        //    }

//        //}


//        // delete
//        public ActionResult Delete(int? Id)
//        {
//            if (Id != null)
//            {
//                var employee = employeeService.ReadById(Id.Value);
//                var employeeInfo = mapper.Map<EmployeeModel>(employee);
//                return View(employeeInfo);
//            }
//            return RedirectToAction("Index");
//        }

//    }
//}

