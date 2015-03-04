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
    public class DataCenterBLL
    {
        public static List<DataCenter> Getdatalist(Int64 domainId)
        {
            return DataCenterDAL.Getdatalist(domainId);
        }
        public static void SaveDataCeneterDetails(EditDataCenterModel editDataCenterModel)
        {
            DataCenterDAL.SaveDataCeneterDetails(editDataCenterModel);
        }
        public static EditDataCenterModel getDataCenterById(Int64 dataCenterId)
        {
            EditDataCenterModel editDataCenterModel = new EditDataCenterModel();
            DataCenter entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.DataCenters.Where(sp => sp.DataCenterId == dataCenterId) select p).SingleOrDefault();
            }
            editDataCenterModel.DataCenterId = entity.DataCenterId;
            editDataCenterModel.DomainId = entity.DomainId;
            editDataCenterModel.Title = entity.Title;
            editDataCenterModel.Description = entity.DataCenterDescription;
            editDataCenterModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editDataCenterModel;
        }
        public static Boolean DeleteDataCenter(Int64 dataCenterId)
        {
            return DataCenterDAL.DeleteDataCenter(dataCenterId);
        }
    }
}
