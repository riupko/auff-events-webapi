using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AuffEventsMobileService.DataObjects
{
    public class Image : EntityData
    {
        public string BlobUrl { get; set; }
    }
}