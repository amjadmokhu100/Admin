using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test3.Models;

namespace test3.Services
{
    public interface IEmployeeService
    {
        bool Delete(int id);
        Employee ReadById(int id);

    }
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext db;
        public UserManager<ApplicationUser> MyUserManager { get; set; }
        public EmployeeService()
        {
            db = new ApplicationDbContext();
            MyUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

       

        public bool Delete(int id)
        {
            var employee = ReadById(id);
            if (employee != null)
            {
                string userId = employee.UsersId;
                db.Employees.Remove(employee);
                db.SaveChanges();
                var user = MyUserManager.FindById(userId);
                MyUserManager.Delete(user);
                return true;
            }
            return false;
        }


        public Employee ReadById(int id)
        {
            return db.Employees.Find(id);
        }


    }
}