using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class PricingDAL : BaseDAL<Pricing_Master>
    {
        public static List<Pricing_Master> Getpricinglist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<Pricing_Master> pricingList = new List<Pricing_Master>();
                pricingList = dbModel.Pricing_Master.Where(x => x.DomainId == domainId).ToList();
                return pricingList;
            }
        }
        public static void SavePricingDetails(EditPricingModel editPricingModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                Pricing_Master entity;
                if (editPricingModel.PricingId == 0)
                {
                    entity = dbModel.Pricing_Master.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.Pricing_Master.Where(a => a.PricingId == editPricingModel.PricingId)
                              select a).FirstOrDefault<Pricing_Master>();
                }
                entity.DomainId = Convert.ToInt32(editPricingModel.DomainId);
                entity.Title = editPricingModel.Title;
                entity.PricingDescription = editPricingModel.Description;
                entity.IsActive = editPricingModel.IsActive;

                if (editPricingModel.PricingId == 0)
                {
                    dbModel.Pricing_Master.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeletePricing(Int64 pricingId)
        {
            Pricing_Master pricing_Master = EntityModel.Pricing_Master.Where(x => x.PricingId == pricingId).FirstOrDefault();
            if (pricing_Master != null)
            {
                PricingDAL.Delete(pricing_Master);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
