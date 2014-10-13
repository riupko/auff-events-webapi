using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuffEventsApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateEntryStop { get; set; }
        public int LocationID { get; set; }
        public int ParentEventID { get; set; }
        public int PosterID { get; set; }
        public bool IsPublished { get; set; }
    }
}