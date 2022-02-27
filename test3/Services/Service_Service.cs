using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test3.Data;

namespace test3.Services
{
    public interface IService_Service
    {
        bool Delete(int id);
        int Update(Service updatedService);
        Service ReadById(int id);
        List<Service> ReadAll();
        int Create(Service newService);
    }
    public class Service_Service : IService_Service

    {

        private readonly PaperHelpDbEntities db;
        public Service_Service()
        {
            db = new PaperHelpDbEntities();
        }

        public int Create(Service newService)
        {
            var serviceName = newService.Name.ToLower();
           var serviceNameExists =  db.Services.Where(c => c.Name.ToLower() == serviceName).Any();
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
            if(service != null)
            {
                db.Services.Remove(service);
                return db.SaveChanges() > 0 ? true : false;
            }
            return false;
        }

        public List<Service> ReadAll()
        {
          return  db.Services.ToList();
        }

        public Service ReadById(int id)
        {
            return db.Services.Find(id);
        }

        public int Update(Service updatedService)
        {
            var serviceName = updatedService.Name.ToLower();
            var serviceNameExists = db.Services.Where(c => c.Name.ToLower() == serviceName).Any();
            if (serviceNameExists)
            {
                return -2;
            }
            db.Services.Attach(updatedService);
            db.Entry(updatedService).State = System.Data.Entity.EntityState.Modified;
          return  db.SaveChanges();
        }
    }
}