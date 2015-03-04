using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class ContactModel
    {
        public List<ContactDetail> contactList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditContactModel
    {
        public Int64 ContactId { get; set; }
        public Int64 DomainId { get; set; }     

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
