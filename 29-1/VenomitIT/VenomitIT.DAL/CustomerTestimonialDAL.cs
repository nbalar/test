using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class CustomerTestimonialDAL : BaseDAL<CustomerTestimonail>
    {
        public static List<CustomerTestimonail> GetCustomertestimoniallist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<CustomerTestimonail> customertestimonialList = new List<CustomerTestimonail>();
                customertestimonialList = dbModel.CustomerTestimonails.Where(x => x.DomainId == domainId).ToList();
                return customertestimonialList;
            }
        }

        public static void SaveCustomertestimonialDetails(EditCustomerTestimonialModel editCustomeTesatimonialModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                CustomerTestimonail entity;
                if (editCustomeTesatimonialModel.CustomerId == 0)
                {
                    entity = dbModel.CustomerTestimonails.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.CustomerTestimonails.Where(a => a.CustomerId == editCustomeTesatimonialModel.CustomerId)
                              select a).FirstOrDefault<CustomerTestimonail>();
                }
                entity.DomainId = Convert.ToInt32(editCustomeTesatimonialModel.DomainId);
                entity.Description = editCustomeTesatimonialModel.Description;
                entity.IsActive = editCustomeTesatimonialModel.IsActive;
                if (editCustomeTesatimonialModel.ImagePath != null && editCustomeTesatimonialModel.ImagePath != String.Empty)
                {
                    entity.CustomerImage = editCustomeTesatimonialModel.ImagePath;
                }
                if (editCustomeTesatimonialModel.CustomerId == 0)
                {
                    dbModel.CustomerTestimonails.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteCustomerTestimonial(Int64 customerId)
        {
            CustomerTestimonail customerTestimonail = EntityModel.CustomerTestimonails.Where(x => x.CustomerId == customerId).FirstOrDefault();
            if (customerTestimonail != null)
            {
                CustomerTestimonialDAL.Delete(customerTestimonail);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
