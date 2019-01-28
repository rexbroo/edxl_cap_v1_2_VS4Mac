using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using edxl_cap_v1_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace edxl_cap_v1_2.Models.ContentViewModels
{
    public class InfoViewModel
    {
        [Key]
        public int InfoIndex { get; set; }
        public int? SelectedAlertIndex { get; set; }
        [NotMapped]
        public List<SelectListItem> Alert_Identifiers { get; set; }
        public List<InfoVm> Infos { get; set; }
    }
    public class InfoVm
    {
        [Key]
        public int InfoIndex { get; set; }
        [MaxLength(150)]
        public string Alert_Identifier { get; set; }
    }
    
    public class Info
    {
        [Key]
        public int InfoIndex { get; set; }
        public string Language { get; set; }
        public EdxlCapMessageCategory Category { get; set; }
        public string Event { get; set; }
        public ResponseType ResponseType { get; set; }
        public Urgency Urgency { get; set; }
        public Certainty Certainty { get; set; }
        public Severity Severity { get; set; }
        public string Audience { get; set; }
        public string EventCode { get; set; }
        public DateTime Effective { get; set; }
        public DateTime Onset { get; set; }
        public DateTime Expires { get; set; }
        public string SenderName { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public string Web { get; set; }
        public string Contact { get; set; }
        public string Parameter { get; set; }
        [MaxLength(150)]
        public string Alert_Identifier { get; set; }
        public int DataCategory_Id { get; set; }

        public ICollection<Element> Elements { get; set; }

    }

    public enum EdxlCapMessageCategory
    {
        Geo,
        Met,
        Safety,
        Security,
        Rescue,
        Fire,
        Health,
        Env,
        Tranport,
        Infra,
        CBRNE,
        Other
    }
    public enum ResponseType
    {
        Shelter,
        Evacuate,
        Prepare,
        Execute,
        Avoid,
        Monitor,
        Assess,
        AllClear,
        None
    }
    public enum Urgency
    {
        Immediate,
        Expected,
        Future,
        Past,
        Unknown
    }
    public enum Severity
    {
        Extreme,
        Severe,
        Moderate,
        Minor,
        Unknown
    }
    public enum Certainty
    {
        Observed,
        Likely,
        Possible,
        Unlikely,
        Unknown
    }
    
}


