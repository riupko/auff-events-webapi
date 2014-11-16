using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations;

namespace AuffEventsMobileService.DataObjects
{
    public class EntryForm : EntityData
    {
        [Required]
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
        [Required]
        public string TeamId { get; set; }
        public virtual Team Team { get; set; }
        public bool IsApproved { get; set; }
    }
}