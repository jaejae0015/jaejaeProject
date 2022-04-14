using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using jaejaeBoardASP.Biz.Interface;
using System.Web.Services.Description;
using jaejaeBoardASP.Common;

namespace jaejaeBoardASP.Controllers
{
    /// <summary>
    /// UserBizHandler의 요약 설명입니다.
    /// </summary>
    public class UserBizHandler : BaseHandler
    {
        

        public object GETUSERLIST_PROC(string pStrSearchText)
        {
            var a = "짜정나";
            DataTable dt;
            using (IUserBusiness Proxy = ServiceFactory.CreateServiceChannel<IUserBusiness>(ServiceEP.WCF_OfficeService()))
            {
                dt = Proxy.GETUSERLIST_PROC(pStrSearchText);
            }
            return JsonConvert.SerializeObject(dt);
        }
    }
}