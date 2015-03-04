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
    public class TestimonailBLL
    {
        public static List<Testimonial> Gettestimoniallist(Int64 domainId)
        {
            return TestimonailDAL.Gettestimoniallist(domainId);
        }
        public static void SaveTestimonialDetails(EditTestimonailModel editTestimonailModel)
        {
            TestimonailDAL.SaveTestimonialDetails(editTestimonailModel);
        }
        public static EditTestimonailModel gettestimonialById(Int64 testimonialId)
        {
            EditTestimonailModel editTestimonailModel = new EditTestimonailModel();
            Testimonial entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.Testimonials.Where(sp => sp.TestimonialId == testimonialId) select p).SingleOrDefault();
            }
            editTestimonailModel.TestimonialId = entity.TestimonialId;
            editTestimonailModel.DomainId = entity.DomainId;
            editTestimonailModel.Author = entity.Author;
            editTestimonailModel.Description = entity.Description;
            editTestimonailModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editTestimonailModel;
        }
        public static Boolean DeleteTestimonial(Int64 testimonialId)
        {
            return TestimonailDAL.DeleteTestimonial(testimonialId);
        }
    }
}
