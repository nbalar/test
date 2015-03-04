using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class AboutUsModel
    {
        public List<AboutU> aboutList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditAboutUsModel
    {
        public Int64 AboutId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    //Slider Content
    public class AboutDetailsModel
    {
        public List<AboutUsDetail> aboutusdetailsList { get; set; }
        public Int64 AboutId { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditAboutDetailsModel
    {
        public Int64 AboutDetailsId { get; set; }
        public Int64 AboutId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public string AboutImage { get; set; }

        public bool IsActive { get; set; }
    }
}
