using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class DomainDAL : BaseDAL<Domain_Master>
    {

        public static List<Domain_Master> Getdomainlist()
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<Domain_Master> domainList = new List<Domain_Master>();
                domainList = dbModel.Domain_Master.ToList();

                return domainList;
            }
        }
        public static void SaveDomainDetails(EditDomainModel domainmodel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                Domain_Master entity;
                if (domainmodel.DomainId == 0)
                {
                    entity = dbModel.Domain_Master.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.Domain_Master.Where(a => a.DomainId == domainmodel.DomainId)
                              select a).FirstOrDefault<Domain_Master>();
                }
                entity.DomainName = domainmodel.DomainName;
                entity.DomainURL = domainmodel.DomainURL;
                entity.IsActive = domainmodel.IsActive;
                if (domainmodel.DomainId == 0)
                {
                    dbModel.Domain_Master.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }
        public static Domain_Master GetdomainDetailById(long domainId)
        {
            return EntityModel.Domain_Master.FirstOrDefault(x => x.DomainId == domainId);
        }
        public static Boolean DeleteDomains(Int64 domainId)
        {
            Domain_Master domainMaster = EntityModel.Domain_Master.Where(x => x.DomainId == domainId).FirstOrDefault();
            if (domainMaster != null)
            {
                DomainDAL.Delete(domainMaster);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
