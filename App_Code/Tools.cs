using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace basic.Tools
{
    /// <summary>
    /// QZRequest 的摘要说明
    /// </summary>
    public class RequestClass
    {
        /// <summary>
        /// 获得指定Url参数的值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName)
        {
            return GetString(strName);
        }
        /// <summary>
        /// 获得指定Url参数的值 转换为int
        /// </summary>
        /// <param name="strName">参数</param>
        /// <param name="intDefault">默认值</param>
        public static int GetQueryInt(string strName, int intDefault)
        {
            int Int = intDefault;
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                Int = intDefault;
            }
            else
            {
                try
                {
                    Int = Int32.Parse(HttpContext.Current.Request.QueryString[strName]);
                }
                catch
                {
                    Int = intDefault;
                }
            }
            return Int;
        }
        /// <summary>
        /// 获得指定Url参数的值
        /// </summary> 
        /// <param name="strName">Url参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>Url参数的值</returns>
        private static string GetString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            bool bol = true;
            bol = IsSafeString(HttpContext.Current.Request.QueryString[strName].ToLower());
            if (!bol)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName];
        }
        // 检查危险字符
        private static bool IsSafeString(string Str)
        {
            string SqlStr = "'|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";
            bool ReturnValue = true;
            try
            {
                if (Str != "")
                {
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
    }
}
