
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test3.Data;
using test3.Models;
using test3.Services;

namespace test3.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMapper mapper;
        private readonly Service_Service service_Service;
        public ServiceController()
        {
            mapper = AutoMapperConfig.Mapper;
            service_Service = new Service_Service();
        }
        public ActionResult Index()
        {
            var serviceList = service_Service.ReadAll();
            var mappedServiceList = mapper.Map<List<ServiceModel>>(serviceList);
            return View(mappedServiceList);

        }


        [HttpGet]
        public ActionResult Create()
        {
            var serviceModel = new ServiceModel();
            return View(serviceModel);

        }


        [HttpPost]
        public ActionResult Create(ServiceModel data)
        {

            //if (data.ImageFile == null || data.ImageFile.ContentLength == 0)
            //    return View(data);

            try
            {
                if (ModelState.IsValid)
                {

                    data.Photo = SaveImageFile(data.ImageFile);
                    var serviceDTO = mapper.Map<Service>(data);
                    int result = service_Service.Create(serviceDTO);
                    if(result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.Message = "An error occurred!";
                }
                return View(data);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(data);
            }

        }









        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
                return HttpNotFound();

            var currentServiceData = service_Service.Get(Id.Value);
            var serviceModel = mapper.Map<ServiceModel>(currentServiceData);
            return View(serviceModel);

        }


        [HttpPost]
        public ActionResult Edit(ServiceModel data)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    data.Photo = SaveImageFile(data.ImageFile, data.Photo);

                    var service= mapper.Map<Service>(data);
                     int result = service_Service.Update(service);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.Message = "An error occurred!";
                }
                return View(data);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(data);
            }

        }

        private string SaveImageFile(HttpPostedFileBase ImageFile, string currentPhoto="")
        {
           
            if (ImageFile != null)
            {

                //save new file
                var fileExtension = Path.GetExtension(ImageFile.FileName);
                var photoGuid = Guid.NewGuid().ToString();
                string Photo = photoGuid + fileExtension;
                // save file in upload / services file
                string filePath = Server.MapPath($"~/Upload/Services/{Photo}");


                ImageFile.SaveAs(filePath);


                //delete old file - update action

                if (!string.IsNullOrEmpty(currentPhoto))
                {
                    string oldFilePath = Server.MapPath($"~/Upload/Services/{currentPhoto}");
                    System.IO.File.Delete(oldFilePath);
                }

                return Photo;
            }
            return currentPhoto;

        }



        public ActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                var service = service_Service.ReadById(Id.Value);
                var serviceInfo = mapper.Map<ServiceModel>(service);

                return View(serviceInfo);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult DeleteConfirmed(int? Id)
        {
            if (Id != null)
            {
                var deleted = service_Service.Delete(Id.Value);
                if (deleted)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Delete", new { Id = Id });
            }
            return HttpNotFound();
        }

    }

}
