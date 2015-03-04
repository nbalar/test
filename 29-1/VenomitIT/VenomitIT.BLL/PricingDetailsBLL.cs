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
   public class PricingDetailsBLL
    {
       public static List<PricingDetail> Getpricingdetailslist(Int64 pricingId)
        {
            return PricingDetailsDAL.Getpricingdetailslist(pricingId);
        }

       public static void SavePricingDetails(EditPricingDetailsModel editPricingDetailsModel)
        {
            PricingDetailsDAL.SavePricingDetails(editPricingDetailsModel);
        }

       public static EditPricingDetailsModel getPricingDetailsById(Int64 pricingDetailsId)
        {
            EditPricingDetailsModel editPricingDetailsModel = new EditPricingDetailsModel();
            PricingDetail entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.PricingDetails.Where(sp => sp.PricingDetailsId == pricingDetailsId) select p).SingleOrDefault();
            }
            editPricingDetailsModel.PricingId = entity.PricingId;        
            editPricingDetailsModel.Description = entity.Description;
            editPricingDetailsModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editPricingDetailsModel;
        }
       public static Boolean DeletePricingContent(Int64 pricingDetailsId)
        {
            return PricingDetailsDAL.DeletePricingContent(pricingDetailsId);
        }
    }
}
