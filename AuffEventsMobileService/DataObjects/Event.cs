using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AuffEventsMobileService.DataObjects
{
    /// <summary>
    /// Событие украинского флорбола
    /// </summary>
    public class Event : EntityData
    {
        public Event()
        {
            EntryForms = new List<EntryForm>();
        }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public DateTime DateEntryStop { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
        //[ForeignKey("EventID")]
        //public string ParentEventId { get; set; }
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public bool IsPublished { get; set; }
        [JsonIgnore]
        public virtual ICollection<EntryForm> EntryForms { get; set; }
    }
}