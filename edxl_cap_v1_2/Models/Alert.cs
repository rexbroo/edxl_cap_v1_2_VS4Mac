using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Models
{
    public class Alert
    {
        [Key]
        public int Id { get; set; }
        public string Identifier { get; set; }
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
