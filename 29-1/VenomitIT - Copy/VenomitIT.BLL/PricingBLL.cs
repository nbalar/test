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
    public class PricingBLL
    {
        public static List<Pricing_Master> Getpricinglist(Int64 domainId)
        {
            return PricingDAL.Getpricinglist(domainId);
        }
        public static void SavePricingDetails(EditPricingModel editPricingModel)
        {
            PricingDAL.SavePricingDetails(editPricingModel);
        }
        public static EditPricingModel getPricingById(Int64 pricingId)
        {
            EditPricingModel editPricingModel = new EditPricingModel();
            Pricing_Master entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.Pricing_Master.Where(sp => sp.PricingId == pricingId) select p).SingleOrDefault();
            }
            editPricingModel.PricingId = entity.PricingId;
            editPricingModel.DomainId = entity.DomainId;
            editPricingModel.Title = entity.Title;
            editPricingModel.Description = entity.PricingDescription;
            editPricingModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editPricingModel;
        }
        public static Boolean DeletePricing(Int64 pricingId)
        {
            return PricingDAL.DeletePricing(pricingId);
        }
    }
}

