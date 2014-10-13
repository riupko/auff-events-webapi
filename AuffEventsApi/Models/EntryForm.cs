using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuffEventsApi.Models
{
    public class EntryForm
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsApproved { get; set; }
    }
}