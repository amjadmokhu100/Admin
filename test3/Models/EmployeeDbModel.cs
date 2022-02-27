using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test3.Data;

namespace test3.Models
{
    public partial class EmployeeDbModel
    {

        public int Id { get; set; }
        public Nullable<byte> Employeekind { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}