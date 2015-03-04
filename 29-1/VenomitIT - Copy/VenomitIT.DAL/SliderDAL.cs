using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class SliderDAL : BaseDAL<Slider_Master>
    {
        public static List<Slider_Master> Getsliderlist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<Slider_Master> sliderList = new List<Slider_Master>();
                sliderList = dbModel.Slider_Master.Where(x=>x.DomainId==domainId).ToList();
                return sliderList;
            }
        }
        public static void SaveSliderDetails(EditSliderModel editSliderModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                Slider_Master entity;
                if (editSliderModel.SliderId == 0)
                {
                    entity = dbModel.Slider_Master.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.Slider_Master.Where(a => a.SliderId == editSliderModel.SliderId)
                              select a).FirstOrDefault<Slider_Master>();
                }
                entity.DomainId = Convert.ToInt32(editSliderModel.DomainId);
                entity.IsActive = editSliderModel.IsActive;
                if (editSliderModel.ImagePath != null && editSliderModel.ImagePath != String.Empty)
                {
                    entity.SliderImage = editSliderModel.ImagePath;
                }
                if (editSliderModel.SliderId == 0)
                {
                    dbModel.Slider_Master.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteSlider(Int64 sliderId)
        {
            Slider_Master sliderMaster = EntityModel.Slider_Master.Where(x => x.SliderId == sliderId).FirstOrDefault();
            if (sliderMaster != null)
            {
                SliderDAL.Delete(sliderMaster);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
