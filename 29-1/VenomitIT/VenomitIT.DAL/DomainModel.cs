using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class DomainModel
    {
        public List<Domain_Master> domainList { get; set; }

    }

    public class EditDomainModel
    {
        [Display(Name = "DomainId")]
        public Int64 DomainId { get; set; }

        [Required(ErrorMessage = "Domain Name is required.")]
        public string DomainName { get; set; }

        [Required(ErrorMessage = "URL is required.")]
        public string DomainURL { get; set; }

        public bool IsActive { get; set; }
    }
}
