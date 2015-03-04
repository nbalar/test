using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class SliderModel
    {
        public List<Slider_Master> sliderList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditSliderModel
    {
        public Int64 SliderId { get; set; }
        public Int64 DomainId { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
    }

    //Slider Content
    public class SliderContentModel
    {
        public List<Slider_Details> slidercontentList { get; set; }
        public Int64 SliderId { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditSliderContentModel
    {
        public Int64 SliderDetailsId { get; set; }
        public Int64 SliderId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }

}
