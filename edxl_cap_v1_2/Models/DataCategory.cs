using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Models
{
    public class DataCategory
    {
        [Key]
        public int DataCategory_Id { get; set; }
        public string DataCategoryName { get; set; }

        public ICollection<Element> Elements { get; set; }
    }
}
