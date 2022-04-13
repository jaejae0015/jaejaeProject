using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using jaejaeBoard.Models;
using jaejaeBoard.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SharpRepository.EfRepository;
using jaejaeBoard.Interface;

namespace jaejaeBoard.Controllers
{
    public class testTBsController : AppController
    {
        //private jaejaeSystemEntities db = new jaejaeSystemEntities();
        public ItestTBs _testTBSvc { get; set; }

        public testTBsController(ItestTBs testTBSvc)
        {
            this._testTBSvc = testTBSvc;
        }
        //public testTBService _testTBSvc { get; set; }
        //조회 화면
        public ActionResult Select()
        {
            return View();
        }

        //사용자 정보 가져오기 (SELECT WHERE)
        public JsonResult GetUserDetail(int iUserIdx)
        {
            userTB data = _testTBSvc.GetUserDetail(iUserIdx);
            if (data == null)
            {
                data = new userTB();
            }
            return Json(data);
        }
        //코드값 조회 (SELECT WHERE)
        public string GetCodeLists(string sGroupCode, bool bAddDefaultEmptyValue = false, bool bAddDefaultAllValue = false)
        {
            IEnumerable<tCommonCode> commonCode;
            tCommonCodeGroup data = _testTBSvc.GetGroupCode(sGroupCode);
            int groupIdx = 0;
            if (data != null)
                groupIdx = data.GroupIdx;

            commonCode = _testTBSvc.GetCodeLists(groupIdx);
            string strHtml;
            if (bAddDefaultEmptyValue == true)
                strHtml = commonCode.ToOptionValueText("CommonCode", "CodeName").GetOptionHtml("", "&nbsp;");
            else if (bAddDefaultAllValue == true)
                strHtml = commonCode.ToOptionValueText("CommonCode", "CodeName").GetOptionHtml("", "전체");
            else if (sGroupCode == "OffTelCd")
                strHtml = commonCode.ToOptionValueText("CommonCode", "CommonCode").GetOptionHtml("", "전체");
            else
                strHtml = commonCode.ToOptionValueText("CommonCode", "CodeName").GetOptionHtml(null, null);
            return strHtml;

        }

        //사용자 저장
        public int SaveUser(string sData)
        {
            userTB data = JsonConvert.DeserializeObject<userTB>(sData);

            int iResultCode = 0;

            if (data.UKID == 0)
            {
                data.CREUSERID = "JAEJAE1";
                data.MODUSERID = "JAEJAE1";
                data.CREDT = DateTime.Now;
                data.MODDT = DateTime.Now;
                iResultCode = _testTBSvc.AddUser(data);
            }
            else
            {
                data.MODUSERID = "JAEJAE1";
                data.MODDT = DateTime.Now;
                iResultCode = _testTBSvc.ModifyUser(data);
            }

            return iResultCode;
        }
        //INSERT/UPDATE/DELETE화면 조회
        public ActionResult Create(int ukId)
        {
            ViewBag.Ukid = ukId;
            return View();
        }
        //조건 조회 (SELECT WHERE)
        public JsonResult SelectCondition(string strSearchText)
        {
            IEnumerable<userTB> data = _testTBSvc.GetUserCondition(strSearchText);
            return Json(data);
        }
    }
}


