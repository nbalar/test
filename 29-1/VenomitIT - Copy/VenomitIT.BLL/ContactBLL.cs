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
    public class ContactBLL
    {
        public static List<ContactDetail> Getcontactlist(Int64 domainId)
        {
            return ContactDAL.Getcontactlist(domainId);
        }
        public static void SaveContactDetails(EditContactModel editContactModel)
        {
            ContactDAL.SaveContactDetails(editContactModel);
        }
        public static EditContactModel getContactById(Int64 contactId)
        {
            EditContactModel editContactModel = new EditContactModel();
            ContactDetail entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.ContactDetails.Where(sp => sp.ContactId == contactId) select p).SingleOrDefault();
            }
            editContactModel.ContactId = entity.ContactId;
            editContactModel.DomainId = entity.DomainId;
            editContactModel.Description = entity.Description;
            editContactModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editContactModel;
;
        }
        public static Boolean DeleteContactDetails(Int64 contactId)
        {
            return ContactDAL.DeleteContactDetails(contactId);
        }
    }
}
