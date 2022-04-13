using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace jaejaeBoard.Models
{
    public static class OptionHtml
    {
        public static DataTable ConvertListToDataTable<TSource>(IEnumerable<TSource> source)
        {
            System.Reflection.PropertyInfo[] props = typeof(TSource).GetProperties();

            DataTable dt = new DataTable();
            List<DataColumn> dcList = new List<DataColumn>();
            foreach (var tmp in props)
            {
                DataColumn dc = new DataColumn(tmp.Name, Nullable.GetUnderlyingType(tmp.PropertyType) ?? tmp.PropertyType);
                foreach (Attribute attr in tmp.GetCustomAttributes(true))
                {
                    ValueNameAttribute info = attr as ValueNameAttribute;
                    if (info != null)
                        dc.Caption = info.ValueName;
                }
                dcList.Add(dc);
            }
            dt.Columns.AddRange(dcList.ToArray());

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }
        public static string GetOptionHtml(this IEnumerable<OptionValueText> ovts, string sDefaultValue, string sDefaultText)
        {
            var list = ovts.ToList();
            if (sDefaultValue != null && sDefaultText != null)
            {
                list.Insert(0, new OptionValueText(sDefaultValue, sDefaultText));
            }
            return list.GetOptionHtml(false, 0);
        }

        public static string GetOptionHtml(this IEnumerable<OptionValueText> ovts, bool isEmptyValueSkip = true, int selectedIndex = 0)
        {
            var sb = new StringBuilder();
            int i = 0;
            foreach (OptionValueText ovt in ovts)
            {
                if (isEmptyValueSkip && ovt.value == "") continue;

                sb.Append("<option value=\"");
                sb.Append(ovt.value);

                sb.Append("\"");

                if (i == selectedIndex)
                {
                    sb.Append(" selected=\"selected\"");
                }
                sb.Append(">");
                sb.Append(ovt.text);
                sb.Append("</option>\n");
                i++;
            }
            return sb.ToString();
        }

        public static string GetOptionHtml(this IEnumerable<OptionValueText> ovts, bool isEmptyValueSkip, string selectedValue)
        {
            var sb = new StringBuilder();

            foreach (OptionValueText ovt in ovts)
            {
                if (isEmptyValueSkip && ovt.value == "") continue;

                sb.Append("<option value=\"");
                sb.Append(ovt.value);

                sb.Append("\"");

                if (!String.IsNullOrEmpty(selectedValue))
                {
                    foreach (var itemValue in selectedValue.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (ovt.value.Equals(itemValue, StringComparison.OrdinalIgnoreCase))
                        {
                            sb.Append(" selected=\"selected\"");
                            break; // selected는 한번만..
                        }
                    }
                }
                sb.Append(">");
                sb.Append(ovt.text);
                sb.Append("</option>\n");
            }
            return sb.ToString();
        }
        public static IEnumerable<OptionValueText> ToOptionValueText<TSource>(this IEnumerable<TSource> source, string sValueColumn, string sTextColumn)
        {
            List<OptionValueText> rtn = new List<OptionValueText>();

            if (source == null) return rtn;

            DataTable dt = ConvertListToDataTable(source);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                OptionValueText o = new OptionValueText(dr[sValueColumn].ToString(), dr[sTextColumn].ToString());

                rtn.Add(o);
            }

            return rtn;
        }

        public static IEnumerable<OptionValueText> ToOptionValueText<TSource>(this IEnumerable<TSource> source, string sValueColumn, string[] sTextColumns, string sTextFormat)
        {
            List<OptionValueText> rtn = new List<OptionValueText>();

            if (source == null) return rtn;

            DataTable dt = ConvertListToDataTable(source);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string[] arrText = new string[sTextColumns.Length];
                for (int j = 0; j < sTextColumns.Length; j++)
                {
                    arrText[j] = dr[sTextColumns[j]].ToString();
                }

                OptionValueText o = new OptionValueText();
                o.value = dr[sValueColumn].ToString();
                o.text = string.Format(sTextFormat, arrText);

                rtn.Add(o);
            }

            return rtn;
        }

        public static IEnumerable<OptionValueText> ToOptionValueText<TSource>(this IEnumerable<TSource> source, string[] sValueColumns, string sValueFormat, string[] sTextColumns, string sTextFormat)
        {
            List<OptionValueText> rtn = new List<OptionValueText>();

            if (source == null) return rtn;

            DataTable dt = ConvertListToDataTable(source);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string[] arrValue = new string[sValueColumns.Length];
                for (int j = 0; j < sValueColumns.Length; j++)
                {
                    arrValue[j] = dr[sValueColumns[j]].ToString();
                }

                string[] arrText = new string[sTextColumns.Length];
                for (int j = 0; j < sTextColumns.Length; j++)
                {
                    arrText[j] = dr[sTextColumns[j]].ToString();
                }

                OptionValueText o = new OptionValueText();
                o.value = string.Format(sValueFormat, arrValue);
                o.text = string.Format(sTextFormat, arrText);

                rtn.Add(o);
            }

            return rtn;
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

    public class OptionValueTextExtra1
    {
        public string value { get; set; }
        public string text { get; set; }
        public string extra1 { get; set; }
        public string selected { get; set; }
        public OptionValueTextExtra1() { }
        public OptionValueTextExtra1(string v, string t, string e1)
        {
            value = v;
            text = t;
            extra1 = e1;
        }
    }
    public class ValueNameAttribute : Attribute
    {
        private string name;
        public ValueNameAttribute(string name)
        {
            this.name = name;
        }
        public string ValueName
        {
            set { name = value; }
            get { return name; }
        }
    }
}

