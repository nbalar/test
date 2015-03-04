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
    public class DomainBLL
    {

        public static List<Domain_Master> Getdomainlist()
        {
            return DomainDAL.Getdomainlist();
        }
        public static void SaveDomainDetails(EditDomainModel domainModel)
        {
            DomainDAL.SaveDomainDetails(domainModel);
        }


        //new Domain Register Email
        public static void SendRegisterDomainEmail(EditDomainModel model, Controller controller)
        {
           Int32 userid=Convert.ToInt32(CookieHelper.UserID);
           User_Master usermaster = UserDAL.GetUserById(userid);
            StringBuilder emailBody = new StringBuilder();
            emailBody.AppendLine("Hi  " + CookieHelper.Fullname);
            emailBody.AppendLine("<br /> Latest Domain Addedd in our CMS");
            emailBody.AppendLine("<br /> Domain Name : " + model.DomainName);
            emailBody.AppendLine("<br /> Domain URL : " + model.DomainURL);
            emailBody.AppendLine("<br /> Thanks & Regards  <br /> VenomIT");
            EmailUtility.SendEmail(ConfigHelper.AdminEmailID, usermaster.Email, String.Empty, String.Empty, "New Domain Registration", emailBody.ToString(), true, null);
        }
        public static Boolean DeleteDomains(Int64 domainId)
        {
            return DomainDAL.DeleteDomains(domainId);
        }

        public static EditDomainModel getDomainDetailsById(Int64 domainId)
        {
            EditDomainModel domainModel = new EditDomainModel();
            Domain_Master entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.Domain_Master.Where(sp => sp.DomainId == domainId) select p).SingleOrDefault();
            }
            domainModel.DomainId = entity.DomainId;
            domainModel.DomainName = entity.DomainName;
            domainModel.DomainURL = entity.DomainURL;
            domainModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return domainModel;
        }
    }
}
