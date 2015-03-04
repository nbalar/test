using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class CustomerTestimonialModel
    {
        public List<CustomerTestimonail> custometestimonailList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditCustomerTestimonialModel
    {
        public Int64 CustomerId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
    }
}
