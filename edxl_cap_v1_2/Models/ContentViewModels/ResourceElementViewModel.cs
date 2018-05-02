﻿using System;
using System.Collections.Generic;
using edxl_cap_v1_2.Models;


namespace edxl_cap_v1_2.Models.ContentViewModels
{
    public class ResourceElementViewModel
    {
        public Resource Resource { get; set; }
        public IEnumerable<Element> Elements { get; set; }
        public IEnumerable<DataCategory> DataCategories { get; set; }
       
    }
}
