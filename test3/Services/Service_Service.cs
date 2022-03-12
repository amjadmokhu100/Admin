using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test3.Models;

namespace test3.Services
{

    public interface IService_Service
    {
        int Create(Service newService);
        bool Delete(int id);


        List<Service> ReadAll();
        Service Get(int Id);
                Service ReadById(int id);

        int Update(Service updatedService);
    }
    public class Service_Service : IService_Service

    {

        private readonly ApplicationDbContext db;
        public Service_Service()
        {
            db = new ApplicationDbContext();
        }

        public int Create(Service newService)
        {
            var serviceName = newService.Name.ToLower();
            var serviceNameExists = db.Services.Where(c => c.Name.ToLower() == serviceName).Any();
            if (serviceNameExists)
            {
                return -2;
            }
            db.Services.Add(newService);
            return db.SaveChanges();
        }


        public bool Delete(int id)
        {
            var service = ReadById(id);
            if (service != null)
            {
                db.Services.Remove(service);
                return db.SaveChanges() > 0 ? true : false;
            }
            return false;
        }

        public Service ReadById(int id)
        {
            return db.Services.Find(id);
        }

        public Service Get(int Id)
        {
            return db.Services.Find(Id);
        }

        public List<Service> ReadAll()
        {
            return db.Services.ToList();      
        }

        public int Update(Service updatedService)
        {
            db.Services.Attach(updatedService);
            db.Entry(updatedService).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}