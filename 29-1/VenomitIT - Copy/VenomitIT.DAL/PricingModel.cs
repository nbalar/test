using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class PricingModel
    {
        public List<Pricing_Master> pricingList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditPricingModel
    {
        public Int64 PricingId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class PricingDetailsModel
    {
        public List<PricingDetail> pricingdetailsList { get; set; }
        public Int64 PricingId { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditPricingDetailsModel
    {
        public Int64 PricingDetailsId { get; set; }
        public Int64 PricingId { get; set; }
        public Int64 DomainId { get; set; }      

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

}
