using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SharpRepository.EfRepository;

namespace jaejaeBoard.Controllers
{
    public class AppController : Controller
    {
        protected Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
            ContractResolver = new DefaultContractResolver()
        };
        protected new JsonResult Json(object data, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            var r = base.Json(new jaejaeBoard.Models.JsonResults()
            {
                List = Newtonsoft.Json.JsonConvert.SerializeObject(data, jsonSerializerSettings)
            }, behavior);
            r.MaxJsonLength = int.MaxValue;
            return r;
        }
        protected JsonResult Html(string html, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            var r = base.Json(new jaejaeBoard.Models.JsonResults() { Html = html }, behavior);
            r.MaxJsonLength = int.MaxValue;
            return r;
        }

    }
}
public class OptionValueText
{
    public string value { get; set; }
    public string text { get; set; }
    public string selected { get; set; }
    public OptionValueText() { }
    public OptionValueText(string v, string t)
    {
        value = v;
        text = t;
    }
}