using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpRepository.EfRepository;
using jaejaeBoard.Interface;
using jaejaeBoard.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

namespace jaejaeBoard.Service
{
    public class testTBService : ItestTBs
    {

        jaejaeSystemEntities db = new jaejaeSystemEntities();
        EfRepository<userTB> _repositoryTestTb = null;
        EfRepository<tCommonCode> _repositoryCommonCode = null;
        EfRepository<tCommonCodeGroup> _repositoryCommonCodeGroup = null;

        public testTBService()
        {
            _repositoryTestTb = new EfRepository<userTB>(db);
            _repositoryCommonCode = new EfRepository<tCommonCode>(db);
            _repositoryCommonCodeGroup = new EfRepository<tCommonCodeGroup>(db);
        }

        public int AddUser(userTB sData)
        {
            _repositoryTestTb.Add(sData);
            int iResultCode = 1 ;
            return iResultCode;
        }

        public IEnumerable<tCommonCode> GetCodeLists(int groupIdx)
        {
            return _repositoryCommonCode.FindAll(p => p.GroupIdx == groupIdx && p.DltYn == "N");
        }

        public tCommonCodeGroup GetGroupCode(string groupCode)
        {
            return _repositoryCommonCodeGroup.Find(p => p.GroupCode == groupCode && p.DltYn == "N");
        }

        public IEnumerable<userTB> GetUserCondition(string strSearchText)
        {
            string strSql = @"
                EXEC [pSelectConditionTestTB] @strSearchText
            ";

            object[] param = new object[] {
                 new SqlParameter("@strSearchText", strSearchText)
            };
            return db.Database.SqlQuery<userTB>(strSql, param).ToList();
        }

        public userTB GetUserDetail(int iUserIdx)
        {
            return _repositoryTestTb.Find(p => p.UKID == iUserIdx);
        }

        public int ModifyUser(userTB sData)
        {
            _repositoryTestTb.Update(sData);
            int iResultCode = 1;
            return iResultCode;

        }
    }
}