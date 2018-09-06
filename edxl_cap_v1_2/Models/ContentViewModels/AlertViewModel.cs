using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edxl_cap_v1_2.Models.ContentViewModels
{
    public class AlertViewModel
    {
		[Key]
		public int AlertIndex { get; set;  }
		public int SelectedAlertIndex { get; set; }
		[NotMapped]
		public List<SelectListItem> Alert_Identifiers { get; set; }
        public List<AlertVm> Alerts { get; set; }
    }
    public class AlertVm
    {
        [Key]
        public int AlertIndex { get; set; }
        [MaxLength(150)]
        public string Alert_Identifier { get; set; }
    }

	public class Alert
    {
        [Key]
        public int AlertIndex { get; set; }
		public int SelectedAlertIndex { get; set; }
        [MaxLength(150)]
		public string Alert_Identifier { get; set; }
        public string Sender { get; set; }
        public DateTime Sent { get; set; }
        public Status Status { get; set; }
        public MsgType MsgType { get; set; }
        public string Source { get; set; }
        public Scope Scope { get; set; }
        public string Restriction { get; set; }
        public string Addresses { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public string References { get; set; }
        public string Incidents { get; set; }
        public int DataCategory_Id { get; set; }

        public ICollection<Element> Elements { get; set; }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public enum Status
    {
        Actual,
        Exercise,
        System,
        Test,
        Draft
    }
    public enum MsgType
    {
        Alert,
        Update,
        Cancel,
        Ack,
        Error
    }
    public enum Scope
    {
        Public,
        Restricted,
        Private
    }

}
