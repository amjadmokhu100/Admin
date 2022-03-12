using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test3.Models;

namespace test3.Orders
{
    public interface IOrderService
    {
       
        List<Order> ReadAll();
        Order Get(int Id);
        Order ReadById(int id);

    }
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext db;

        public OrderService()
        {
            db = new ApplicationDbContext();

        }

        public Order Get(int Id)
        {
            return db.Orders.Find(Id);
        }

        public List<Order> ReadAll()
        {

            return db.Orders.ToList();

        }

        public Order ReadById(int id)
        {
            return db.Orders.Find(id);
        }
    }


}