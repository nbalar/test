using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class WhyWeDAL : BaseDAL<WhyWe>
    {
        public static List<WhyWe> Getwhywelist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<WhyWe> whyweList = new List<WhyWe>();
                whyweList = dbModel.WhyWes.Where(x => x.DomainId == domainId).ToList();
                return whyweList;
            }
        }
        public static void SaveWhyWeDetails(EditWhyWeModel editWhyWeModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                WhyWe entity;
                if (editWhyWeModel.WhyWeId == 0)
                {
                    entity = dbModel.WhyWes.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.WhyWes.Where(a => a.Id == editWhyWeModel.WhyWeId)
                              select a).FirstOrDefault<WhyWe>();
                }
                entity.DomainId = Convert.ToInt32(editWhyWeModel.DomainId);
                entity.Title = editWhyWeModel.Title;
                entity.Description = editWhyWeModel.Description;
                entity.IsActive = editWhyWeModel.IsActive;
                if (editWhyWeModel.WhyWeId == 0)
                {
                    dbModel.WhyWes.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteWhywe(Int64 whyweId)
        {
            WhyWe whyWe = EntityModel.WhyWes.Where(x => x.Id == whyweId).FirstOrDefault();
            if (whyWe != null)
            {
                WhyWeDAL.Delete(whyWe);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
