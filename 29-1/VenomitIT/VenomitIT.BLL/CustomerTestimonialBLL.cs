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
    public class CustomerTestimonialBLL
    {
        public static List<CustomerTestimonail> GetCustomertestimoniallist(Int64 domainId)
        {
            return CustomerTestimonialDAL.GetCustomertestimoniallist(domainId);
        }
        public static void SaveCustomertestimonialDetails(EditCustomerTestimonialModel editCustomeTesatimonialModel)
        {
            CustomerTestimonialDAL.SaveCustomertestimonialDetails(editCustomeTesatimonialModel);
        }
        public static EditCustomerTestimonialModel getCustomerTestimonialById(Int64 customerId)
        {
            EditCustomerTestimonialModel editCustomeTesatimonialModel = new EditCustomerTestimonialModel();
            CustomerTestimonail entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.CustomerTestimonails.Where(sp => sp.CustomerId == customerId) select p).SingleOrDefault();
            }
            editCustomeTesatimonialModel.CustomerId = entity.CustomerId;            
            editCustomeTesatimonialModel.DomainId = entity.DomainId;
            editCustomeTesatimonialModel.Description = entity.Description;
            editCustomeTesatimonialModel.ImagePath = entity.CustomerImage;
            editCustomeTesatimonialModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editCustomeTesatimonialModel;
        }
        public static Boolean DeleteCustomerTestimonial(Int64 customerId)
        {
            return CustomerTestimonialDAL.DeleteCustomerTestimonial(customerId);
        }
    }
}
