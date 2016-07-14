using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class PresentModel
    {
        public string Background { get; set; }
        public string Username { get; set; }
        public  List<EmployerModel> Employer  { get; set; }
    }
}