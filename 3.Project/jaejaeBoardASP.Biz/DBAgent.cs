using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Configuration;

namespace jaejaeBoardASP.Biz
{
    public class DBAgent
    {

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static T ConvertTo<T>(object _entity)
        {
            T obj = default(T);
            if (_entity != null)
            {
                obj = Activator.CreateInstance<T>();

                System.ComponentModel.PropertyDescriptorCollection properties = System.ComponentModel.TypeDescriptor.GetProperties(_entity);

                foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                {
                    System.Reflection.PropertyInfo _p = obj.GetType().GetProperty(prop.Name);
                    try
                    {
                        object value = prop.GetValue(_entity);
                        if (value.GetType().Name.Equals("DBNull")) value = null;
                        _p.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here

                    }
                }
            }

            return obj;
        }

        public string ConnectionString;
        private SqlConnection m_Connection;

        public DBAgent()
        {
            Setup();
        }

        public DBAgent(string Dsn)
        {
            Setup(Dsn);
        }

        public DBAgent(string ConnectionStr, string strType)
        {
            ConnectionString = ConnectionStr;
        }

        private void Setup()
        {
            ConnectionString = CommClass.GetConfigRead();
        }

        private void Setup(string Dsn)
        {
            ConnectionString = CommClass.GetConfigRead(Dsn);
        }

        #region DataReader 반환
        public SqlDataReader Get_ExcuteReader(string Query, SqlParameter[] paramArray, CommandType cmdType)
        {
            if (ConnectionString != "")
                m_Connection = new SqlConnection(ConnectionString);

            SqlDataReader dr;
            try
            {
                SqlCommand cmd = new SqlCommand(Query, m_Connection);
                cmd.CommandType = cmdType;
                m_Connection.Open();

                if (paramArray != null)
                {
                    foreach (SqlParameter param in paramArray)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dr;
        }

        public SqlDataReader Get_ExcuteReader(string Query)
        {
            return Get_ExcuteReader(Query, null, CommandType.Text);
        }

        public SqlDataReader Get_ExcuteReader(string Query, SqlParameter[] paramArray)
        {
            return Get_ExcuteReader(Query, paramArray, CommandType.Text);
        }
        #endregion

        #region DataSet반환
        public DataSet Get_ExcuteDataSetPL(string Query, List<SqlParameter> lstParam, CommandType cmdType)
        {
            return Get_ExcuteDataSetPL(Query, "Table", null, lstParam, cmdType);
        }

        public DataSet Get_ExcuteDataSetPL(string Query, string sTable, DataSet dataset, List<SqlParameter> lstParam, CommandType cmdType)
        {
            if (ConnectionString != "")
                m_Connection = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adt = new SqlDataAdapter(Query, m_Connection);
                adt.SelectCommand.CommandType = cmdType;
                adt.SelectCommand.CommandTimeout = 5000;
                if (dataset == null)
                    dataset = new DataSet();

                if (lstParam != null && lstParam.Count > 0)
                {
                    foreach (SqlParameter param in lstParam)
                    {
                        adt.SelectCommand.Parameters.Add(param);
                    }
                }
                dataset.Clear();
                adt.Fill(dataset, sTable);
                adt.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
                m_Connection.Dispose();
            }

            return dataset;
        }

        private List<object> paramOut = new List<object>();

        public List<object> GetOUTPUT
        {
            get { return paramOut; }
        }

        public DataSet Get_ExcuteDataSet(string Query, string sTable, DataSet dataset, SqlParameter[] paramArray, CommandType cmdType, int timeout)
        {
            if (ConnectionString != "")
                m_Connection = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adt = new SqlDataAdapter(Query, m_Connection);
                adt.SelectCommand.CommandType = cmdType;
                adt.SelectCommand.CommandTimeout = timeout * 60;

                if (dataset == null)
                    dataset = new DataSet();

                if (paramArray != null)
                {
                    foreach (SqlParameter param in paramArray)
                    {
                        adt.SelectCommand.Parameters.Add(param);
                    }
                }
                dataset.Clear();

                adt.Fill(dataset, sTable);

                adt.Dispose();
            }
            catch (Exception ex)
            {
               // LogMessageToFile(Query, paramArray);
                throw ex;
            }
            finally
            {
                m_Connection.Close();
                m_Connection.Dispose();
            }

            return dataset;
        }

