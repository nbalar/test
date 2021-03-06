﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{

    public class ServiceModel
    {
        public List<Service> serviceList { get; set; }
        public Int64 DomainId { get; set; }
    }
    public class EditServiceModel
    {
        public Int64 ServiceId { get; set; }
        public Int64 DomainId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
