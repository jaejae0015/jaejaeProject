using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace jaejaeBoardASP.Controllers
{
    /// <summary>
    /// UserBizHandler의 요약 설명입니다.
    /// </summary>
    public class UserBizHandler : IHttpHandler
    {
        public string GetJson(object obj)
        {
            string json = string.Empty;

            if (obj != null)
            {
                json = JsonConvert.SerializeObject(obj);
            }

            return json;
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}