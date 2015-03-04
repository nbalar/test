using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class TestimonailDAL : BaseDAL<Testimonial>
    {
        public static List<Testimonial> Gettestimoniallist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<Testimonial> testimonialList = new List<Testimonial>();
                testimonialList = dbModel.Testimonials.Where(x => x.DomainId == domainId).ToList();
                return testimonialList;
            }
        }
        public static void SaveTestimonialDetails(EditTestimonailModel editTestimonailModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                Testimonial entity;
                if (editTestimonailModel.TestimonialId == 0)
                {
                    entity = dbModel.Testimonials.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.Testimonials.Where(a => a.TestimonialId == editTestimonailModel.TestimonialId)
                              select a).FirstOrDefault<Testimonial>();
                }
                entity.DomainId = Convert.ToInt32(editTestimonailModel.DomainId);
                entity.Author = editTestimonailModel.Author;
                entity.Description = editTestimonailModel.Description;
                entity.IsActive = editTestimonailModel.IsActive;

                if (editTestimonailModel.TestimonialId == 0)
                {
                    dbModel.Testimonials.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteTestimonial(Int64 testimonialId)
        {
            Testimonial testimonial = EntityModel.Testimonials.Where(x => x.TestimonialId == testimonialId).FirstOrDefault();
            if (testimonial != null)
            {
                TestimonailDAL.Delete(testimonial);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
