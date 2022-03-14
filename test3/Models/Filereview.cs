using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PaperHelp.Models
{
    public class Filereview
    {

        [DisplayName("Order Id")]

        public int OrderId { get; set; }

        [DisplayName("Write Your note:")]
        public string ClientNote { get; set; }

        [DisplayName("Upload Your Assist File:")]
        public string AssFile{ get; set; }

        public HttpPostedFileBase UploadFile { get; set; }
    }
}











   