using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using test3.Data;

namespace test3.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public byte? Employeekind { get; set; }
        public string UserId { get; set; }
        [Required]
        public virtual AspNetUser AspNetUser { get; set; }

    }
}