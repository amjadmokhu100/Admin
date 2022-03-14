using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperHelp.Models;
using PaperHelp.Orders;

namespace PaperHelp.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {


        private readonly IMapper mapper;
        private readonly OrderService orderService;
        // GET: Admin/Order

        public OrderController()
        {

            mapper = AutoMapperConfig.Mapper;
            orderService = new OrderService();
        }
        public ActionResult Index()
        {
            var orderList =  orderService.ReadAll();
            var mappedOrderList = mapper.Map<List<OrderModel>>(orderList);
            return View(mappedOrderList);
        }


        public ActionResult PindingForAdminStatusView(int? Id)
        {

            if (Id != null)
            {
                var order = orderService.ReadById(Id.Value);
                var orderInfo = mapper.Map<OrderModel>(order);

                return View(orderInfo);
            }
            return RedirectToAction("Index");
        }


    }
}