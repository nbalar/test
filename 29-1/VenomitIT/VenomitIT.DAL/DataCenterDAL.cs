using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class DataCenterDAL : BaseDAL<DataCenter>
    {
        public static List<DataCenter> Getdatalist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<DataCenter> dataList = new List<DataCenter>();
                dataList = dbModel.DataCenters.Where(x => x.DomainId == domainId).ToList();
                return dataList;
            }
        }
        public static void SaveDataCeneterDetails(EditDataCenterModel editDataCenterModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                DataCenter entity;
                if (editDataCenterModel.DataCenterId == 0)
                {
                    entity = dbModel.DataCenters.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.DataCenters.Where(a => a.DataCenterId == editDataCenterModel.DataCenterId)
                              select a).FirstOrDefault<DataCenter>();
                }
                entity.DomainId = Convert.ToInt32(editDataCenterModel.DomainId);
                entity.Title = editDataCenterModel.Title;
                entity.DataCenterDescription = editDataCenterModel.Description;
                entity.IsActive = editDataCenterModel.IsActive;

                if (editDataCenterModel.DataCenterId == 0)
                {
                    dbModel.DataCenters.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteDataCenter(Int64 dataCenterId)
        {
            DataCenter dataCenter = EntityModel.DataCenters.Where(x => x.DataCenterId == dataCenterId).FirstOrDefault();
            if (dataCenter != null)
            {
                DataCenterDAL.Delete(dataCenter);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
