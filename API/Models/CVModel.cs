using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CVModel
    {
        public Guid ID { get; set; } 
        public byte[] FileData { get; set; }
        public DateTime DateCreated { get; set; }
        public string FileName { get; set; }
    }
}