        public DataSet Get_ExcuteDataSet(string Query, string sTable, DataSet dataset, ref SqlParameter[] paramArray, CommandType cmdType)
        {
            if (ConnectionString != "")
                m_Connection = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adt = new SqlDataAdapter(Query, m_Connection);
                adt.SelectCommand.CommandType = cmdType;
                adt.SelectCommand.CommandTimeout = 5000;
                if (dataset == null)
                    dataset = new DataSet();

                if (paramArray != null)
                {
                    foreach (SqlParameter param in paramArray)
                    {
                        adt.SelectCommand.Parameters.Add(param);
                    }
                }
                dataset.Clear();

                adt.Fill(dataset, sTable);

                if (paramArray != null)
                {
                    foreach (SqlParameter param in paramArray)
                    {
                        if (param.Direction.Equals(ParameterDirection.Output))
                            param.Value = adt.SelectCommand.Parameters[param.ParameterName].Value;
                    }
                }

                adt.Dispose();

                //dataset.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
                m_Connection.Dispose();
            }

            return dataset;
        }

        public DataSet Get_ExcuteDataSet(string Query, SqlParameter[] paramArray, CommandType cmdType, int timeout)
        {
            return Get_ExcuteDataSet(Query, "Table", null, paramArray, cmdType, timeout);
        }

        public DataSet Get_ExcuteDataSet(string Query, SqlParameter[] paramArray, CommandType cmdType)
        {
            return Get_ExcuteDataSet(Query, "Table", null, paramArray, cmdType, 1);
        }

        public DataSet Get_ExcuteDataSet(string Query, ref SqlParameter[] paramArray, CommandType cmdType)
        {
            return Get_ExcuteDataSet(Query, "Table", null, ref paramArray, cmdType);
        }

        public DataSet Get_ExcuteDataSet(string Query)
        {
            return Get_ExcuteDataSet(Query, "Table", null, null, CommandType.Text, 1);
        }

        public DataSet Get_ExcuteDataSet(string Query, string sTable)
        {
            return Get_ExcuteDataSet(Query, sTable, null, null, CommandType.Text, 1);
        }
        #endregion

        #region object값 반환
        public object Get_ExcuteNonQuery(string Query, SqlParameter[] paramArray, CommandType cmdType)
        {
            object oValue;

            if (ConnectionString != "")
                m_Connection = new SqlConnection(ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand(Query, m_Connection);
                cmd.CommandType = cmdType;

                if (paramArray != null)
                {
                    foreach (SqlParameter param in paramArray)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                m_Connection.Open();
                oValue = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
                m_Connection.Dispose();
            }

            return oValue;
        }

        public object Get_ExcuteNonQuery(string Query)
        {
            return Get_ExcuteNonQuery(Query, null, CommandType.Text);
        }
        #endregion

