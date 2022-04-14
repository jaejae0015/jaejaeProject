using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using jaejaeBoardASP.Biz.Interface;
using System.Data.SqlClient;

namespace jaejaeBoardASP.Biz
{
    public class UserBusiness : IUserBusiness
    {
        public void Dispose() {   }

        public DataTable GETUSERLIST_PROC(string pStrSearchText)
        {
            DBAgent dx = new DBAgent();
            SqlParameter[] param =
            {
                DataHelper.SqlDBParameter("strSearchText", SqlDbType.NVarChar, pStrSearchText, string.IsNullOrEmpty(pStrSearchText))
               
            };

            return dx.Get_ExcuteDataSet("pSelectConditionTestTB", param, CommandType.StoredProcedure).Tables[0];

        }
    }
}
