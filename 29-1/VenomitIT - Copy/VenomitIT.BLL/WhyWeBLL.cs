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
    public class WhyWeBLL
    {
        public static List<WhyWe> Getwhywelist(Int64 domainId)
        {
            return WhyWeDAL.Getwhywelist(domainId);
        }
        public static void SaveWhyWeDetails(EditWhyWeModel editWhyWeModel)
        {
            WhyWeDAL.SaveWhyWeDetails(editWhyWeModel);
        }
        public static EditWhyWeModel getWhyweById(Int64 whyweId)
        {
            EditWhyWeModel editWhyWeModel = new EditWhyWeModel();
            WhyWe entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.WhyWes.Where(sp => sp.Id == whyweId) select p).SingleOrDefault();
            }
            editWhyWeModel.WhyWeId = entity.Id;
            editWhyWeModel.DomainId = entity.DomainId;
            editWhyWeModel.Title = entity.Title;
            editWhyWeModel.Description = entity.Description;
            editWhyWeModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editWhyWeModel;
        }
        public static Boolean DeleteWhywe(Int64 whyweId)
        {
            return WhyWeDAL.DeleteWhywe(whyweId);
        }
    }
}