        #region 엑셀 데이터
        /// <summary>
        /// 엑셀용 데이터테이블 조회시
        /// </summary>
        /// <param name="Proc"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable Get_ExcuteDataTable(string Proc, Dictionary<string, object> args)
        {
            DataTable dtRtn = null;

            try
            {
                SqlParameter[] sParam = {
                    DataHelper.SqlDBParameter("IN_PROCNM", SqlDbType.NVarChar, Proc),

                };

                DataTable dtParam = Get_ExcuteDataSet("USP_COMPROPERTIES", ref sParam, CommandType.StoredProcedure).Tables[0];

                if (dtParam != null && dtParam.Rows.Count > 0)
                {
                    SqlParameter[] dParam = new SqlParameter[dtParam.Rows.Count];

                    if (args != null)
                    {
                        int index = 0;
                        SqlParameter param;

                        foreach (DataRow drParam in dtParam.Rows)
                        {
                            param = new SqlParameter();
                            param.ParameterName = drParam["ARGUMENT_NAME"].ToString();
                            SetSqlDbType(param, drParam["DATA_TYPE"], drParam["IN_OUT"], drParam["IN_OUT"].ToString().ToLower().Equals("in") ? args[param.ParameterName.Substring(1)] : null);

                            dParam[index] = param;
                            index++;
                        }
                    }

                    dtRtn = Get_ExcuteDataSet(Proc, dParam, CommandType.StoredProcedure, 20).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRtn;
        }

        public SqlParameter SetSqlDbType(SqlParameter rtnParam, object typeNm, object inout, object value)
        {
            if (inout.ToString().ToLower().Equals("out")) rtnParam.Direction = ParameterDirection.Output;
            if (value == null) value = string.Empty;

            switch (typeNm.ToString().ToLower())
            {
                case "numeric":
                    rtnParam.SqlDbType = SqlDbType.Decimal;
                    if (!string.IsNullOrEmpty(value.ToString()))
                        rtnParam.Value = Convert.ToInt32(value);
                    else
                        rtnParam.Value = DBNull.Value;
                    break;
                case "number":
                    rtnParam.SqlDbType = SqlDbType.Decimal;
                    if (!string.IsNullOrEmpty(value.ToString()))
                        rtnParam.Value = Convert.ToInt32(value);
                    else
                        rtnParam.Value = DBNull.Value;
                    break;
                case "nvarchar":
                    rtnParam.SqlDbType = SqlDbType.NVarChar;
                    if (string.IsNullOrEmpty(value.ToString()))
                        rtnParam.Value = DBNull.Value;
                    else
                        rtnParam.Value = value.ToString();
                    break;
                case "nchar":
                    rtnParam.SqlDbType = SqlDbType.NChar;
                    rtnParam.Value = value.ToString();
                    break;
                case "datetime":
                    rtnParam.SqlDbType = SqlDbType.Date;
                    if (!string.IsNullOrEmpty(value.ToString()))
                        rtnParam.Value = Convert.ToDateTime(value);
                    else
                        rtnParam.Value = DBNull.Value;
                    break;
                case "double":
                    rtnParam.SqlDbType = SqlDbType.Decimal;
                    rtnParam.Value = Convert.ToDouble(value);
                    break;
                case "text":
                    rtnParam.SqlDbType = SqlDbType.Text;
                    rtnParam.Value = value.ToString();
                    break;
                case "ntext":
                    rtnParam.SqlDbType = SqlDbType.NText;
                    rtnParam.Value = value.ToString();
                    break;
                case "float":
                    rtnParam.SqlDbType = SqlDbType.Decimal;
                    if (!string.IsNullOrEmpty(value.ToString()))
                        rtnParam.Value = Convert.ToDecimal(value);
                    else
                        rtnParam.Value = DBNull.Value;
                    break;
                case "char":
                    rtnParam.SqlDbType = SqlDbType.Char;
                    rtnParam.Value = value.ToString();
                    break;
                case "varchar":
                    rtnParam.SqlDbType = SqlDbType.NVarChar;
                    if (string.IsNullOrEmpty(value.ToString()))
                        rtnParam.Value = DBNull.Value;
                    else
                        rtnParam.Value = value.ToString();
                    break;
                case "binary":
                    rtnParam.SqlDbType = SqlDbType.Binary;
                    rtnParam.Value = value.ToString();
                    break;
                case "ref cursor":
                    rtnParam.SqlDbType = SqlDbType.NVarChar;
                    rtnParam.Value = DBNull.Value;
                    break;
            }

            return rtnParam;
        }
        #endregion

        #region
        public object Get_ExcuteReturnQuery(string Query, SqlParameter[] paramArray, CommandType cmdType, SqlDbType SdType)
        {
            if (ConnectionString != "")
                m_Connection = new SqlConnection(ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand(Query, m_Connection);
                cmd.CommandType = cmdType;
                cmd.CommandTimeout = 60000;

                if (paramArray != null)
                {
                    foreach (SqlParameter param in paramArray)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                SqlParameter Param = new SqlParameter();
                Param.ParameterName = "@OUT_RESULT";
                Param.SqlDbType = SdType;
                if (SdType.Equals(SqlDbType.NVarChar)) { Param.Size = 1000; }
                Param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(Param);

                m_Connection.Open();
                cmd.ExecuteNonQuery();

                object obj = cmd.Parameters["@OUT_RESULT"].Value;

                return obj != null ? obj.ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
                m_Connection.Dispose();
            }
        }

        public void EXE_ExcuteNonQuery(string Query, SqlParameter[] paramArray, CommandType cmdType)
        {
            if (ConnectionString != "")
                m_Connection = new SqlConnection(ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand(Query, m_Connection);
                cmd.CommandType = cmdType;
                cmd.CommandTimeout = 60000;

                List<object> paramnm = new List<object>();

                if (paramArray != null)
                {
                    foreach (SqlParameter param in paramArray)
                    {
                        if (param.Direction == ParameterDirection.Output)
                        {
                            paramnm.Add(param.ParameterName);
                        }

                        cmd.Parameters.Add(param);
                    }
                }

                for (int i = 0; i < paramnm.Count; i++)
                {
                    paramOut.Add(cmd.Parameters[paramnm[i].ToString()].Value);
                }


                m_Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
                m_Connection.Dispose();
            }
        }

        public void EXE_ExcuteNonQuery(string Query)
        {
            EXE_ExcuteNonQuery(Query, null, CommandType.Text);
        }
        #endregion
    }

    #region DataTable To Edmx
    public class CollectionHelper
    {
        private CollectionHelper()
        {
        }

        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        if (value.GetType().Name.Equals("DBNull")) value = null;
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        throw;
                    }
                }
            }

