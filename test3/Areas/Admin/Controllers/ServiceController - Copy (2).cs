

//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using test3.Data;
//using test3.Models;
//using test3.Services;

//namespace test3.Areas.Admin.Controllers
//{
//    public class ServiceController : Controller
//    {
//        private readonly Service_Service service_Service;
//        private readonly IMapper mapper;
//        PaperHelpDbEntities db = new PaperHelpDbEntities();

//        public ServiceController()
//        {
//            service_Service = new Service_Service();
//            mapper = AutoMapperConfig.Mapper;
//        }

//        GET: Admin/Service
//        public ActionResult Index()
//        {
//            var services = service_Service.ReadAll();
//            var serviceList = mapper.Map<List<ServiceModel>>(services);
//            foreach (var item in services)
//            {
//                serviceList.Add(new ServiceModel
//                {
//                    Id = item.Id,
//                    Name = item.Name,
//                    Description = item.Description,
//                    NormalPrice = item.NormalPrice,
//                    NormalHour = item.NormalHour,
//                    FastPrice = item.FastPrice,
//                    FastHour = item.FastHour,
//                    Photo = item.Photo
//                });
//            }
//            return View(db.Services.ToList());
//            return View(serviceList);
//        }
//        [HttpGet]
//        public ActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Create(ServiceModel data)
//        {


//            if (data.PhotoFile == null || data.PhotoFile.ContentLength == 0)
//                return View(data);

//            var fileExtension = Path.GetExtension(data.PhotoFile.FileName);
//            var photoGuid = Guid.NewGuid().ToString();
//            data.Photo = photoGuid + fileExtension;
//            save file in upload / services file
//            string filePath = Server.MapPath($"~/Upload/Services/{data.Photo}");
//            data.PhotoFile.SaveAs(filePath);

//            if (ModelState.IsValid)
//            {

//                db.Services.Add(service);
//                db.SaveChanges();

//                var newService = mapper.Map<Service>(data);
//                int creationResult = service_Service.Create(newService);

//                if (creationResult == -2)
//                {
//                    ViewBag.Message = "Service Name is exists";
//                    return View(data);
//                }

//                return RedirectToAction("Index");


//            }
//            return View();


//        }
//        [HttpGet]
//        public ActionResult Edit(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return RedirectToAction("index", "Home");
//            }

//            var currentService = service_Service.ReadById(id.Value);
//            if (currentService == null)
//            {
//                return HttpNotFound($"This service ({id}) not found");
//            }
//            var serviceModel = mapper.Map<ServiceModel>(currentService);

//            {
//                Id = currentService.Id,
//                Name = currentService.Name,
//                Description = currentService.Description,
//                NormalPrice = currentService.NormalPrice,
//                NormalHour = currentService.NormalHour,
//                FastPrice = currentService.FastPrice,
//                FastHour = currentService.FastHour,
//                Photo = currentService.Photo,
//                Sale = currentService.Sale
//            };
//            return View(serviceModel);
//        }
//        [HttpPost]
//        public ActionResult Edit(ServiceModel data)
//        {
//            if (ModelState.IsValid)
//            {
//                var updatedService = mapper.Map<Service>(data);
//                {
//                    Id = data.Id,
//                    Name = data.Name,
//                    Description = data.Description,
//                    NormalPrice = data.NormalPrice,
//                    NormalHour = data.NormalHour,
//                    FastPrice = data.FastPrice,
//                    FastHour = data.FastHour,
//                    Photo = data.Photo
//                };
//                var result = service_Service.Update(updatedService);

//                if (result == -2)
//                {
//                    ViewBag.Message = "Service Name is exists";
//                    return View(data);
//                }
//                else if (result > 0)
//                {
//                    ViewBag.Success = true;
//                    ViewBag.Message = $"Service ({data.Id}) updated successfully.";
//                }
//                else
//                {
//                    ViewBag.Message = $"An error occured!";
//                }
//            }
//            return View(data);
//        }


//        public ActionResult Delete(int? Id)
//        {
//            if (Id != null)
//            {
//                var service = service_Service.ReadById(Id.Value);
//                var serviceInfo = mapper.Map<ServiceModel>(service);
//                {
//                    Id = service.Id,
//                    Name = service.Name,
//                    Description = service.Description,
//                    NormalPrice = service.NormalPrice,
//                    NormalHour = service.NormalHour,
//                    FastPrice = service.FastPrice,
//                    FastHour = service.FastHour,
//                    Photo = service.Photo
//                };
//                return View(serviceInfo);
//            }
//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        public ActionResult DeleteConfirmed(int? Id)
//        {
//            if (Id != null)
//            {
//                var deleted = service_Service.Delete(Id.Value);
//                if (deleted)
//                {
//                    return RedirectToAction("Index");
//                }
//                return RedirectToAction("Delete", new { Id = Id });
//            }
//            return HttpNotFound();
//        }
//    }
//}
