using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperHelp.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public Nullable<byte> Employeekind { get; set; }
        public string UsersId { get; set; }
        public ApplicationUser Users { get; set; }

    }
}