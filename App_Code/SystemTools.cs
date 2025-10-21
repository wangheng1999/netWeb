using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace WebApp.Components
{
    /// <summary>
    /// 系统常用工具函数类
    /// </summary>
    public class SystemTools
    {
        /// <summary>
        /// 置顶飘红
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strIstop"></param>
        /// <returns></returns>
        public string ChangeColor(string strTitle, string strIstop)
        {
            string strValue = null;
            if (strIstop == "0")
            {
                strValue = strTitle;
            }
            else
            {
                strValue = "<font color='red'>" + strTitle + "</font>";
            }
            return strValue;
        }
        /// <summary>
        /// 最近的新闻显示图标
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ChangeGif(string data)
        {
            DateTime t1 = DateTime.Now;
            DateTime t2 = Convert.ToDateTime(data);
            TimeSpan ts = t1 - t2;
            int d = ts.Days;
            string strGif = null;
            if (d <= 7)
            {
                strGif = "<img src='/images/news.gif'>";
            }
            return strGif;
        }
        /// <summary>
        /// 判断网站是否到期
        /// </summary>
        public void showTimeLimit()
        {
            ClientTimeLimit clienttimelimit = new ClientTimeLimit();

            Common common = new Common();
            clienttimelimit = common.showTimeLimit();

            string strEndTime = clienttimelimit.EndTime; //获得到期时间

            DateTime t1 = DateTime.Now;
            DateTime t2 = Convert.ToDateTime(strEndTime);
            TimeSpan ts = t1 - t2;
            int d = ts.Days;

            WebSiteState websitestate = new WebSiteState();
            websitestate = common.showWebSiteState();
            string strState = websitestate.State; //获得网站运行状态
            string strTishi = websitestate.Tishi; //网站关闭原因

            string strMessage = null;
            if (d >= 1)
            {
                strMessage = "<li><b>关闭原因：网站于" + t2.ToString("yyyy年MM月dd日") + "已经到期</b></li>";
                strMessage = strMessage + "<li>请您尽快联系我们续费!<br /><span>You as soon as possible renewals!</span></li>";
                strMessage = strMessage + "<li>您的数据还都在的,我们会为您免费保存3天，3天后数据将会被删除!<br /><span>Your data is still, we kept only 3 days, 3 days after the data will be deleted!</span></li><li><strong>有任何疑问，请联系服务支持人员，谢谢！<br /><span>售后QQ：97028865</span></strong></li>";
                System.Web.HttpContext.Current.Response.Redirect("Tishi.aspx?Message=" + System.Web.HttpUtility.UrlEncode(strMessage) + "");
            }
            else if (strState == "1")
            {
                strMessage = "<li><b>关闭原因：" + strTishi + "</b></li>";
                System.Web.HttpContext.Current.Response.Redirect("Tishi.aspx?Message=" + System.Web.HttpUtility.UrlEncode(strMessage) + "");
            }
        }
        /// <summary>
        /// 防止SQL注入
        /// </summary>
        public bool StartProcessRequest()
        {
            bool ReturnValue = true;
            try
            {
                string getkeys = null;
                if (System.Web.HttpContext.Current.Request.QueryString != null)
                {
                    for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys].ToLower()))
                        {
                            ReturnValue = false;
                            break;
                            //System.Web.HttpContext.Current.Response.Write("您的请求带有不合法的参数，谢谢合作！");
                            //System.Web.HttpContext.Current.Response.End();
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
        /// <summary>
        /// 分析用户请求是否正常
        /// </summary>
        /// <param name="Str">传入用户提交数据</param>
        /// <returns>返回是否含有SQL注入式攻击代码</returns>
        public bool ProcessSqlStr(string Str)
        {
            string SqlStr = "'|and|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare|alert";
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
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="oText"></param>
        /// <returns></returns>
        public bool IsNumberic(string oText)//判断是否是数字
        {
            bool bolValue = false;
            try
            {
                if (oText != null)
                {
                    int var1 = System.Convert.ToInt32(oText);
                    bolValue = true;
                }
                else
                {
                    bolValue = false;
                }
            }
            catch
            {
                bolValue = false;
            }
            if (bolValue == false)
            {
                System.Web.HttpContext.Current.Response.Write("您的请求带有不合法的参数，谢谢合作！");
                System.Web.HttpContext.Current.Response.End();
            }
            return bolValue;
        }
        /// <summary>
        ///  截取字符串
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string SubString(string inputString, int length)
        {
            if (Encoding.UTF8.GetByteCount(inputString) <= length * 2)
            {
                return inputString;
            }
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
                tempString += inputString.Substring(i, 1);
                if (tempLen >= (length - 1) * 2)
                    break;
            }
            //如果截过则加上半个省略号
            if (System.Text.Encoding.Default.GetBytes(inputString).Length > length)
                tempString += "…";
            return tempString;
        }
        /// <summary>
        /// 将DataReader 转为 DataTable
        /// </summary>
        /// <param name="DataReader">DataReader</param>
        //public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        //{
        //    DataTable datatable = new DataTable();
        //    DataTable schemaTable = dataReader.GetSchemaTable();
        //    //动态添加列
        //    try
        //    {

        //        foreach(DataRow myRow in schemaTable.Rows)
        //        {
        //            DataColumn myDataColumn = new DataColumn();
        //            myDataColumn.DataType	= myRow.GetType();
        //            myDataColumn.ColumnName = myRow[0].ToString();
        //            datatable.Columns.Add(myDataColumn);
        //        }
        //        //添加数据
        //        while(dataReader.Read())
        //        {
        //            DataRow myDataRow = datatable.NewRow();
        //            for(int i=0;i<schemaTable.Rows.Count;i++)
        //            {
        //                myDataRow[i] = dataReader[i].ToString();
        //            }
        //            datatable.Rows.Add(myDataRow);
        //            myDataRow = null;
        //        }
        //        schemaTable = null;
        //        dataReader.Close();
        //        return datatable;
        //    }
        //    catch(Exception ex)
        //    {
        //        ///抛出类型转换错误
        //        throw new Exception("转换出错出错!",ex);
        //    }

        //}
        public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        {
            ///定义DataTable
            DataTable datatable = new DataTable();

            try
            { ///动态添加表的数据列
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = dataReader.GetFieldType(i);
                    myDataColumn.ColumnName = dataReader.GetName(i);
                    datatable.Columns.Add(myDataColumn);
                }

                ///添加表的数据
                while (dataReader.Read())
                {
                    DataRow myDataRow = datatable.NewRow();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        myDataRow[i] = dataReader[i].ToString();
                    }
                    datatable.Rows.Add(myDataRow);
                    myDataRow = null;
                }
            }
            catch (Exception ex)
            {
                ///抛出类型转换错误
                //SystemError.SystemLog(ex.Message);
                throw new Exception("转换出错出错!", ex);
            }
            finally
            {
                ///关闭数据读取器
                dataReader.Close();
            }

            return datatable;
        }

        /// <summary>
        /// 将英文的星期几转为中文
        /// </summary>	
        public static string ConvertDayOfWeekToZh(System.DayOfWeek dw)
        {
            string DayOfWeekZh = "";
            switch (dw.ToString("D"))
            {
                case "0":
                    DayOfWeekZh = "日";
                    break;
                case "1":
                    DayOfWeekZh = "一";
                    break;
                case "2":
                    DayOfWeekZh = "二";
                    break;
                case "3":
                    DayOfWeekZh = "三";
                    break;
                case "4":
                    DayOfWeekZh = "四";
                    break;
                case "5":
                    DayOfWeekZh = "五";
                    break;
                case "6":
                    DayOfWeekZh = "六";
                    break;
            }

            return DayOfWeekZh;
        }
        /// <summary>
        /// 提示窗口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public void MessageBox(string url, string message, int type)
        {
            if (type == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('" + message + "');location.href='" + url + "';</script>");

            }
            else if (type == 1)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('" + message + "');parent.location.href='" + url + "';</script>");
            }
            else if (type == 2)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('" + message + "');window.close();</script>");
            }
            else if (type == 3)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('" + message + "');history.go(-1);</script>");
            }
        }
        /// <summary>
        /// 生成各类随机密码,包括纯字母,纯数字,带特殊字符等,除非字母大写密码类型,其余方式都将采用小写密码
        /// </summary>
        /// <param name="pwdType">密码类型 大写为"UPPER",小写为"LOWER",数字为"NUMBER",字母与数字为"NUMCHAR",数字字母字符都包括为"ALL" </param>
        /// <param name="length">密码长度,最小为6位</param>
        /// <returns></returns>
        public static string MakeRandomPassword(string pwdType, int length)
        {
            //定义密码字符的范围,小写,大写字母,数字以及特殊字符
            string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numnberChars = "0123456789";
            string specialCahrs = "~!@#$%^&*()_+|-=,./[]{}:;'";   //"\" 转义字符不添加 "号不添加

            string tmpStr = "";

            int iRandNum;
            Random rnd = new Random();

            length = (length < 6) ? 6 : length; //密码长度必须大于6,否则自动取6

            // LOWER为小写 UPPER为大写 NUMBER为数字 NUMCHAR为数字和字母 ALL全部包含 五种方式
            //只有当选择UPPER才会有大写字母产生,其余方式中的字母都为小写,避免有些时候字母不区分大小写
            if (pwdType == "LOWER")
            {
                for (int i = 0; i < length; i++)
                {
                    iRandNum = rnd.Next(lowerChars.Length);
                    tmpStr += lowerChars[iRandNum];
                }
            }
            else if (pwdType == "UPPER")
            {
                for (int i = 0; i < length; i++)
                {
                    iRandNum = rnd.Next(upperChars.Length);
                    tmpStr += upperChars[iRandNum];
                }
            }
            else if (pwdType == "NUMBER")
            {
                for (int i = 0; i < length; i++)
                {
                    iRandNum = rnd.Next(numnberChars.Length);
                    tmpStr += numnberChars[iRandNum];
                }
            }
            else if (pwdType == "NUMCHAR")
            {
                int numLength = rnd.Next(length);
                //去掉随机数为0的情况
                if (numLength == 0)
                {
                    numLength = 1;
                }
                int charLength = length - numLength;
                string rndStr = "";
                for (int i = 0; i < numLength; i++)
                {
                    iRandNum = rnd.Next(numnberChars.Length);
                    tmpStr += numnberChars[iRandNum];
                }
                for (int i = 0; i < charLength; i++)
                {
                    iRandNum = rnd.Next(lowerChars.Length);
                    tmpStr += lowerChars[iRandNum];
                }
                //将取得的字符串随机打乱
                for (int i = 0; i < length; i++)
                {
                    int n = rnd.Next(tmpStr.Length);
                    //去除n随机为0的情况
                    //n = (n == 0) ? 1 : n;
                    rndStr += tmpStr[n];
                    tmpStr = tmpStr.Remove(n, 1);
                }
                tmpStr = rndStr;
            }
            else if (pwdType == "ALL")
            {
                int numLength = rnd.Next(length - 1);
                //去掉随机数为0的情况
                if (numLength == 0)
                {
                    numLength = 1;
                }
                int charLength = rnd.Next(length - numLength);
                if (charLength == 0)
                {
                    charLength = 1;
                }
                int specCharLength = length - numLength - charLength;
                string rndStr = "";
                for (int i = 0; i < numLength; i++)
                {
                    iRandNum = rnd.Next(numnberChars.Length);
                    tmpStr += numnberChars[iRandNum];
                }
                for (int i = 0; i < charLength; i++)
                {
                    iRandNum = rnd.Next(lowerChars.Length);
                    tmpStr += lowerChars[iRandNum];
                }
                for (int i = 0; i < specCharLength; i++)
                {
                    iRandNum = rnd.Next(specialCahrs.Length);
                    tmpStr += specialCahrs[iRandNum];
                }
                //将取得的字符串随机打乱
                for (int i = 0; i < length; i++)
                {
                    int n = rnd.Next(tmpStr.Length);
                    //去除n随机为0的情况
                    //n = (n == 0) ? 1 : n;
                    rndStr += tmpStr[n];
                    tmpStr = tmpStr.Remove(n, 1);
                }
                tmpStr = rndStr;
            }
            //默认将返回数字类型的密码
            else
            {
                for (int i = 0; i < length; i++)
                {
                    iRandNum = rnd.Next(numnberChars.Length);
                    tmpStr += numnberChars[iRandNum];
                }
            }
            return tmpStr;
        }
    }

    /// <summary>
    /// 错误处理函数，用于记录错误日志
    /// </summary>
    public class SystemError
    {
        //记录错误日志位置
        private const string FILE_NAME = "c:\\OfficeAutolog.txt";

        /// <summary>
        /// 记录日志至文本文件
        /// </summary>
        /// <param name="message">记录的内容</param>
        public static void SystemLog(string message)
        {
            //			if(File.Exists(FILE_NAME))
            //			{
            //				///如果日志文件已经存在，则直接写入日志文件
            //				StreamWriter sr = File.AppendText(FILE_NAME);
            //				sr.WriteLine ("\n");
            //				sr.WriteLine (DateTime.Now.ToString()+message);
            //				sr.Close();
            //			}
            //			else
            //			{
            //				///创建日志文件
            //				StreamWriter sr = File.CreateText(FILE_NAME);
            //				sr.Close();
            //			}				
        }
    }

    //自定义Exception
    public class MyException : Exception
    {
        //包含系统Excepton
        public MyException(string source, string message, Exception inner)
            : base(message, inner)
        {
            base.Source = source;
        }

        //不包含系统Exception
        public MyException(string source, string message)
            : base(message)
        {
            base.Source = source;
        }
    }

    /// <summary>
    /// 处理网页中的HTML代码，并消除危险字符
    /// </summary>
    public class SystemHTML
    {
        private static string HTMLEncode(string fString)
        {
            if (fString != string.Empty)
            {
                ///替换尖括号
                fString.Replace("<", "&lt;");
                fString.Replace(">", "&rt;");
                ///替换引号
                fString.Replace(((char)34).ToString(), "&quot;");
                fString.Replace(((char)39).ToString(), "&#39;");
                ///替换空格
                fString.Replace(((char)13).ToString(), "");
                ///替换换行符
                fString.Replace(((char)10).ToString(), "<BR>");
            }
            return (fString);
        }
    }
}

