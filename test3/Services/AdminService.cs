using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test3.Models;

namespace test3.Services
{
    public interface IAdminService
    {
        bool Login(string Email, string Password);
        bool ChangePassword(string Email, string Password);
        bool ForgotPassword(string Email);
    }
    public class AdminService : IAdminService
    {
        public ApplicationDbContext context { get; set; }

        public AdminService()
        {
            context = new ApplicationDbContext();
        }

        public bool ChangePassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string Email)
        {
            throw new NotImplementedException();
        }

        public bool Login(string Email, string Password)
        {
            throw new NotImplementedException();
        }
    }
}