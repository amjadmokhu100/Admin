using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using test3.Data;

namespace test3.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Service name is required!")]
        [StringLength(200, MinimumLength =10,ErrorMessage = "Service name is should be 10 to 200!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double? NormalPrice { get; set; }
        public int? NormalHour { get; set; }
        public double? FastPrice { get; set; }
        public int? FastHour { get; set; }
        public string Photo { get; set; }
        public bool? Sale { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }
}