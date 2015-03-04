using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{

    public class DataCenterModel
    {
        public List<DataCenter> dataceneterList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditDataCenterModel
    {
        public Int64 DataCenterId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    //Slider Content
    public class DataCenterDetailsModel
    {
        public List<DataCenterDetail> dataceneterdetailsList { get; set; }
        public Int64 DataCenterId { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditDataCenterDetailsModel
    {
        public Int64 DataDetailId { get; set; }
        public Int64 DataCenterId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
