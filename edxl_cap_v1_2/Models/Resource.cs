using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Models
{
    public class Resource
    {
        [Key]
        public int ResourceIndex { get; set; }
        public string ResourceDesc { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }
        public string Uri { get; set; }
        public string DerefUri { get; set; }
        public string Digest { get; set; }
        public string Info_Alert_Identifier { get; set; }
        public string Alert_Identifier { get; set; }
        public int DataCategory_Id { get; set; }

        public ICollection<Element> Elements { get; set; }
    }
}
