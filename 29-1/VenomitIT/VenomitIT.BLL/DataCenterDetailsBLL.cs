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
    public class DataCenterDetailsBLL
    {
        public static List<DataCenterDetail> Getdatacenterdetailslist(Int64 dataCenterId)
        {
            return DataCenterDetailsDAL.Getdatacenterdetailslist(dataCenterId);
        }

        public static void SaveDataCenterDetails(EditDataCenterDetailsModel editDataCeneterDetailsModel)
        {
            DataCenterDetailsDAL.SaveDataCenterDetails(editDataCeneterDetailsModel);
        }

        public static EditDataCenterDetailsModel getDataCenterDetailsById(Int64 dataDetailId)
        {
            EditDataCenterDetailsModel editDataCenterDetailsModel = new EditDataCenterDetailsModel();
            DataCenterDetail entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.DataCenterDetails.Where(sp => sp.DataDetailId == dataDetailId) select p).SingleOrDefault();
            }
            editDataCenterDetailsModel.DataCenterId = entity.DataCenterId;
            editDataCenterDetailsModel.Description = entity.Description;
            editDataCenterDetailsModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editDataCenterDetailsModel;
        }
        public static Boolean DeleteDataCenterContent(Int64 dataDetailId)
        {
            return DataCenterDetailsDAL.DeleteDataCenterContent(dataDetailId);
        }
    }
}
