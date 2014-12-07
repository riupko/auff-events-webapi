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
        public string TeamId { get; set; }
        public virtual Team Team { get; set; }
        [Required]
        public string TeamRoleId { get; set; }
        public virtual TeamRole TeamRole { get; set; }
        [Required]
        public string MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int Number { get; set; }
    }
}