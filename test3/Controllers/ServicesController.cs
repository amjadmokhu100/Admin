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
    public class ServicesController : Controller
    {
        //public ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationDbContext db { get; set; }
        // public UserManager MyProperty { get; set; }

        public ServicesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Services
       public ActionResult MyOrders(string id)
        {
            string userid = User.Identity.GetUserId();

            var orders = db.Orders.Where(x => x.ClientId == id).ToList();
            //var myorder = db.Orders.Find(id);
            return View(orders);
        }

        // GET: Services
        public ActionResult Index()
        {
            /*Select all services*/
            var s = db.Services.ToList();
            return View(s);
        }
        [HttpGet]
        public ActionResult Order( int id)
        {

            // get services by id
            var O = db.Services.FirstOrDefault(b => b.Id == id);
           
            return View(O);
            
        }
        
        public PartialViewResult AddOrder_2(int id)
        {
            //PaperHelp.Models.Order order = new Models.Order() { ServiceId = id };

            AddOrder a = new AddOrder() { ServiceId = id };
            var s = db.Services.FirstOrDefault(b => b.Id == id);
            if (s.Sale == true)
            {
                return PartialView("AddOrderSale", a);
            }

            
            return PartialView("AddOrderView", a);
            //return PartialView(");
        }

        [HttpPost]
        public ActionResult AddOrder_3(AddOrder model)
        {
            //AddOrder o = new AddOrder();
            //if (ModelState.IsValid)
            //{
             var s = db.Services.FirstOrDefault(b => b.Id == model.ServiceId);
            string userid = User.Identity.GetUserId();
            if (s.Sale == true) {
                model.Price = (decimal)(model.NoOfPaper * s.NormalPrice);
                model.duration = (byte)(model.NoOfPaper * s.NormalHour);
                model.Description = model.Description;
                model.startDate = DateTime.Today;
                model.ClientId = userid;

                double hourtoday = model.duration;
                Order O = new Order();
                O.ServiceId = model.ServiceId;
                O.Price = model.Price;
                O.duration = (byte?)model.duration;
                O.Description = model.Description;
                O.NoOfPaper = model.NoOfPaper;
                O.OrderStatus = (byte)OrderStatus.WaitPayment;
                O.startDate = model.startDate;
                //string userid = User.Identity.GetUserId();
                O.ClientId = userid;


                O.finishedDate = DateTime.Now.AddHours(hourtoday);


                db.Orders.Add(O);
                db.SaveChanges();
                int latestOrderId = O.Id;

                return View(O);
              
            }
            else
            {

            
            if (model.IsNormal)
            {
                model.Price = (decimal)(model.NoOfPaper * s.NormalPrice);
                model.duration = (byte)(model.NoOfPaper * s.NormalHour);
                model.Description = model.Description;
                model.startDate = DateTime.Today;
            }
            else 

            {
                model.Price = (decimal)(model.NoOfPaper * s.FastPrice);
                model.duration = (byte)(model.NoOfPaper * s.FastHour);
                model.Description = model.Description;
                model.startDate = DateTime.Now;
            }

            double hourtoday = model.duration;

         
            Order O = new Order();
            O.ServiceId = model.ServiceId;
            O.Price = model.Price;
            O.duration =(byte?)model.duration;
            O.IsNormal = model.IsNormal;
            O.Description = model.Description;
            O.NoOfPaper = model.NoOfPaper;
            O.OrderStatus = (byte)OrderStatus.WaitPayment;
            O.startDate = model.startDate;

                //string userid = User.Identity.GetUserId();
                O.ClientId = userid;

                O.finishedDate = DateTime.Now.AddHours(hourtoday);
           

            db.Orders.Add(O);
            db.SaveChanges();
                int latestOrderId = O.Id;

            return View(O);
        }
}



        //[HttpGet]
        public ActionResult ClientPage(int id)
        {
            var myorder = db.Orders.Find(id);
            myorder.OrderStatus = (byte)OrderStatus.PindingAdmin;
            string userid = User.Identity.GetUserId();
            myorder.ClientId = userid;
            db.SaveChanges();
         

            var orders = db.Orders.Where(x => x.ClientId == userid).ToList();
            //return View(orders);

            //return View("~/Views/ClientHome/Index.cshtml");
            return RedirectToAction("Index", "ClientHome");

        }


        public ActionResult ClientPageFinish(int id)
        {
            var myorder = db.Orders.Find(id);
            myorder.OrderStatus = (byte)OrderStatus.Finished;
            string userid = User.Identity.GetUserId();
            myorder.ClientId = userid;

            db.SaveChanges();

            //var orders = db.Orders.Where(x => x.ClientId == userid).ToList();
            return RedirectToAction("Index", "ClientHome");
        }

        public ActionResult Delete(int id)
        {
            var OrderForm = db.Orders.FirstOrDefault(b => b.Id == id);

            db.Orders.Remove(OrderForm);
            db.SaveChanges();
            return RedirectToAction("Index", "ClientHome");

        }



        //[HttpPost]
        //public ActionResult ClientPage(Order Update)
        //{
        //    Update.OrderStatus =(byte?)OrderStatus.PindingAdmin;
        //    db.Entry(Update).State = EntityState.Modified;
        //    db.SaveChanges();
        //    //Order a = new Order() { ID = id };


        //    //a.OrderStatus = (byte?)OrderStatus.PindingAdmin;



        //    return View(Update);
        //}



        public ActionResult AddOrder_pay(int id)
        {
            //Order a = new Order() { ID = id };
            var myorder = db.Orders.Find(id);
            myorder.startDate = DateTime.Now;
            double hourtoday1 = (double)myorder.duration;
            myorder.finishedDate = DateTime.Now.AddHours(hourtoday1);
            string userid = User.Identity.GetUserId();
            myorder.ClientId = userid;
            db.SaveChanges();
            return View(myorder);

        }


        public ActionResult BackToOrder(int id)
        {
           
            var myorder = db.Orders.Find(id);
            var s = db.Services.Find(myorder.ServiceId);
            ViewBag.sale = s.Sale;
            return View(myorder);

        }

        public PartialViewResult BackToAddOrder_2(int id)
        {
           

            var a = db.Orders.Find(id);
            var s = db.Services.Find(a.ServiceId);
            ViewBag.sale = s.Sale;
            if (a.Service.Sale == true)
            {
                return PartialView("BackToEditOrderSale", a);
            }
            return PartialView("BackToEditOrderView", a);
            //return PartialView(");
        }

        [HttpPost]
        public ActionResult BackToAddOrder_3(Order model)
        {
            AddOrder o = new AddOrder() { Id = model.Id };
            var s = db.Services.FirstOrDefault(b => b.Id == model.ServiceId);
            if (s.Sale == true)
            {
                o.NoOfPaper = (int)model.NoOfPaper; ;
                o.Price = (decimal)(model.NoOfPaper * s.NormalPrice);
                o.duration = (int)(o.NoOfPaper * s.NormalHour);
                o.Description = model.Description;
                o.startDate = DateTime.Today;
                double hourtoday = o.duration;


                var myorder = db.Orders.Find(o.Id);

                myorder.Price = o.Price;
                myorder.duration = (byte?)o.duration;
               
                myorder.Description = o.Description;
                myorder.NoOfPaper = o.NoOfPaper;
                myorder.OrderStatus = (byte)OrderStatus.WaitPayment;
                myorder.startDate = o.startDate;

                string userid = User.Identity.GetUserId();
                myorder.ClientId = userid;

                myorder.finishedDate = DateTime.Now.AddHours(hourtoday);


                //db.Orders.Add(myorder);
                db.SaveChanges();
                int latestOrderId = myorder.Id;

                return View(myorder);
                

            }
            else { 
            //var s = db.Services.Find(model.ServiceId);
            o.IsNormal = (bool)model.IsNormal;
            if (o.IsNormal)
            {
               o.NoOfPaper = (int)model.NoOfPaper; ;
               o.Price = (decimal)(model.NoOfPaper * s.NormalPrice);
               o.duration = (int)(o.NoOfPaper * s.NormalHour);
               o.Description = model.Description;
               o.startDate = DateTime.Today;
            }
            else

            {
                o.NoOfPaper = (int)model.NoOfPaper;
                o.Price = (decimal)(model.NoOfPaper * s.FastPrice);
                o.duration = (int)(o.NoOfPaper * s.NormalHour); ;
                o.Description = model.Description;
                o.startDate = DateTime.Now;
            }

            double hourtoday = o.duration;


            var myorder = db.Orders.Find(o.Id);
         
            myorder.Price = o.Price;
            myorder.duration = (byte?)o.duration;
            myorder.IsNormal = o.IsNormal;
            myorder.Description = o.Description;
            myorder.NoOfPaper = o.NoOfPaper;
            myorder.OrderStatus = (byte)OrderStatus.WaitPayment;
            myorder.startDate = o.startDate;

                string userid = User.Identity.GetUserId();
                myorder.ClientId = userid;

                myorder.finishedDate = DateTime.Now.AddHours(hourtoday);


            //db.Orders.Add(myorder);
            db.SaveChanges();
            int latestOrderId = myorder.Id;

            return View(myorder);
        }
}

        public ActionResult RequestView(int id)
        {
            var myorder = db.Orders.Find(id);
            var s = db.Services.Find(myorder.ServiceId);
            string ServiceN = s.Name;
            ViewBag.SN = ServiceN;
            
            string[] filepath = Directory.GetFiles(Server.MapPath("~/Files/"));
            List<FileModel> files = new List<FileModel>() ;
           
        
            files.Add(new FileModel { FileName = Path.GetFileName(myorder.FinalFilePath) , OrderID = id}) ;
           

            return View(files);
        }


        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Files/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }
        public ActionResult SendReview(int id)
        {

            Filereview f = new Filereview();
            f.OrderId = id;
            //db.Fil.Add(f);
            //db.SaveChanges();


            var s = db.Orders.FirstOrDefault(b => b.Id == id);
            //s.ClientNote = s.ClientNote;
            ////db.Orders.Add(note);
            db.SaveChanges();

            return View();
        }

        [HttpPost]
        public ActionResult SendReview(Filereview obj , int id)

        {
            try
            {
                //Filereview obj = new Filereview() { OrderId = id };


                string strDateTime = System.DateTime.Now.ToString("ddMMyyyyHHMMss");
                string finalPath = "\\UploadFile\\" + strDateTime + obj.UploadFile.FileName;

                obj.UploadFile.SaveAs(Server.MapPath("~") + finalPath);
                obj.AssFile = finalPath;
                obj.ClientNote = obj.ClientNote; /**/
                obj.OrderId = id;
                ViewBag.Message = "Saved Successfully";

                /*start save data to database*/
                AssFile File = new AssFile();
                File.FilePath = obj.AssFile;
                File.OrderId = obj.OrderId;            /**/
                db.AssFiles.Add(File);



                //Order note = new Order();
                string userid = User.Identity.GetUserId();
                
                var o = db.Orders.Find(obj.OrderId);
                o.ClientId = userid;
                o.ClientNote = obj.ClientNote;
                o.OrderStatus = (byte)OrderStatus.Reviewing;
                //db.Orders.Add(note);
                //var s = db.Services.Find(o.ServiceId);
                //string ServiceN = s.Name;
                //ViewBag.SN = ServiceN;
                db.SaveChanges();


                /*end*/

                return RedirectToAction("Index", "ClientHome");

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                return View();
            }
        }











    }
}
