using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperHelp.Models
{
    public class AssFile
    {
        public int id { get; set; }
        public string FilePath { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}