            return obj;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }

    }
    #endregion

    /*
    public class Cryptography
    {
        #region MD5
        /// <summary>
        /// MD5 변환
        /// </summary>
        /// <param name="input">원문</param>
        /// <returns>코드</returns>
        public static string getMd5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        /// <summary>
        ///  MD5 비교
        /// </summary>
        /// <param name="input">원문</param>
        /// <param name="hash">코드</param>
        /// <returns>결과 값</returns>
        public static bool verifyMd5Hash(string input, string hash)
        {
            string hashOfInput = getMd5Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
                return true;
            else
                return false;
        }
        #endregion
    }
     * */

    public class CommClass
    {
        #region AppSettings반환
        public static string GetAppRead(string str)
        {
            return ConfigurationManager.AppSettings[str];
        }

        public static string GetConfigRead()
        {
            return GetConfigRead("jaejaeSystemEntities");
        }

        public static string GetConfigRead(string str)
        {
            return ConfigurationManager.ConnectionStrings[str].ConnectionString;
        }
        #endregion

        //허용한 HTML 태그를 제외하고 <,>를 &lt;,&gt;로 치환  
        public static string ReplaceHTMLSpecialChars(string str, string strAllowTag)
        {
            strAllowTag = string.Concat("ul,ol,dl,dt,dd,li,hr,strong,em,s,u,sub,sup,", strAllowTag);

            string pattern = @"<(\/?)(?!\/####)([^<|>]+)?>";
            string substitute = string.Empty; // "&lt;$1$2&gt;";
            string[] allowTags = strAllowTag.Split(',');
            System.Text.StringBuilder buffer = new System.Text.StringBuilder();

            for (int i = 0; i < allowTags.Length; i++)
            {
                buffer.Append("|" + allowTags[i].Trim() + @"(?!\w)");
            }

            pattern = pattern.Replace("####", buffer.ToString());

            return System.Text.RegularExpressions.Regex.Replace(str, pattern, substitute);
        }

        /// <summary>
        /// NUL 문자 제거 추가
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string decodeURIComponent(string str)
        {
            if (!string.IsNullOrEmpty(str))
                return Uri.UnescapeDataString(str).Replace("•", "·").Trim('\0');
            else
                return string.Empty;
        }

        /// <summary>
        /// 날짜 형태 반환
        /// </summary>
        /// <param name="yyyyMMdd"></param>
        /// <param name="Delistr"></param>
        /// <returns></returns>
        public static string Get_yyyyMMdd(string yyyyMMdd, string Delistr)
        {
            try
            {
                string y, m, d;
                string rtnDate = string.Empty;

                y = string.Empty;
                m = string.Empty;
                d = string.Empty;

                if (yyyyMMdd.Length > 10)
                {
                    y = yyyyMMdd.Substring(0, 4);
                    m = yyyyMMdd.Substring(5, 2);
                    d = yyyyMMdd.Substring(8, 2);
                }
                else if (yyyyMMdd.Length == 8)
                {
                    y = yyyyMMdd.Substring(0, 4);
                    m = yyyyMMdd.Substring(4, 2);
                    d = yyyyMMdd.Substring(6, 2);
                }

                if (!string.IsNullOrEmpty(y))
                    rtnDate = string.Concat(y, Delistr, m, Delistr, d);

                return rtnDate;
            }
            catch
            {
                return "-";
            }
        }
    }

    public class DataHelper
    {
        public static string Get_ExcuteNonQuery(string Query)
        {
            string ReturnString;

            try
            {
                DBAgent dx = new DBAgent();
                ReturnString = dx.Get_ExcuteNonQuery(Query).ToString();
            }
            catch
            {
                ReturnString = string.Empty;
            }

            return ReturnString;
        }

        public static string Get_ExcuteNonQuery(string Query, string Dsn)
        {
            string ReturnString;

            try
            {
                DBAgent dx = new DBAgent(Dsn);
                ReturnString = dx.Get_ExcuteNonQuery(Query).ToString();
            }
            catch
            {
                ReturnString = string.Empty;
            }

            return ReturnString;
        }

        public static SqlDataReader Get_DataReader(string Query)
        {
            DBAgent dx = new DBAgent();
            SqlDataReader dr = dx.Get_ExcuteReader(Query);

            return dr;
        }

        public static void EXE_ExcruteNonQuery(string Query)
        {
            DBAgent dx = new DBAgent();
            dx.EXE_ExcuteNonQuery(Query);
        }

        public static void EXE_ExcruteNonQuery(string Query, string DSN)
        {
            DBAgent dx = new DBAgent();
            dx.ConnectionString = CommClass.GetConfigRead(DSN);

            dx.EXE_ExcuteNonQuery(Query);
        }

        #region SqlParameter
        public static SqlParameter SqlDBParameter(string ParameterName, SqlDbType St, object oValue)
        {
            SqlParameter Sp = new SqlParameter("@" + ParameterName, St);
            Sp.Value = oValue;

            return Sp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="St"></param>
        /// <param name="iSize"></param>
        /// <param name="oValue"></param>
        /// <param name="bNull">참일 경우 DBNull 값 적용</param>
        /// <returns></returns>
        public static SqlParameter SqlDBParameter(string ParameterName, SqlDbType St, object oValue, bool bNull)
        {
            SqlParameter Sp = new SqlParameter("@" + ParameterName, St);

            if (bNull)
                Sp.Value = DBNull.Value;
            else
                Sp.Value = oValue;

            return Sp;
        }

        public static SqlParameter SqlDBParameter(string ParameterName, SqlDbType St, object oValue, ParameterDirection Pd)
        {
            SqlParameter Sp = new SqlParameter("@" + ParameterName, St);
            Sp.Value = oValue;
            Sp.Direction = Pd;

            return Sp;
        }
        #endregion

        #region 단순 쿼리 반환
        public static DataSet Get_QueryResult(string sField, string sTable, string sWhere, string sOrder)
        {
            int iRecodeCount = -1;

            return Get_QueryResult(sField, sTable, false, sWhere, sOrder, null, out iRecodeCount);
        }

        public static DataSet Get_QueryResult(string sField, string sTable, bool GetRecodeCount, string sFilter, string sSort, string sGroup, out int iRecodeCount)
        {
            SqlParameter[] oParams = new SqlParameter[6];
            oParams[0] = new SqlParameter("@strFields", SqlDbType.NVarChar, 4000);
            oParams[0].Value = sField;
            oParams[1] = new SqlParameter("@strTables", SqlDbType.NVarChar, 4000);
            oParams[1].Value = sTable;
            oParams[2] = new SqlParameter("@blnGetRecordCount", SqlDbType.Decimal, 1);
            oParams[2].Value = GetRecodeCount;
            oParams[3] = new SqlParameter("@strFilter", SqlDbType.NVarChar, 8000);
            oParams[3].Value = sFilter;
            oParams[4] = new SqlParameter("@strSort", SqlDbType.NVarChar, 8000);
            oParams[4].Value = sSort;
            oParams[5] = new SqlParameter("@strGroup", SqlDbType.NVarChar, 8000);
            oParams[5].Value = sGroup;

            iRecodeCount = -1;

            DBAgent dx = new DBAgent();
            DataSet ds = dx.Get_ExcuteDataSet("usp_ReturnQuery", sTable, null, oParams, CommandType.StoredProcedure, 1);

            if (ds.Tables.Count != 0)
            {
                if (ds.Tables.Count == 2 && ds.Tables[1].Rows.Count != 0)
                    iRecodeCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }

            return ds;
        }
        #endregion

        #region 페이징 리피터 바인딩

        public static DataSet Get_PagingList(int iPage, string sField, string sPK,
            string sTable, int iPageSize, bool GetRecodeCount, string sFilter, string sSort, string sGroup, out int iRecodeCount)
        {
            SqlParameter[] oParams = new SqlParameter[9];
            oParams[0] = new SqlParameter("@strFields", SqlDbType.NVarChar, 4000);
            oParams[0].Value = sField;
            oParams[1] = new SqlParameter("@strPK", SqlDbType.NVarChar, 100);
            oParams[1].Value = sPK;
            oParams[2] = new SqlParameter("@strTables", SqlDbType.NVarChar, 4000);
            oParams[2].Value = sTable;
            oParams[3] = new SqlParameter("@intPageNo", SqlDbType.Decimal, 38);
            oParams[3].Value = iPage;
            oParams[4] = new SqlParameter("@intPageSize", SqlDbType.Decimal, 38);
            oParams[4].Value = iPageSize;
            oParams[5] = new SqlParameter("@blnGetRecordCount", SqlDbType.Decimal, 1);
            oParams[5].Value = GetRecodeCount;
            oParams[6] = new SqlParameter("@strFilter", SqlDbType.NVarChar, 8000);
            oParams[6].Value = sFilter;
            oParams[7] = new SqlParameter("@strSort", SqlDbType.NVarChar, 8000);
            oParams[7].Value = sSort;
            oParams[8] = new SqlParameter("@strGroup", SqlDbType.NVarChar, 8000);
            oParams[8].Value = sGroup;

            iRecodeCount = -1;

            DBAgent dx = new DBAgent();
            DataSet ds = dx.Get_ExcuteDataSet("Usp_PagingQuery", sTable, null, oParams, CommandType.StoredProcedure, 1);

            if (ds.Tables.Count != 0)
            {
                if (ds.Tables.Count == 2 && ds.Tables[1].Rows.Count != 0)
                    iRecodeCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }

            return ds;
        }
        #endregion
    }
}