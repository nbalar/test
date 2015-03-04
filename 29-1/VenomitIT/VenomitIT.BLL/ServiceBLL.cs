using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VenomitIT.DAL;
using VenomitIT.BLL;
using VenomitIT.Common;


namespace VenomitIT.BLL
{
    public class ServiceBLL
    {
        public static List<Service> Getserviceslist(Int64 domainId)
        {
            return ServiceDAL.Getserviceslist(domainId);
        }
        public static void SaveServiceDetails(EditServiceModel editServiceModel)
        {
            ServiceDAL.SaveServiceDetails(editServiceModel);
        }
        public static EditServiceModel getServiceById(Int64 serviceId)
        {
            EditServiceModel editServiceModel = new EditServiceModel();
            Service entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.Services.Where(sp => sp.ServiceId == serviceId) select p).SingleOrDefault();
            }
            editServiceModel.ServiceId = entity.ServiceId;
            editServiceModel.DomainId = entity.DomainId;
            editServiceModel.Title = entity.Title;
            editServiceModel.Description = entity.ServiceDescription;
            editServiceModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editServiceModel;
        }
        public static Boolean DeleteServices(Int64 serviceId)
        {
            return ServiceDAL.DeleteServices(serviceId);
        }
    }
}
