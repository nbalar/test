using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{

    public class BackupModel
    {
        public List<Backup_Master> backupList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditBackupModel
    {
        public Int64 BackupId { get; set; }
        public Int64 DomainId { get; set; }
        public bool IsActive { get; set; }
        public string BackupImage { get; set; }
    }
}
