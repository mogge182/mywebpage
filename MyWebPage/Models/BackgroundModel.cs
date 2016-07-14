using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebPage.Models
{
    public class BackgroundModel
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string ImageAdress { get; set; }
    }
}