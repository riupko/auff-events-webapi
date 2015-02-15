using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace AuffEventsMobileService.DataObjects
{
    public class Member : EntityData
    {
        public Member()
        {
            TeamMembers = new List<TeamMember>();
        }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Patronymic { get; set; }
        public int Height { get; set; }
        public int Grip { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }
        [MaxLength(128)]
        public string OriginalTeam { get; set; }
        public string ClubId { get; set; }
        public virtual Club Club { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}