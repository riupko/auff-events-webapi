using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuffEventsApi.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateBirth { get; set; }
        public int LocationID { get; set; }
        public int ManagerID { get; set; }
        public int LogoID { get; set; }
        public bool IsArchived { get; set; }
    }
}