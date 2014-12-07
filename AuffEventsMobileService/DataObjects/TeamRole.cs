using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations;

namespace AuffEventsMobileService.DataObjects
{
    public class TeamRole : EntityData
    {
        [Required]
        public string Name { get; set; }
    }
}