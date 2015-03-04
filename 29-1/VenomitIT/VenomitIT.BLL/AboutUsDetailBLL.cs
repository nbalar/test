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
    public class AboutUsDetailBLL
    {
        public static List<AboutUsDetail> Getaboutuscontentlist(Int64 aboutId)
        {
            return AboutUsDetailDAL.Getaboutuscontentlist(aboutId);
        }

        public static void SaveAboutcontentDetails(EditAboutDetailsModel editAboutDetailsModel)
        {
            AboutUsDetailDAL.SaveAboutcontentDetails(editAboutDetailsModel);
        }

        public static EditAboutDetailsModel getaboutusDetailsById(Int64 aboutDetailsId)
        {
            EditAboutDetailsModel editAboutDetailsModel = new EditAboutDetailsModel();
            AboutUsDetail entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.AboutUsDetails.Where(sp => sp.AboutDetailsId == aboutDetailsId) select p).SingleOrDefault();
            }
            editAboutDetailsModel.AboutId = entity.AboutId;
            editAboutDetailsModel.Title = entity.Title;
            editAboutDetailsModel.Description = entity.Description;
            editAboutDetailsModel.AboutImage = entity.AboutImage;
            editAboutDetailsModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editAboutDetailsModel;
        }
        public static Boolean DeleteAboutusContent(Int64 aboutDetailsId)
        {
            return AboutUsDetailDAL.DeleteAboutusContent(aboutDetailsId);
        }
    }
}
