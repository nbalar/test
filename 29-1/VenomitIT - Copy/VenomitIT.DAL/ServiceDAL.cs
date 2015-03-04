using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class ServiceDAL : BaseDAL<Service>
    {
        public static List<Service> Getserviceslist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<Service> serviceList = new List<Service>();
                serviceList = dbModel.Services.Where(x => x.DomainId == domainId).ToList();
                return serviceList;
            }
        }
        public static void SaveServiceDetails(EditServiceModel editServiceModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                Service entity;
                if (editServiceModel.ServiceId == 0)
                {
                    entity = dbModel.Services.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.Services.Where(a => a.ServiceId == editServiceModel.ServiceId)
                              select a).FirstOrDefault<Service>();
                }
                entity.DomainId = Convert.ToInt32(editServiceModel.DomainId);
                entity.Title = editServiceModel.Title;
                entity.ServiceDescription = editServiceModel.Description;
                entity.IsActive = editServiceModel.IsActive;

                if (editServiceModel.ServiceId == 0)
                {
                    dbModel.Services.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteServices(Int64 serviceId)
        {
            Service services = EntityModel.Services.Where(x => x.ServiceId == serviceId).FirstOrDefault();
            if (services != null)
            {
                ServiceDAL.Delete(services);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
