using PaperHelp.Models;
using PaperHelp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;

namespace PaperHelp.Controllers
{
    [Authorize]
    public class ClientHomeController : Controller
    {
        // GET: ClientPage


        public ApplicationDbContext db { get; set; }
        // public UserManager MyProperty { get; set; }

        public ClientHomeController()
        {
            db = new ApplicationDbContext();
        }


        public ActionResult Index()
        {

            string userid = User.Identity.GetUserId();
            string username = User.Identity.GetUserName();
            ViewBag.profile = username;
            var orders = db.Orders.Where(x => x.ClientId == userid).OrderByDescending(x=>x.finishedDate).ToList();
            //var myorder = db.Orders.Find(id);
            return View(orders);


        }
    }
}