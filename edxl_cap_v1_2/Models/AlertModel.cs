using edxl_cap_v1_2.Models.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Models
{
    class AlertModel : EdxlCapMessageViewModel
    {
        int SelectedAlertIndex { get; set; }
        int AlertIndex { get; set; }
    }
}
