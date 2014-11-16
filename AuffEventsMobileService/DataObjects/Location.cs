using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AuffEventsMobileService.DataObjects
{
    public class Location : EntityData
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}