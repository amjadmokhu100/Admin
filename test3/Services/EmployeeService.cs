//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using test3.Data;

//namespace test3.Services
//{
//    public interface IEmployeeService
//    {
//        int Create(Employee employee);
//        IEnumerable<Employee> ReadAll();
//    }
//    public class EmployeeService : IEmployeeService
//    {
//        private readonly PaperHelpDbEntities db;

//        public EmployeeService()
//        {
//            db = new PaperHelpDbEntities();
//        }
//        public int Create(Employee employee)
//        {
//            var existsEmployee = FindByEmail(employee.AspNetUser.Email);
//            if (existsEmployee !=null)
//            {
//                return -2;
//            }
//            db.Employees.Add(employee);
//            return db.SaveChanges();
//        }

//        public AspNetUser FindByEmail(string email)
//        {
//          return  db.AspNetUsers.Where(e => e.Email == email).FirstOrDefault();   
                
                
//        }

//        public IEnumerable<Employee> ReadAll()
//        {
//            throw new NotImplementedException();
//        }

//        public Employee ReadById(int Id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}