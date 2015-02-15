using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AuffEventsMobileService.DataObjects
{
    public class MemberLicense :EntityData
    {
        [Required]
        public string MemberId { get; set; }
        public virtual Member Member { get; set; }
        [Required]
        public string ClubId { get; set; }
        public virtual Club Team { get; set; }
        public string LicenseId { get; set; }
        public DateTime DateExpired { get; set; }
    }
}