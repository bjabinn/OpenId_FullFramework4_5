﻿using System.Web;
using System.Web.Mvc;

namespace OpenIdConnect_Test1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
