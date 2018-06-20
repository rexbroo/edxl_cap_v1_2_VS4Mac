using System;
using System.Collections;
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
        public int AlertIndex { get; set; }

        public Alert Alert { get; set; }

        [MaxLength(150)]
        public string Alert_Identifier { get; set; }

        public Info Info { get; set; }

        public int InfoIndex { get; set; }

        public Area Area { get; set; }

        public int AreaIndex { get; set; }

        public Resource Resource { get; set; }

		public int ResourceIndex { get; set; }

    }
}

