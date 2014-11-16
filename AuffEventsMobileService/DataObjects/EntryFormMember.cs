using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AuffEventsMobileService.DataObjects
{
    public class EntryFormMember : EntityData
    {
        public string EntryFormId { get; set; }
        public virtual EntryForm EntryForm { get; set; }
        public string TeamMemberId { get; set; }
        public virtual TeamMember TeamMember { get; set; }
    }
}