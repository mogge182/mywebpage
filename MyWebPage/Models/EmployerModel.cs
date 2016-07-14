﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebPage.Models
{
    public class EmployerModel
    {
        public Guid ID { get; set; }
        public string EmployerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}