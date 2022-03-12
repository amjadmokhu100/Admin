using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test3.Models;
using test3.Orders;

namespace test3.Areas.Admin.Controllers
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

  

     
    }
}