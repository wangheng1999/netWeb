using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Management;                     //在工程(project)的引用中，右键，添加引用
using System.DirectoryServices;             //在工程(project)的引用中，右键，添加引用
using Microsoft.JScript;                    //获取脚本解释引擎用
using System.Diagnostics;                    //速度测试用
using System.IO;

/// <summary>
/// Summary description for BasicPage
/// </summary>
/// 
namespace basic
{
    public class BasicPage : System.Web.UI.Page
    {
        public string newString;//返回被截取的字符串
        public string connstring;
        public string strSql;
        public SqlConnection myconn;
        public SqlCommand mycommand;
        public SqlDataReader myreader;
        public SqlDataAdapter myadapter;
        public DataSet ds;
        public DataView dv;
        public DataTable tzDataTable;
        //
        public string strTitle = null;
        public string strDescription = null;
        public string strKeys = null;
        public string strCssPath = null;
        //参数设置开始
        public string strServer = System.Configuration.ConfigurationManager.AppSettings["Server"].ToString();
        public string strDatabase = System.Configuration.ConfigurationManager.AppSettings["Database"].ToString();
        public string strUid = System.Configuration.ConfigurationManager.AppSettings["UID"].ToString();
        public string strPwd = System.Configuration.ConfigurationManager.AppSettings["PWD"].ToString();
        String Connstring;
        SqlConnection Myconn;
        SqlCommand Mycommand;
        SqlDataReader Myreader;
        public void connection()
        {
            //IpLock(HttpContext.Current.Request.UserHostAddress);
            //StartProcessRequest();
            connstring = "Server=" + ConfigurationManager.AppSettings["Server"].ToString() + ";Database=" + ConfigurationManager.AppSettings["Database"].ToString() + ";UID=" + ConfigurationManager.AppSettings["UID"].ToString() + ";PWD=" + ConfigurationManager.AppSettings["PWD"].ToString();
            myconn = new SqlConnection(connstring);
        }
        public void dbOpen()
        {
            connection();
            myconn.Open();
        }
        public void dbClose()
        {
            myconn.Close();
        }
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
        ///返回数据集
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tempStrSQL"></param>
        /// <returns></returns>
        public DataSet SelectDataBase(string tableName, string tempStrSQL)
        {
            connection();
            ds = new DataSet();
            this.myadapter = new SqlDataAdapter(tempStrSQL, this.myconn);
            this.myadapter.Fill(ds, tableName);

            return ds;
        }
        /// <summary>
        /// 返回单条数据
        /// </summary>
        /// <param name="tempStrSql"></param>
        /// <returns></returns>
        public SqlDataReader getRead(string tempStrSql)
        {
            connection();
            SqlCommand mycommand = new SqlCommand(tempStrSql, myconn);
            myconn.Open();
            SqlDataReader myreader = mycommand.ExecuteReader(CommandBehavior.CloseConnection);
            return myreader;
        }
        /// <summary>
        /// 执行更新操作
        /// </summary>
        /// <param name="tempStrSql"></param>
        /// <returns></returns>
        public bool doExecute(string tempStrSql)
        {
            connection();
            SqlCommand mycommand = new SqlCommand(tempStrSql, myconn);
            myconn.Open();
            try
            {
                mycommand.ExecuteNonQuery();
                return true;
            }
            finally
            {
                mycommand.Dispose();
                myconn.Close();
                myconn.Dispose();
            }
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string CutString(string str, int length)
        {
            if (str != "")
            {
                if (str.Length > length)
                {
                    newString = str.Substring(0, length) + "...";
                }
                else
                {
                    newString = str;
                }
            }
            return newString;
        }
        /// <summary>
        /// 清空浏览器客户端的缓存
        /// </summary>
        public bool ClearClientPageCache()
        {
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.AddHeader("pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("cache-control", "private");
            HttpContext.Current.Response.CacheControl = "no-cache";
            return true;
        }
        /// <summary>
        /// 检测Jmail4.3邮箱组件或FSO文本读写
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public bool IsObjInstalled(string _obj)
        {
            bool IsFSOInstalled = false;
            try
            {
                Server.CreateObject(_obj);
                IsFSOInstalled = true;

            }
            catch
            {
                IsFSOInstalled = false;
            }
            return IsFSOInstalled;
        }
        /// <summary>
        /// 获取脚本解释引擎
        /// </summary>
        /// <returns></returns>
        public string JiaoBenYinqing()
        {
            return GlobalObject.ScriptEngine() + "/" + GlobalObject.ScriptEngineMajorVersion() + "." + GlobalObject.ScriptEngineMinorVersion() + "." + GlobalObject.ScriptEngineBuildVersion();
        }
        /// <summary>
        /// 获取服务器ip
        /// </summary>
        /// <returns></returns>
        public string ServerIp()
        {
            string stringMAC = "";
            string stringIP = "";
            ManagementClass MC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection MOC = MC.GetInstances();
            foreach (ManagementObject MO in MOC)
            {
                if ((bool)MO["IPEnabled"] == true)
                {
                    stringMAC += MO["MACAddress"].ToString();
                    //TextMAC.Text = stringMAC.ToString();
                    string[] IPAddresses = (string[])MO["IPAddress"];
                    if (IPAddresses.Length > 0) stringIP = IPAddresses[0];
                }
            }
            return stringIP;
        }
        /// <summary>
        /// 获取操作系统
        /// </summary>
        /// <returns></returns>
        public string ServerOS()
        {
            return System.Environment.OSVersion.ToString();
        }
        /// <summary>
        /// 整数运算速度测试
        /// </summary>
        /// <returns></returns>
        public string IntTest()
        {
            string Value;
            Stopwatch timer = new Stopwatch();
            long total = 0;
            timer.Start();
            for (int i = 1; i <= 500000; i++)
            {
                total += i;
            }
            timer.Stop();
            decimal micro = timer.Elapsed.Ticks / 10m;
            Value = "整数运算测试，正在进行50万次加法运算......已完成！<font color=red>" + micro.ToString() + "微妙" + "</font>";
            return Value;
        }
        /// <summary>
        /// 实数运算速度测试
        /// </summary>
        /// <returns></returns>
        public string FloatTest()
        {
            string Value;
            Stopwatch timer = new Stopwatch();
            long total = 0;
            timer.Start();
            for (int i = 1; i <= 200000; i++)
            {
                total *= total;
            }
            timer.Stop();
            decimal micro = timer.Elapsed.Ticks / 10m;
            Value = "浮点数运算测试，正在进行20万次乘法运算......已完成！<font color=red>" + micro.ToString() + "微妙" + "</font>";
            return Value;
        }
        public bool DbBackup(string strDbName, string strFileName, string strRname)
        {
            SQLDMO.Backup oBackup = new SQLDMO.BackupClass();
            SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
            try
            {
                oSQLServer.LoginSecure = false;
                oSQLServer.Connect(strServer, strUid, strPwd);
                oBackup.Action = SQLDMO.SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
                oBackup.Database = strDbName;

                string Path = strFileName + strRname + ".bak";
                oBackup.Files = Path;
                oBackup.BackupSetName = strRname;
                oBackup.BackupSetDescription = "备份数据库";
                oBackup.Initialize = true;
                oBackup.SQLBackup(oSQLServer);
                return true;
            }
            catch
            {
                throw;
            }
            finally
            {
                oSQLServer.DisConnect();
            }

        }
        public bool DbRestore(string strDbName, string strFileName, string strRname)
        {
            SQLDMO.Restore oRestore = new SQLDMO.RestoreClass();
            SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
            try
            {
                oSQLServer.LoginSecure = false;
                oSQLServer.Connect(strServer, strUid, strPwd);
                oRestore.Action = SQLDMO.SQLDMO_RESTORE_TYPE.SQLDMORestore_Database;
                oRestore.Database = strDbName;
                oRestore.Files = strFileName + strRname;
                oRestore.FileNumber = 1;
                oRestore.ReplaceDatabase = true;
                oRestore.SQLRestore(oSQLServer);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 管理员登陆系统代码
        /// </summary>
        /// <param name="strFile"></param>
        /// <param name="strUser"></param>
        /// <param name="strPwd"></param>
        /// <param name="strIp"></param>
        /// <returns></returns>
        public int UserLogin(string strFile, string strUser, string strPwd, string strIp)
        {
            SqlDataReader Myreader;
            int intId = 0;
            Myreader = getRead("select * from Admin where AdminName='" + strUser + "' and status=0");
            if (Myreader.Read())
            {
                Myreader.Close();
                Myreader = getRead("select * from Admin where AdminPassword='" + strPwd + "' and status=0");
                if (Myreader.Read())
                {
                    Myreader.Close();
                    if (doExecute("update Admin set lasttimes='" + DateTime.Now + "',logins=logins+1,loginip='" + strIp + "' where AdminName='" + strUser + "'"))
                    {
                        Session["j95fn3839vfn93h9n29n"] = strUser;
                        if (doExecute("insert into tblog(object,matter,times,ip,username,result,tips)values('" + strFile + "','登录后台管理系统','" + DateTime.Now + "','" + strIp + "','" + strUser + "','<b>√</b>成功','审核成功')"))
                        {
                            intId = 1;
                            //Response.Redirect("main/index.aspx");
                        }
                    }
                    else
                    {
                        intId = 2;
                        //lErrorMessage.Text = "不可预知的意外错误！";
                    }
                }
                else
                {
                    Myreader.Close();
                    doExecute("insert into tblog(object,matter,times,ip,username,result,tips)values('" + strFile + "','登录后台管理系统','" + DateTime.Now + "','" + strIp + "','" + strUser + "','<b><font color=red>×</font></b>失败','密码错误')");
                    intId = 3;
                    //lErrorMessage.Text = "密码错误！";
                }
            }
            else
            {
                Myreader.Close();
                doExecute("insert into tblog(object,matter,times,ip,username,result,tips)values('" + strFile + "','登录后台管理系统','" + DateTime.Now + "','" + strIp + "','" + strUser + "','<b><font color=red>×</font></b>失败','帐号错误')");
                intId = 4;
                //lErrorMessage.Text = "用户名错误！";
            }
            return intId;
        }
        /// <summary>
        /// 获取系统使用者名称
        /// </summary>
        /// <returns></returns>
        public string readConame()
        {
            string strConame;
            SqlDataReader Myreader;
            Myreader = getRead("select webname from tbset where id=1");
            if (Myreader.Read())
            {
                strConame = Myreader["webname"].ToString();
            }
            else
            {
                strConame = "<font color=red>暂无数据(请先进行系统基本设置)</font>";
            }
            Myreader.Close();
            return strConame;
        }
        /// <summary>
        /// 统计服务器空间占用情况
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public long GetDirectoryLength(string dirPath)
        {
            //判断给定的路径是否存在,如果不存在则退出
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;

            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(dirPath);

            //通过GetFiles方法,获取di目录中的所有文件的大小
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }

            //获取di中所有的文件夹,并存到一个新的对象数组中,以进行递归
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }
        /// <summary>
        /// 添加要锁定的IP
        /// </summary>
        /// <param name="strAddIp"></param>
        /// <returns></returns>
        public int lockip(string strAddIp)
        {
            int returnId = 0;
            int intId = 1;
            bool bsign = false;
            string strIpGroup;
            string strIp = strAddIp;
            SqlDataReader myreader = getRead("select ip from tbIp where id=1");
            if (myreader.Read())
            {
                string[] strIPzu = myreader["ip"].ToString().Split('|');
                for (int i = 0; i < strIPzu.Length; i++)
                {
                    if (strIp == strIPzu[i])
                    {
                        bsign = true;
                    }
                }
                strIpGroup = myreader["ip"].ToString();
                myreader.Close();
                if (bsign == false)
                {
                    if (strIpGroup == "")
                    {
                        strIpGroup = strIp;
                    }
                    else
                    {
                        strIpGroup = strIpGroup + "|" + strIp;
                    }
                    if (doExecute("update tbIp set ip='" + strIpGroup + "' where id=1"))
                    {
                        //Response.Redirect("Success.aspx?message=IP锁定成功！&url=IpManage.aspx");
                        returnId = 1;
                    }
                }
                else if (bsign == true)
                {
                    //Response.Redirect("Error.aspx?message=锁定失败，该IP已被锁定！&url=IpManage.aspx");
                    returnId = 2;
                }
            }
            else
            {
                myreader.Close();
                if (doExecute("insert into tbIp(id,ip)values(" + intId + ",'" + strIp + "')"))
                {
                    //Response.Redirect("Success.aspx?message=IP锁定成功！&url=IpManage.aspx");
                    returnId = 3;
                }
            }
            return returnId;
        }
        /// <summary>
        /// 显示被锁定IP
        /// </summary>
        /// <returns></returns>
        public string showLockIp()
        {
            string strIp = "";
            SqlDataReader myreader = getRead("select ip from tbIp where id=1");
            if (myreader.Read())
            {
                strIp = myreader["ip"].ToString();
            }
            myreader.Close();
            return strIp.Trim();
        }
        /// <summary>
        /// 更新锁定的IP列表
        /// </summary>
        /// <param name="strIps"></param>
        /// <returns></returns>
        public bool updateIp(string strIps)
        {
            bool sign = false;
            SqlDataReader myreader = getRead("select * from tbIp where id=1");
            if (myreader.Read())
            {
                if (doExecute("update tbIp set ip='" + strIps + "' where id=1"))
                {
                    sign = true;
                }
            }
            else
            {
                int id = 1;
                if (doExecute("insert into tbIp(id,ip)values(" + id + ",'" + strIps + "')"))
                {
                    sign = true;
                }
            }
            myreader.Close();
            return sign;
        }
        /// <summary>
        /// 关闭网站提示
        /// </summary>
        /// <returns></returns>
        public string CloseWeb()
        {
            string strStateDescription = null;
            string strState = "0";
            SqlDataReader myreader = getRead("select state,statedescription from TBset where id=1");
            if (myreader.Read())
            {
                strState = myreader["state"].ToString();
                if (strState == "1")
                {
                    strStateDescription = myreader["statedescription"].ToString();
                }
            }
            myreader.Close();
            return strStateDescription;
        }
        /// <summary>
        /// 读取网站风格
        /// </summary>
        public void showCssPath()
        {
            Connstring = "Server=" + strServer + ";Database=" + strDatabase + ";UID=" + strUid + ";PWD=" + strPwd + "";
            Myconn = new SqlConnection(Connstring);
            Mycommand = new SqlCommand("GetStyleList_Client", Myconn);
            Mycommand.CommandType = CommandType.StoredProcedure;
            Myconn.Open();
            try
            {
                Myreader = Mycommand.ExecuteReader();
                if (Myreader.Read())
                {
                    strCssPath = Myreader["StyleUrl"].ToString();
                }
            }
            finally
            {
                Myreader.Close();
                Myconn.Close();
            }
        }
        /// <summary>
        /// 读取Title,Description,Keys
        /// </summary>
        public void showWebTitle()
        {
            int intId = 1;
            Connstring = "Server=" + strServer + ";Database=" + strDatabase + ";UID=" + strUid + ";PWD=" + strPwd + "";
            Myconn = new SqlConnection(Connstring);
            Mycommand = new SqlCommand("GetWebsite_Id", Myconn);
            Mycommand.CommandType = CommandType.StoredProcedure;
            Mycommand.Parameters.Add("@Id", SqlDbType.Int).Value = intId;
            Myconn.Open();
            try
            {
                Myreader = Mycommand.ExecuteReader();
                if (Myreader.Read())
                {
                    strTitle = Myreader["webtitle"].ToString();
                    strDescription = Myreader["webdescription"].ToString();
                    strKeys = Myreader["webkeys"].ToString();
                }
            }
            finally
            {
                Myreader.Close();
                Myconn.Close();
            }
        }
        public string showWeatherForecast()
        {
            string strContent = "";
            SqlDataReader myreader = getRead("select content from TbWeatherForecast where id=1");
            if (myreader.Read())
            {
                strContent = myreader["content"].ToString();
            }
            else
            {
                strContent = "没有初始化！";
            }
            myreader.Close();
            return strContent;
        }
        public static void StartProcessRequest()
        {

            //            System.Web.HttpContext.Current.Response.Write("<script>alert('dddd');</script>");
            try
            {
                string getkeys = "";
                //string sqlErrorPage = System.Configuration.ConfigurationManager.AppSettings["CustomErrorPage"].ToString();
                if (System.Web.HttpContext.Current.Request.QueryString != null)
                {

                    for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys], 0))
                        {
                            //System.Web.HttpContext.Current.Response.Redirect (sqlErrorPage+"?errmsg=sqlserver&sqlprocess=true");
                            System.Web.HttpContext.Current.Response.Write("您的请求带有不合法的参数，谢谢合作！1");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
                if (System.Web.HttpContext.Current.Request.Form != null)
                {
                    for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.Form.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.Form[getkeys], 1))
                        {
                            //System.Web.HttpContext.Current.Response.Redirect (sqlErrorPage+"?errmsg=sqlserver&sqlprocess=true");
                            System.Web.HttpContext.Current.Response.Write("您的请求带有不合法的参数，谢谢合作！1");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
            }
            catch
            {
                // 错误处理: 处理用户提交信息!
            }
        }
        /**/
        /// <summary>
        /// 分析用户请求是否正常
        /// </summary>
        /// <param name="Str">传入用户提交数据</param>
        /// <returns>返回是否含有SQL注入式攻击代码</returns>
        private static bool ProcessSqlStr(string Str, int type)
        {
            string SqlStr;

            if (type == 1)
                SqlStr = "exec|insert|select|delete|update|count|chr|mid|master|truncate|char|declare";
            else
                SqlStr = "'|and|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";

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
        /// 取最大的Id值
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int SelectMaxId(string strSql)
        {
            int intId = 1;
            SqlDataReader myreader = getRead(strSql);
            if (myreader.Read())
            {
                intId = System.Convert.ToInt16(myreader["id"]) + 1;
            }
            myreader.Close();
            return intId;
        }
        public void IpLock(string ip)
        {
            connstring = "Server=" + strServer + ";Database=" + strDatabase + ";UID=" + strUid + ";PWD=" + strPwd + "";
            myconn = new SqlConnection(connstring);
            SqlCommand mycommand = new SqlCommand("select * from tbip", myconn);
            myconn.Open();
            SqlDataReader myreader = mycommand.ExecuteReader(CommandBehavior.CloseConnection);
            bool sign = false;
            string strIp = null;
            if (myreader.Read())
            {
                strIp = myreader["ip"].ToString();
            }
            myreader.Close();
            myconn.Close();
            if (strIp != null)
            {
                string[] list = strIp.Split('|');
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == ip) { sign = true; break; }
                }
                if (sign == true)
                {
                    HttpContext.Current.Response.Redirect("jinzhi.html");
                }
            }
        }
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="oText"></param>
        /// <returns></returns>
        public bool IsNumberic(string oText)//判断是否是数字
        {
            try
            {
                int var1 = System.Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 截取字符串
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
            return tempString;
        }
    }
}

