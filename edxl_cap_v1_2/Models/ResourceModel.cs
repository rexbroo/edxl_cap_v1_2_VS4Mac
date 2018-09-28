using edxl_cap_v1_2.Models.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Models
{
    class ResourceModel : EdxlCapMessageViewModel
    {
        int ResourceIndex { get; set; }

        int SelectedResourceIndex { get; set; }
    }
}
