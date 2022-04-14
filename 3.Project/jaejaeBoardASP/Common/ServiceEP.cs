using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace jaejaeBoardASP.Common
{
    public class ServiceEP
    {
        public static string WCF_OfficeService()
        {
            string address = String.Empty;
            address = ConfigurationManager.AppSettings["WCFOfficeService"].ToString();

            return address;
        }
    }
}