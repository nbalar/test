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
    public class SliderContentBLL
    {
        public static List<Slider_Details> Getslidercontentlist(Int64 sliderId)
        {
            return SliderContentDAL.Getslidercontentlist(sliderId);
        }
        public static void SaveSlidercontentDetails(EditSliderContentModel editSliderContentModel)
        {
            SliderContentDAL.SaveSlidercontentDetails(editSliderContentModel);
        }

        public static EditSliderContentModel getSliderDetailsById(Int64 sliderDetailsId)
        {
            EditSliderContentModel editSlidercontentModel = new EditSliderContentModel();
            Slider_Details entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.Slider_Details.Where(sp => sp.SliderDetailsId == sliderDetailsId) select p).SingleOrDefault();
            }
            editSlidercontentModel.SliderId = entity.SliderId;
            editSlidercontentModel.Title = entity.Title;
            editSlidercontentModel.Description = entity.Description;
            editSlidercontentModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editSlidercontentModel;
        }
        public static Boolean DeleteSliderContent(Int64 sliderDetailsId)
        {
            return SliderContentDAL.DeleteSliderContent(sliderDetailsId);
        }
    }
}
