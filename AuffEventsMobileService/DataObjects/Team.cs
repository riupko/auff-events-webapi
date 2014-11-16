using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace AuffEventsMobileService.DataObjects
{
    public class Team :EntityData
    {
        public Team()
        {
            EntryForms = new List<EntryForm>();
            TeamMembers = new List<TeamMember>();
        }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateBirth { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
        //public string ManagerId { get; set; }
        public string ImageId { get; set; }
        public Image Image { get; set; }
        [JsonIgnore]
        public virtual ICollection<EntryForm> EntryForms { get; set; }
        [JsonIgnore]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}