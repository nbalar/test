using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class DataCenterDetailsDAL : BaseDAL<DataCenterDetail>
    {
        public static List<DataCenterDetail> Getdatacenterdetailslist(Int64 dataCenterId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<DataCenterDetail> datacentercontentList = new List<DataCenterDetail>();
                datacentercontentList = dbModel.DataCenterDetails.Where(x => x.DataCenterId == dataCenterId).ToList();
                return datacentercontentList;
            }
        }

        public static void SaveDataCenterDetails(EditDataCenterDetailsModel editDataCenterDetailsModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                DataCenterDetail entity;
                if (editDataCenterDetailsModel.DataDetailId == 0)
                {
                    entity = dbModel.DataCenterDetails.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.DataCenterDetails.Where(a => a.DataDetailId == editDataCenterDetailsModel.DataDetailId)
                              select a).FirstOrDefault<DataCenterDetail>();
                }
                entity.DataCenterId = Convert.ToInt32(editDataCenterDetailsModel.DataCenterId);
                entity.Description = editDataCenterDetailsModel.Description;
                entity.IsActive = editDataCenterDetailsModel.IsActive;
                if (editDataCenterDetailsModel.DataDetailId == 0)
                {
                    dbModel.DataCenterDetails.AddObject(entity);
                }
                dbModel.SaveChanges();
            }
        }

        public static Boolean DeleteDataCenterContent(Int64 dataDetailId)
        {
            DataCenterDetail datacenterdetails = EntityModel.DataCenterDetails.Where(x => x.DataDetailId == dataDetailId).FirstOrDefault();
            if (datacenterdetails != null)
            {
                DataCenterDetailsDAL.Delete(datacenterdetails);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
