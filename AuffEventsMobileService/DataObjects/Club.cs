using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace AuffEventsMobileService.DataObjects
{
    public class Club : EntityData
    {
        public Club()
        {
            Teams = new List<Team>();
        }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        //public string ManagerId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }
    }
}