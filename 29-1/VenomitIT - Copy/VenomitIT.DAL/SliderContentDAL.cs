using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class SliderContentDAL : BaseDAL<Slider_Details>
    {
        public static List<Slider_Details> Getslidercontentlist(Int64 sliderId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<Slider_Details> slidercontentList = new List<Slider_Details>();
                slidercontentList = dbModel.Slider_Details.Where(x => x.SliderId == sliderId).ToList();
                return slidercontentList;
            }
        }
        public static void SaveSlidercontentDetails(EditSliderContentModel editSliderContentModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                Slider_Details entity;
                if (editSliderContentModel.SliderDetailsId == 0)
                {
                    entity = dbModel.Slider_Details.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.Slider_Details.Where(a => a.SliderDetailsId == editSliderContentModel.SliderDetailsId)
                              select a).FirstOrDefault<Slider_Details>();
                }
                entity.SliderId = Convert.ToInt32(editSliderContentModel.SliderId);
                entity.Title = editSliderContentModel.Title;
                entity.Description = editSliderContentModel.Description;
                entity.IsActive = editSliderContentModel.IsActive;
                if (editSliderContentModel.SliderDetailsId == 0)
                {
                    dbModel.Slider_Details.AddObject(entity);
                }
                dbModel.SaveChanges();
            }
        }

        public static Boolean DeleteSliderContent(Int64 sliderDetailsId)
        {
            Slider_Details sliderdetails = EntityModel.Slider_Details.Where(x => x.SliderDetailsId == sliderDetailsId).FirstOrDefault();
            if (sliderdetails != null)
            {
                SliderContentDAL.Delete(sliderdetails);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
