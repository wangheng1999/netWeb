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
using basic;
using System.Text.RegularExpressions;

/// <summary>
/// MyClass 的摘要说明
/// </summary>
namespace WebApp.Components
{
    public class MyClass
    {
        BasicPage bp = new BasicPage();

        /// <summary>
        /// 查询图片
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string SelectPicByClassID(int ID)
        {
            string strPath = "";
            SqlDataReader myread = bp.getRead("select path from tbPic where ClassID=" + ID + "");
            if (myread.Read())
            {
                strPath = myread["path"].ToString();
            }
            myread.Close();
            return strPath;
        }
        /// <summary>
        /// 查询图片的字段根据阿弟{阿弟，字段}
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string SelectPicKeyByClassID(int ID, string Key)
        {
            string strPath = "";
            SqlDataReader myread = bp.getRead("select " + Key + " from tbPic where ClassID=" + ID + "");
            if (myread.Read())
            {
                strPath = myread[0].ToString();
            }
            myread.Close();
            return strPath;
        }
        /// <summary>
        /// 嵌入Flash
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string SelectSwfByClassID(int ID)
        {
            string str = null;
            SqlDataReader dr = bp.getRead("select Length,Width,Path from tbPic where ClassID=" + ID + "");
            if (dr.Read())
            {
                str = "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0'>";
                str = str + "<param name='movie' value='" + dr["Path"].ToString() + "' />";
                str = str + "<param name='quality' value='high' />";
                str = str + "<param name='wmode' value='transparent' />";
                str = str + "<embed src='" + dr["Path"].ToString() + "' width='" + dr["Width"].ToString() + "' height='" + dr["Length"].ToString() + "' align='center' quality='high' pluginspage='http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash'></embed>";
                str = str + "</object>";
            }
            dr.Close();
            return str;
        }
        /// <summary>
        /// 通过栏目ID获取栏目图片
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetColumnListPath(int ID)
        {
            string strPath = null;
            Common common = new Common();
            ClientColumnName clientcolumnname = new ClientColumnName();
            clientcolumnname = common.showColumnName(ID);
            //显示图片或者Flash
            strPath = clientcolumnname.Path;
            string strType = null;
            if (strPath.Length >= 3)
            {
                strType = strPath.Substring(strPath.Length - 3, 3);
            }
            string strLength = clientcolumnname.Length;
            string strWidth = clientcolumnname.Width;
            if (strType == "swf")
            {
                strPath = "<script type=\"text/javascript\">F_viewSwf('" + strWidth + "','" + strLength + "','transparent','transparent','" + strPath + "');</script>";
            }
            else
            {
                strPath = "<img src='" + clientcolumnname.Path + "' alt='' />"; //显示内页通栏图片
            }
            return strPath;
        }
        /// <summary>
        /// 查询新闻
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataSet ShowNews(int ClassID, int Top)
        {
            string strSQL = null;
            if (Top == 0)
            {
                strSQL = "select ID,Title,Url,Path,KeyContent,Keywords,Putdate from News where ClassId=" + ClassID + " order by paixu desc,Istop desc,CONVERT(varchar(100),Putdate,23) desc,ID desc";
            }
            else
            {
                strSQL = "select top " + Top + " ID,Title,Url,Path,KeyContent,Keywords,Putdate from News where ClassId=" + ClassID + " order by paixu desc,Istop desc,CONVERT(varchar(100),Putdate,23) desc,ID desc";
            }
            DataSet dstNews = new DataSet();
            dstNews = bp.SelectDataBase("News", strSQL);
            return dstNews;
        }
        /// <summary>
        /// 查找单条内容
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string ShowAbout(int ID)
        {
            string content = "";
            SqlDataReader myread = bp.getRead("select content from News where classid=" + ID + "");
            if (myread.Read())
            {
                content = myread["content"].ToString();
            }
            myread.Close();
            return content;
        }

