using System;
using System.ComponentModel.DataAnnotations;
using edxl_cap_v1_2.Models;

namespace edxl_cap_v1_2.Models.ContentViewModels
{
    public class EdxlCapMessageViewModel
    {
        [Key]
        public string Alert_Identifier { get; set;  }

        public Alert Alert { get; set; }

        public Info Info { get; set; }

        public Area Area { get; set; }

        public Resource Resource { get; set; }
    }
}
