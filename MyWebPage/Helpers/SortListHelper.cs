using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebPage.Models;

namespace MyWebPage.Helpers
{
    public class SortListHelper
    {
        public static List<EmployerModel> SortEmployerListDescending(List<EmployerModel> listToSort)
        {
            var list = listToSort.OrderByDescending(x => x.EndDate);
            return list.ToList();
        }
    }
}