﻿using System.Web;
using System.Web.Mvc;

namespace DOAN_THWEB_NC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
