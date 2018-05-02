using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Models
{
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
        public string Alert_Identifier { get; set;  }
        public int DataCategory_Id { get; set; }

        public ICollection<Element> Elements { get; set; }
    }
}
