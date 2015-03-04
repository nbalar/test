using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    
    public class TestimonailModel
    {
        public List<Testimonial> testimonialList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditTestimonailModel
    {
        public Int64 TestimonialId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
