using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using edxl_cap_v1_2.Models;

namespace edxl_cap_v1_2.Models
{
    public class EdxlCapMsg
    {
        [Key]
        public int Id { get; set; }
        public int AlertIndex { get; set; }
        public int? SelectedAlertIndex { get; set; }
        public string Alert_Identifier { get; set; }
        public int AreaIndex { get; set; }
        public int? SelectedAreaIndex { get; set; }
        public int InfoIndex { get; set; }
        public int? SelectedInfoIndex { get; set; }
        public int ResourceIndex { get; set; }
        public int? SelectedResourceIndex { get; set; }
    }
}

