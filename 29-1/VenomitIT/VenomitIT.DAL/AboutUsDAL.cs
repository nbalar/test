using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class AboutUsDAL : BaseDAL<AboutU>
    {
        public static List<AboutU> Getaboutlist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<AboutU> aboutList = new List<AboutU>();
                aboutList = dbModel.AboutUs.Where(x => x.DomainId == domainId).ToList();
                return aboutList;
            }
        }
        public static void SaveAboutusDetails(EditAboutUsModel editAboutUsModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                AboutU entity;
                if (editAboutUsModel.AboutId == 0)
                {
                    entity = dbModel.AboutUs.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.AboutUs.Where(a => a.AboutId == editAboutUsModel.AboutId)
                              select a).FirstOrDefault<AboutU>();
                }
                entity.DomainId = Convert.ToInt32(editAboutUsModel.DomainId);
                entity.Title = editAboutUsModel.Title;
                entity.Description = editAboutUsModel.Description;   
                entity.IsActive = editAboutUsModel.IsActive;
                if (editAboutUsModel.AboutId == 0)
                {
                    dbModel.AboutUs.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteAboutus(Int64 aboutId)
        {
            AboutU aboutus = EntityModel.AboutUs.Where(x => x.AboutId == aboutId).FirstOrDefault();
            if (aboutus != null)
            {
                AboutUsDAL.Delete(aboutus);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
