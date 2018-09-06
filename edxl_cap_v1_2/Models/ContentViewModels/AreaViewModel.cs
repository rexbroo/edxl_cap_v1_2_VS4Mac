using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using edxl_cap_v1_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace edxl_cap_v1_2.Models.ContentViewModels
{
    public class AreaViewModel
    {
        [Key]
        public int AreaIndex { get; set; }
        public int? SelectedAlertIndex { get; set; }
        [NotMapped]
        public List<SelectListItem> Alert_Identifiers { get; set; }
        public List<AreaVm> Areas { get; set; }
    }
    public class AreaVm
    {
        [Key]
        public int AreaIndex { get; set; }
        [MaxLength(150)]
        public string Alert_Identifier { get; set; }
    }

    public class Area
    {
        [Key]
        public int AreaIndex { get; set; }
        public string AreaDesc { get; set; }
        public string Polygon { get; set; }
        public string Circle { get; set; }
        public string Geocode { get; set; }
        public string Altitude { get; set; }
        public string Ceiling { get; set; }
        [MaxLength(150)]
        public string Alert_Identifier { get; set; }
        public int DataCategory_Id { get; set; }

        public ICollection<Element> Elements { get; set; }
    }
}


