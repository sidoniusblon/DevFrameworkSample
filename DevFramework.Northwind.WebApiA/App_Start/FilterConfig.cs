﻿using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.WebApiA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