        /// <summary>
        /// 查找联系方式里的字段
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string ShowWebsiteKeyById(int ID, string key)
        {
            string content = "";
            SqlDataReader myread = bp.getRead("select " + key + " from Website where id=" + ID);
            if (myread.Read())
            {
                content = myread[0].ToString();
            }
            myread.Close();
            return content;
        }
        /// <summary>
        /// 查找单条内容的某个字段
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string ShowNewsKeyById(int ID, string key)
        {
            string content = "";
            SqlDataReader myread = bp.getRead("select " + key + " from News where id=" + ID + "");
            if (myread.Read())
            {
                content = myread[0].ToString();
            }
            myread.Close();
            return content;
        }
        /// <summary>
        /// 查找ColumnName
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string ShowColumnName(int ID)
        {
            string ColumnName = "";
            SqlDataReader myread = bp.getRead("select ColumnName from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                ColumnName = myread["ColumnName"].ToString();
            }
            myread.Close();
            return ColumnName;
        }
        /// <summary>
        /// 查找ColumnSubName
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string ShowColumnSubName(int ID)
        {
            string ColumnSubName = "";
            SqlDataReader myread = bp.getRead("select ColumnSubName from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                ColumnSubName = myread["ColumnSubName"].ToString();
            }
            myread.Close();
            return ColumnSubName;
        }

        /// <summary>
        /// 查找栏目的某个属性{栏目阿弟，字段名称}
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string ShowColumnKeyById(int ID, string Key)
        {
            string ColumnName = "";
            SqlDataReader myread = bp.getRead("select " + Key + " from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                ColumnName = myread[0].ToString();
            }
            myread.Close();
            return ColumnName;
        }
        /// <summary>
        /// 根据子分类ID读取其父级的所有子分类
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public DataSet SelectAllSubMenu(int intID)
        {
            DataSet dstMenu = bp.SelectDataBase("ColumnList", "select * from ColumnList where ParentId in (select ParentId from ColumnList where ID=" + intID + " and ParentId<>'0') order by ColumnNo desc,Id asc");
            return dstMenu;
        }
        /// <summary>
        /// 读取所有子分类
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public DataSet SelectSubMenu(int intID)
        {
            DataSet dstMenu = bp.SelectDataBase("ColumnList", "select ID,ColumnName,ColumnUrlClient from ColumnList where ParentId=" + intID + " order by ColumnNo asc,Id asc");
            return dstMenu;
        }
        /// <summary>
        /// 去除html样式
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public string DropHTML(string Htmlstring)
        {
            if (Htmlstring == "") return "";
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&ldquo;", "“", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&rdquo;", "”", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&hellip;", "…", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        /// <summary>
        /// 获取后台创建的表单内容
        /// </summary>
        /// <returns></returns>
        public string GetSubmitContext()
        {
            int intID = 1;
            string strContent = null;
            SqlDataReader myread = bp.getRead("select FormContent from TbSubmitForm where FormID=" + intID + "");
            if (myread.Read())
            {
                strContent = myread["FormContent"].ToString();
            }
            myread.Close();
            return strContent;
        }
        /// <summary>
        /// 判断页面动/静状态
        /// </summary>
        /// <param name="ColumnType"></param>
        /// <returns></returns>
        public string returnStaticPage(string ColumnType)
        {
            string strStaticPage = null;
            SqlDataReader reader = bp.getRead("select StaticPage from ColumnList where ColumnType='" + ColumnType + "'");
            if (reader.Read())
            {
                strStaticPage = reader["StaticPage"].ToString();
            }
            reader.Close();
            return strStaticPage;
        }
        /// <summary>
        /// 返回产品最终页地址
        /// </summary>
        /// <param name="StaticPage"></param>
        /// <param name="StaticUrl"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string returnProUrl(string StaticPage, string StaticUrl, int ID)
        {
            string strUrl = null;
            if (StaticPage == "0")
            {
                strUrl = "ProDetail.aspx?ProId=" + ID;
            }
            else
            {
                strUrl = StaticUrl;
            }
            return strUrl;
        }
        /// <summary>
        /// 返回新闻最终页地址
        /// </summary>
        /// <param name="StaticPage"></param>
        /// <param name="StaticUrl"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string returnNewsUrl(string StaticPage, string StaticUrl, int ID)
        {
            string strUrl = null;
            if (StaticPage == "0")
            {
                strUrl = "NewsDetail.aspx?ID=" + ID;
            }
            else
            {
                strUrl = StaticUrl;
            }
            return strUrl;
        }
        /// <summary>
        /// 返回下载中心
        /// </summary>
        /// <param name="StaticPage"></param>
        /// <param name="StaticUrl"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string returnDownloadUrl(string StaticPage, string StaticUrl, int ID)
        {
            string strUrl = null;
            if (StaticPage == "0")
            {
                strUrl = "DownloadDetail.aspx?ID=" + ID;
            }
            else
            {
                strUrl = StaticUrl;
            }
            return strUrl;
        }
    }
}
