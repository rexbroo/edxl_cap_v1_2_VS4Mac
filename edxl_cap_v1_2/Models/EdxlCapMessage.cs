using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using edxl_cap_v1_2.Models;
using edxl_cap_v1_2.Models.ContentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace edxl_cap_v1_2.Models
{
    public class EdxlCapMessage
    {
       [Key]
//        public int Id { get; set; }
        public int AlertIndex { get; set; }
        public int? SelectedAlertIndex { get; set; }
        public string Alert_Identifier { get; set; }
        public string Sender { get; set; }
        public DateTime Sent { get; set; }

        private Status status;

        public Status GetStatus()
        {
            return status;
        }

        public void SetStatus(Status value)
        {
            status = value;
        }

        private MsgType msgType;

        public MsgType GetMsgType()
        {
            return msgType;
        }

        public void SetMsgType(MsgType value)
        {
            msgType = value;
        }

        public string Source { get; set; }

        private Scope scope;

        public Scope GetScope()
        {
            return scope;
        }

        public void SetScope(Scope value)
        {
            scope = value;
        }

        public string Restriction { get; set; }
        public string Addresses { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public string References { get; set; }
        public string Incidents { get; set; }
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

        public int InfoIndex { get; set; }
//        public int? SelectedInfoIndex { get; set; }
        public string Language { get; set; }

        private Category category;

        public Category GetCategory()
        {
            return category;
        }

        public void SetCategory(Category value)
        {
            category = value;
        }

        public string Event { get; set; }

        private ResponseType responseType;

        public ResponseType GetResponseType()
        {
            return responseType;
        }

        public void SetResponseType(ResponseType value)
        {
            responseType = value;
        }

        private Urgency urgency;

        public Urgency GetUrgency()
        {
            return urgency;
        }

        public void SetUrgency(Urgency value)
        {
            urgency = value;
        }

        private Certainty certainty;

        public Certainty GetCertainty()
        {
            return certainty;
        }

        public void SetCertainty(Certainty value)
        {
            certainty = value;
        }

        private Severity severity;

        public Severity GetSeverity()
        {
            return severity;
        }

        public void SetSeverity(Severity value)
        {
            severity = value;
        }

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
        public enum Category
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

        public int AreaIndex { get; set; }
//        public int? SelectedAreaIndex { get; set; }
        public string AreaDesc { get; set; }
        public string Polygon { get; set; }
        public string Circle { get; set; }
        public string Geocode { get; set; }
        public string Altitude { get; set; }
        public string Ceiling { get; set; }

        public int ResourceIndex { get; set; }
//        public int? SelectedResourceIndex { get; set; }
        public string ResourceDesc { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }
        public string Uri { get; set; }
        public string DerefUri { get; set; }
        public string Digest { get; set; }
        public ContentViewModels.MsgType EdxlCapMessageMsgType { get; internal set; }
        public ContentViewModels.Status EdxlCapMessageStatus { get; internal set; }
        public ContentViewModels.Scope EdxlCapMessageScope { get; internal set; }
        public ContentViewModels.EdxlCapMessageCategory EdxlCapMessageCategory { get; internal set; }
        public ContentViewModels.ResponseType EdxlCapMessageResponseType { get; internal set; }
        public ContentViewModels.Severity EdxlCapMessageSeverity { get; internal set; }
        public ContentViewModels.Urgency EdxlCapMessageUrgency { get; internal set; }
        public ContentViewModels.Certainty EdxlCapMessageCertainty { get; internal set; }
    }
}

