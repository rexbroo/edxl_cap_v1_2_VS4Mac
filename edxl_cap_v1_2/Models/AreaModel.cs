using edxl_cap_v1_2.Models.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Models
{
    class AreaModel : EdxlCapMessageViewModel
    {
        int AreaIndex { get; set; }

        int SelectedAreaIndex { get; set; }
    }
}
