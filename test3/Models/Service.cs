using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperHelp.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<double> NormalPrice { get; set; }
        public Nullable<int> NormalHour { get; set; }
        public Nullable<double> FastPrice { get; set; }
        public Nullable<int> FastHour { get; set; }
        public string Photo { get; set; }
        public Nullable<bool> Sale { get; set; }

    }
}