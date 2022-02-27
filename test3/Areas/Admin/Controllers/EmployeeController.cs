using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test3.Data;
using test3.Models;
using test3.Services;

namespace test3.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeController()
        {
            employeeService = new EmployeeService();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeData)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var employeeDTO = mapper.Map<Employee>(employeeData);
                    int result = employeeService.Create(employeeDTO);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");

                    }
                    else if (result == -2)
                    {

                        ViewBag.Message = "An already exists employee with this email!";
                    }
                    else
                    {

                        ViewBag.Message = "An error occurred!";
                    }
                }
                return View(employeeData);

            }
            catch(Exception ex)
            {
                ViewBag.Message =ex.Message;

                return View(employeeData);
            }
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
