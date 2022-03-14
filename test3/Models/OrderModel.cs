using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperHelp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public int ServiceId { get; set; }
        public Nullable<bool> IsNormal { get; set; }
        public Nullable<int> NoOfPaper { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<byte> duration { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> finishedDate { get; set; }
        public string ClientNote { get; set; }
        public string Description { get; set; }
        public string writerId { get; set; }
        public string ProfreaderId { get; set; }
        public string FinalFilePath { get; set; }
        public string ProfraderNotes { get; set; }
        public Nullable<byte> OrderStatus { get; set; }
        public  Service Service { get; set; }
        public ApplicationUser Client { get; set; }
        public ApplicationUser writer { get; set; }
        public ApplicationUser Profreader { get; set; }

    }
}