using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using edxl_cap_v1_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace edxl_cap_v1_2.Models.ContentViewModels
{
    public class ResourceViewModel
    {
        [Key]
        public int AlertIndex { get; set; }
        public int SelectedAlertIndex { get; set; }
        [NotMapped]
        public List<SelectListItem> Alert_Identifiers { get; set; }
        public List<ResourceVm> Resources { get; set; }
    }
    public class ResourceVm
    {
        [Key]
        public int ResourceIndex { get; set; }
        [MaxLength(150)]
        public string Alert_Identifier { get; set; }
    }
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
        [MaxLength(150)]
        public string Alert_Identifier { get; set; }
        public int DataCategory_Id { get; set; }

        public ICollection<Element> Elements { get; set; }
    }
}

