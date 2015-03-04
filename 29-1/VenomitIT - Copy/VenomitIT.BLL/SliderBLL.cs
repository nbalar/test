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
    public class SliderBLL
    {
        public static List<Slider_Master> Getsliderlist(Int64 domainId)
        {
            return SliderDAL.Getsliderlist(domainId);
        }
        public static void SaveSliderDetails(EditSliderModel editSliderModel)
        {
            SliderDAL.SaveSliderDetails(editSliderModel);
        }
        public static EditSliderModel getSliderById(Int64 sliderId)
        {
            EditSliderModel editSliderModel = new EditSliderModel();
            Slider_Master entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.Slider_Master.Where(sp => sp.SliderId == sliderId) select p).SingleOrDefault();
            }
            editSliderModel.SliderId = entity.SliderId;
            editSliderModel.DomainId = entity.DomainId;
            editSliderModel.ImagePath = entity.SliderImage;
            editSliderModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editSliderModel;
        }
        public static Boolean DeleteSlider(Int64 sliderId)
        {
            return SliderDAL.DeleteSlider(sliderId);
        }
    }
}
