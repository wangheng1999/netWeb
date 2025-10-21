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
using System.IO;
using basic;

/// <summary>
/// Summary description for StaticPage
/// </summary>
namespace WebApp.Components
{
    public class StaticPage
    {
        /// <summary>
        /// 读取模板文件内容
        /// </summary>
        /// <param name="strTmplPath"></param>
        /// <returns></returns>
        public static string re_lable(string strTmplPath)
        {
            //读取模板文件的内容
            System.Text.Encoding code = System.Text.Encoding.GetEncoding("gb2312");
            StreamReader sr = null;
            string str = "";
            try
            {
                sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("./") + strTmplPath, code);
                str = sr.ReadToEnd(); // 读取文件
                sr.Close();
            }
            catch (Exception exp)
            {
                Console.Write(exp);
            }
            return str;
        }
        public static string read_sys(string str)
        {
            return str;
        }
    }
    public class SplitPage
    {
        BasicPage bp = new BasicPage();
        public bool splitpage(string htm, int pagesize, string tableName, string sql, int intId)
        {
            int intRowCount = 0;
            int maxi = 0;
            Boolean isOk = false;
            DataSet ds = bp.SelectDataBase(tableName, sql);
            DataTable dt = ds.Tables[0];
            intRowCount = dt.Rows.Count;
            if (intRowCount > 0)
            {
                //取出所有新闻列表
                if (dt.Rows.Count % pagesize == 0)
                {
                    maxi = dt.Rows.Count / pagesize;
                }
                else
                {
                    maxi = (dt.Rows.Count / pagesize) + 1;
                }
                for (int i = 0; i < maxi; i++) // i 分页的页数(生成页面的个数)
                {
                    StringBuilder sb = new StringBuilder();//新闻列表 
                    //生成新闻列表
                    sb.Append("<div class=\"title_list\"><ul class=\"title_list bluepoint\">");
                    for (int h = i * pagesize; h < (i + 1) * pagesize; h++)//
                    {
                        if (h < dt.Rows.Count)
                        {
                            sb.Append("<li><a href=\"" + dt.Rows[h]["StaticUrl"].ToString() + "\" title=\"" + dt.Rows[h]["title"].ToString() + "\" target=\"_blank\">" + dt.Rows[h]["title"].ToString() + "</a><span>" + dt.Rows[h]["putdate"].ToString() + "</span></li>");
                        }
                    }
                    sb.Append("</ul></div><br><div class=\"tpb_right\">"); //maxi
                    sb.Append(" <a href=\"News_" + intId + "_1.html\">首页</a>");
                    if (i == 0)//判断如果为第一页，则不把“上一页”设为超链接
                    {
                        sb.Append(" <a href=\"#\">上一页</a>");
                    }
                    else
                    {
                        sb.Append(" <a href=\"News_" + intId + "_" + i + ".html\">上一页</a>");
                    }
                    if (i < 10)
                    {
                        for (int f = 1; f < 10; f++)//每页显示9个分页数字
                        {
                            if (f == i + 1)
                            {
                                sb.Append(" <a href=\"News_" + intId + "_" + f.ToString() + ".html\" class=\"cur\">" + f.ToString() + "</a>");
                            }
                            else if (f <= maxi)
                            {
                                sb.Append(" <a href=\"News_" + intId + "_" + f.ToString() + ".html\">" + f.ToString() + "</a>");
                            }
                        }
                    }
                    else
                    {
                        int maxfeye = i + 5;
                        int minfeye = i - 5;
                        for (int f = minfeye; f < maxfeye; f++)//每页显示9个分页数字
                        {
                            if (f == i + 1)
                            {
                                sb.Append(" <a href=\"News_" + intId + "_" + f.ToString() + ".html\" class=\"cur\">" + f.ToString() + "</a>");
                            }
                            else if (f <= maxi)
                            {
                                sb.Append(" <a href=\"News_" + intId + "_" + f.ToString() + ".html\">" + f.ToString() + "</a>");
                            }
                        }
                    }
                    //if (i == dt.Rows.Count / pagesize) //判断如果为最后一页，则不把“下一页”设为超链接
                    if (i == maxi - 1)
                    {
                        sb.Append(" <a href=\"#\">下一页</a>");
                    }
                    else
                    {
                        sb.Append(" <a href=\"News_" + intId + "_" + (i + 2) + ".html\">下一页</a>");
                    }
                    sb.Append(" <a href=\"News_" + intId + "_" + (maxi).ToString() + ".html\">末页</a>");
                    sb.Append("</div>");

                    Encoding code = Encoding.GetEncoding("utf-8");
                    StreamWriter sw = null;
                    string str = null;
                    str = StaticPage.re_lable(htm);
                    //根据新闻的ID

                    int fileName = i + 1;
                    string CreateFileName = "News_" + intId + "_" + fileName.ToString();
                    str = str.Replace("[$NewsList$]", sb.ToString());//替换列表标签
                    //生成静态文件
                    try
                    {
                        str = StaticPage.read_sys(str);
                        sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("../") + CreateFileName + ".html", false, code);
                        sw.Write(str);
                        sw.Flush();
                        isOk = true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            else
            {
                Encoding code = Encoding.GetEncoding("utf-8");
                StreamWriter sw = null;
                string str = null;
                str = StaticPage.re_lable(htm);
                //根据新闻的ID

                string CreateFileName = "News_" + intId + "_1";
                str = str.Replace("[$NewsList$]", "暂时没有数据");//替换列表标签
                //生成静态文件
                try
                {
                    str = StaticPage.read_sys(str);
                    sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("../") + CreateFileName + ".html", false, code);
                    sw.Write(str);
                    sw.Flush();
                    isOk = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sw.Close();
                }
            }
            return isOk;
        }
        public bool splitpageProduct(string htm, int pagesize, string tableName, string sql, int intId)
        {
            int intRowCount = 0;
            int maxi = 0;
            Boolean isOk = false;
            DataSet ds = bp.SelectDataBase(tableName, sql);
            DataTable dt = ds.Tables[0];
            intRowCount = dt.Rows.Count;
            if (intRowCount > 0)
            {
                //if (dt.Rows.Count / pagesize >= 1)
                //{
                //取出所有产品列表
                if (dt.Rows.Count % pagesize == 0)
                {
                    maxi = dt.Rows.Count / pagesize;
                }
                else
                {
                    maxi = (dt.Rows.Count / pagesize) + 1;
                }
                for (int i = 0; i < maxi; i++) // i 分页的页数(生成页面的个数)
                {
                    StringBuilder sb = new StringBuilder();//产品列表 
                    //生成产品列表
                    sb.Append("<div id=\"gallery\" class=\"title_list\"><ul class=\"title_list bluepoint\">");
                    for (int h = i * pagesize; h < (i + 1) * pagesize; h++)// 
                    {
                        if (h < dt.Rows.Count)
                        {
                            sb.Append("<li><table cellpadding=\"3\" cellspacing=\"0\" align=\"center\" class=\"pro\"><tr><td align=center style=\"border:#ddd solid 1px; width:150px; height:110px;\"><a href=\"" + dt.Rows[h]["StaticUrl"].ToString() + "\" title=\"" + dt.Rows[h]["ProName"].ToString() + "\" class=\"tooltip\"><img src=\"" + dt.Rows[h]["ProPath"].ToString() + "\" style=\"display:block;\" alt=\"" + dt.Rows[h]["ProName"].ToString() + "\"></a></td></tr><tr><td style=\"line-height:20px; width:150px; height:40px;\" align=\"center\"><a href=\"" + dt.Rows[h]["StaticUrl"].ToString() + "\" title=\"" + dt.Rows[h]["ProName"].ToString() + "\" class=\"tooltip\">" + dt.Rows[h]["ProName"].ToString() + "</a></td></tr></table></li>");
                        }
                    }
                    sb.Append("</ul></div><div class=\"clear\"></div><div class=\"tpb_right\">"); //maxi
                    sb.Append(" <a href=\"Product_" + intId + "_1.html\">首页</a>");
                    if (i == 0)//判断如果为第一页，则不把“上一页”设为超链接
                    {
                        sb.Append(" <a href=\"#\">上一页</a>");
                    }
                    else
                    {
                        sb.Append(" <a href=\"Product_" + intId + "_" + i + ".html\">上一页</a>");
                    }
                    if (i < 10)
                    {
                        for (int f = 1; f < 10; f++)//每页显示9个分页数字
                        {
                            if (f == i + 1)
                            {
                                sb.Append(" <a href=\"Product_" + intId + "_" + f.ToString() + ".html\" class=\"cur\">" + f.ToString() + "</a>");
                            }
                            else if (f <= maxi)
                            {
                                sb.Append(" <a href=\"Product_" + intId + "_" + f.ToString() + ".html\">" + f.ToString() + "</a>");
                            }
                        }
                    }
                    else
                    {
                        int maxfeye = i + 5;
                        int minfeye = i - 5;
                        for (int f = minfeye; f < maxfeye; f++)//每页显示9个分页数字
                        {
                            if (f == i + 1)
                            {
                                sb.Append(" <a href=\"Product_" + intId + "_" + f.ToString() + ".html\" class=\"cur\">" + f.ToString() + "</a>");
                            }
                            else if (f <= maxi)
                            {
                                sb.Append(" <a href=\"Product_" + intId + "_" + f.ToString() + ".html\">" + f.ToString() + "</a>");
                            }
                        }
                    }
                    //if (i == dt.Rows.Count / pagesize) //判断如果为最后一页，则不把“下一页”设为超链接
                    if (i == maxi - 1)
                    {
                        sb.Append(" <a href=\"#\">下一页</a>");
                    }
                    else
                    {
                        sb.Append(" <a href=\"Product_" + intId + "_" + (i + 2) + ".html\">下一页</a>");
                    }
                    sb.Append(" <a href=\"Product_" + intId + "_" + (maxi).ToString() + ".html\">末页</a>");
                    sb.Append("</div>");

                    Encoding code = Encoding.GetEncoding("utf-8");
                    StreamWriter sw = null;
                    string str = null;
                    str = StaticPage.re_lable(htm);
                    //根据产品的ID

                    int fileName = i + 1;
                    string CreateFileName = "Product_" + intId + "_" + fileName.ToString();
                    str = str.Replace("[$ProductList$]", sb.ToString());//替换列表标签
                    //生成静态文件
                    try
                    {
                        str = StaticPage.read_sys(str);
                        sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("../") + CreateFileName + ".html", false, code);
                        sw.Write(str);
                        sw.Flush();
                        isOk = true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sw.Close();
                    }
                    //}//for语句结束

                }
            }
            else
            {
                Encoding code = Encoding.GetEncoding("utf-8");
                StreamWriter sw = null;
                string str = null;
                str = StaticPage.re_lable(htm);
                //根据新闻的ID

                string CreateFileName = "Product_" + intId + "_1";
                str = str.Replace("[$ProductList$]", "暂时没有数据");//替换列表标签
                //生成静态文件
                try
                {
                    str = StaticPage.read_sys(str);
                    sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("../") + CreateFileName + ".html", false, code);
                    sw.Write(str);
                    sw.Flush();
                    isOk = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sw.Close();
                }
            }
            return isOk;
        }
    }
}

