using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class PricingDetailsDAL : BaseDAL<PricingDetail>
    {
        public static List<PricingDetail> Getpricingdetailslist(Int64 pricingId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<PricingDetail> pricingcontentList = new List<PricingDetail>();
                pricingcontentList = dbModel.PricingDetails.Where(x => x.PricingId == pricingId).ToList();
                return pricingcontentList;
            }
        }

        public static void SavePricingDetails(EditPricingDetailsModel editPricingDetailsModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                PricingDetail entity;
                if (editPricingDetailsModel.PricingDetailsId == 0)
                {
                    entity = dbModel.PricingDetails.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.PricingDetails.Where(a => a.PricingDetailsId == editPricingDetailsModel.PricingDetailsId)
                              select a).FirstOrDefault<PricingDetail>();
                }
                entity.PricingId = Convert.ToInt32(editPricingDetailsModel.PricingId);            
                entity.Description = editPricingDetailsModel.Description;
                entity.IsActive = editPricingDetailsModel.IsActive;
                if (editPricingDetailsModel.PricingDetailsId == 0)
                {
                    dbModel.PricingDetails.AddObject(entity);
                }
                dbModel.SaveChanges();
            }
        }

        public static Boolean DeletePricingContent(Int64 pricingDetailsId)
        {
            PricingDetail pricingdetails = EntityModel.PricingDetails.Where(x => x.PricingDetailsId == pricingDetailsId).FirstOrDefault();
            if (pricingdetails != null)
            {
                PricingDetailsDAL.Delete(pricingdetails);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
