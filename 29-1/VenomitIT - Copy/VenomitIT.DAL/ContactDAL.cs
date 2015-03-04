using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class ContactDAL : BaseDAL<ContactDetail>
    {
        public static List<ContactDetail> Getcontactlist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<ContactDetail> contactList = new List<ContactDetail>();
                contactList = dbModel.ContactDetails.Where(x => x.DomainId == domainId).ToList();
                return contactList;
            }
        }

        public static void SaveContactDetails(EditContactModel editContactModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                ContactDetail entity;
                if (editContactModel.ContactId == 0)
                {
                    entity = dbModel.ContactDetails.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.ContactDetails.Where(a => a.ContactId == editContactModel.ContactId)
                              select a).FirstOrDefault<ContactDetail>();
                }
                entity.DomainId = Convert.ToInt32(editContactModel.DomainId);
                entity.Description = editContactModel.Description;
                entity.IsActive = editContactModel.IsActive;

                if (editContactModel.ContactId == 0)
                {
                    dbModel.ContactDetails.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteContactDetails(Int64 contactId)
        {
            ContactDetail contactDetail = EntityModel.ContactDetails.Where(x => x.ContactId == contactId).FirstOrDefault();
            if (contactDetail != null)
            {
                ContactDAL.Delete(contactDetail);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
