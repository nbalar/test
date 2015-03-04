using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class BackupDAL : BaseDAL<Backup_Master>
    {
        public static List<Backup_Master> Getbackuplist(Int64 domainId)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                List<Backup_Master> backuplist = new List<Backup_Master>();
                backuplist = dbModel.Backup_Master.Where(x => x.DomainId == domainId).ToList();
                return backuplist;
            }
        }

        public static void SaveBackupDetails(EditBackupModel editBackupModel)
        {
            using (cms_venomitEntities dbModel = new cms_venomitEntities())
            {
                Backup_Master entity;
                if (editBackupModel.BackupId == 0)
                {
                    entity = dbModel.Backup_Master.CreateObject();
                }
                else
                {
                    entity = (from a in dbModel.Backup_Master.Where(a => a.BackupId == editBackupModel.BackupId)
                              select a).FirstOrDefault<Backup_Master>();
                }
                entity.DomainId = Convert.ToInt32(editBackupModel.DomainId);
                entity.IsActive = editBackupModel.IsActive;
                if (editBackupModel.BackupImage != null && editBackupModel.BackupImage != String.Empty)
                {
                    entity.BackupImage = editBackupModel.BackupImage;
                }
                if (editBackupModel.BackupId == 0)
                {
                    dbModel.Backup_Master.AddObject(entity);
                }
                dbModel.SaveChanges();

            }
        }

        public static Boolean DeleteBackupDetails(Int64 backupId)
        {
            Backup_Master backupmaster = EntityModel.Backup_Master.Where(x => x.BackupId == backupId).FirstOrDefault();
            if (backupmaster != null)
            {
                BackupDAL.Delete(backupmaster);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
