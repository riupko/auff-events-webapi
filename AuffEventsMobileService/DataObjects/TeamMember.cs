using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AuffEventsMobileService.DataObjects
{
    public class TeamMember :EntityData
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Patronymic { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }
        public int Number { get; set; }
        public string ImageId { get; set; }
        public Image Image { get; set; }
        [MaxLength(128)]
        public string OriginalTeam { get; set; }
        [Required]
        public string TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}