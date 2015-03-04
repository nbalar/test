using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
   public class AboutUsDetailDAL: BaseDAL<AboutUsDetail>
    {
       public static List<AboutUsDetail> Getaboutuscontentlist(Int64 aboutId)
       {
           using (cms_venomitEntities dbModel = new cms_venomitEntities())
           {
               List<AboutUsDetail> aboutuscontentList = new List<AboutUsDetail>();
               aboutuscontentList = dbModel.AboutUsDetails.Where(x => x.AboutId == aboutId).ToList();
               return aboutuscontentList;
           }
       }

       public static void SaveAboutcontentDetails(EditAboutDetailsModel editAboutDetailsModel)
       {
           using (cms_venomitEntities dbModel = new cms_venomitEntities())
           {
               AboutUsDetail entity;
               if (editAboutDetailsModel.AboutDetailsId == 0)
               {
                   entity = dbModel.AboutUsDetails.CreateObject();
               }
               else
               {
                   entity = (from a in dbModel.AboutUsDetails.Where(a => a.AboutDetailsId == editAboutDetailsModel.AboutDetailsId)
                             select a).FirstOrDefault<AboutUsDetail>();
               }
               entity.AboutId = Convert.ToInt32(editAboutDetailsModel.AboutId);
               entity.Title = editAboutDetailsModel.Title;
               entity.Description = editAboutDetailsModel.Description;
               entity.IsActive = editAboutDetailsModel.IsActive;
               if (editAboutDetailsModel.AboutImage != null && editAboutDetailsModel.AboutImage != String.Empty)
               {
                   entity.AboutImage = editAboutDetailsModel.AboutImage;
               }
               if (editAboutDetailsModel.AboutDetailsId == 0)
               {
                   dbModel.AboutUsDetails.AddObject(entity);
               }
               dbModel.SaveChanges();
           }
       }

       public static Boolean DeleteAboutusContent(Int64 aboutDetailsId)
       {
           AboutUsDetail aboutusdetails = EntityModel.AboutUsDetails.Where(x => x.AboutDetailsId == aboutDetailsId).FirstOrDefault();
           if (aboutusdetails != null)
           {
               AboutUsDetailDAL.Delete(aboutusdetails);
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}
