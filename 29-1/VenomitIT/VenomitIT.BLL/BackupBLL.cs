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
    public class BackupBLL
    {
        public static List<Backup_Master> Getbackuplist(Int64 domainId)
        {
            return BackupDAL.Getbackuplist(domainId);
        }
        public static void SaveBackupDetails(EditBackupModel editBackupModel)
        {
            BackupDAL.SaveBackupDetails(editBackupModel);
        }
        public static EditBackupModel getBackupById(Int64 backupId)
        {
            EditBackupModel editBackupModel = new EditBackupModel();
            Backup_Master entity;
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                entity = (from p in dbModel.Backup_Master.Where(sp => sp.BackupId == backupId) select p).SingleOrDefault();
            }
            editBackupModel.BackupId = entity.BackupId;
            editBackupModel.DomainId = entity.DomainId;
            editBackupModel.BackupImage = entity.BackupImage;
            editBackupModel.IsActive = Convert.ToBoolean(entity.IsActive);
            return editBackupModel;
        }
        public static Boolean DeleteBackupDetails(Int64 backupId)
        {
            return BackupDAL.DeleteBackupDetails(backupId);
        }
    }
}
