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
   public class AboutUsBLL
    {
       public static List<AboutU> Getaboutlist(Int64 domainId)
        {
            return AboutUsDAL.Getaboutlist(domainId);
        }
       public static void SaveAboutusDetails(EditAboutUsModel editAboutUsModel)
        {
            AboutUsDAL.SaveAboutusDetails(editAboutUsModel);
        }
       public static EditAboutUsModel getAboutusById(Int64 aboutId)
        {
            EditAboutUsModel editAboutUsModel = new EditAboutUsModel();
            AboutU entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.AboutUs.Where(sp => sp.AboutId == aboutId) select p).SingleOrDefault();
            }
            editAboutUsModel.AboutId = entity.AboutId;
            editAboutUsModel.DomainId = entity.DomainId;
            editAboutUsModel.Title = entity.Title;
            editAboutUsModel.Description = entity.Description;
            editAboutUsModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editAboutUsModel;
        }
       public static Boolean DeleteAboutus(Int64 aboutId)
        {
            return AboutUsDAL.DeleteAboutus(aboutId);
        }
    }
}
