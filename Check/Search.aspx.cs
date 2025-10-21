using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using basic;
using WebApp.Components;
using System.Text;
using System.IO;

public partial class Check_Search : System.Web.UI.Page
{
    public BasicPage bp = new BasicPage();
    public MyClass mc = new MyClass();
    public int ClassID;
    public string strParentColumnName = null;
    public string strColumnName = "搜索结果";
    public string KeyName = "";
    public string strPath = null;
    public SystemTools systemtools = new SystemTools();
    public bool IsIndex = false;
    public string yangban;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Index = HttpContext.Current.Server.MapPath("/index.html");
        if (File.Exists(Index))
        {
            //这时候是生成静态情况
            IsIndex = true;
        }
        KeyName = basic.Tools.RequestClass.GetQueryString("KeyName");
        page = basic.Tools.RequestClass.GetQueryInt("page", 1);
        if (!Page.IsPostBack)
        {
            strsql = ComSQL(KeyName);
            orderby = "Paixu desc,ProId desc";
            RptBind(strsql, orderby);
        }
        ProZidingyi.Visible = false;
        ProMoban.Visible = false;
        yangban = mc.ShowWebsiteKeyById(1, "ProSample");
        if (yangban == "" || yangban == "99")
        {
            ProZidingyi.Visible = true;
            if (IsIndex)
            {
                GetMobanhtml2();
            }
            else
            {
                GetMobanhtml();
            }
        }
        else
        {
            ProMoban.Visible = true;
            if (IsIndex)
            {
                GetMobanhtml2();
            }
            else
            {
                GetMobanhtml();
            }
        }
    }

    #region 分页 绑定数据

    public string strsql, orderby;
    public DataSet dsNews = new DataSet();
    public int intNews;
    public int intTotalCount = 1;
    public int intUnm = 0;//共多少条记录
    public int page = 1;//第几页
    public int Num;//前多少页
    public int pageNum = 12;//每页的页数
    private void RptBind(string _strWhere, string _orderby)
    {
        Num = (page - 1) * pageNum;
        showpageNum();//总数
        intTotalCount = ShowintTotalCount(intUnm, pageNum);

        StringBuilder strSql1 = new StringBuilder();
        strSql1.Append("select top " + pageNum + " ProName,ProId,ProPath,ProKeyDescription from Product ");
        strSql1.Append(" where ");
        strSql1.Append(_strWhere);
        strSql1.Append(" and ProId not in ");
        strSql1.Append(" ( ");
        strSql1.Append(" select top " + Num + " ProId from Product ");
        strSql1.Append(" where  ");
        strSql1.Append(_strWhere);
        strSql1.Append(" order by ");
        strSql1.Append(_orderby);
        strSql1.Append(" ) ");
        strSql1.Append(" order by ");
        strSql1.Append(_orderby);

        dsNews = bp.SelectDataBase("Product", strSql1.ToString());
        intNews = dsNews.Tables[0].Rows.Count;

        //this.DataList2.DataSource = dsNews;
        //this.DataList2.DataBind();
    }
    //总条数
    protected void showpageNum()
    {
        SqlDataReader myread = bp.getRead("select count(ProId) as CountId from Product where " + strsql);
        if (myread.Read())
        {
            intUnm = Convert.ToInt32(myread["CountId"].ToString());
        }
        myread.Close();
    }

    //计算一共多少页
    public int ShowintTotalCount(int Total, int PageSize)
    {
        if (Total % PageSize == 0)
        {
            return Total / PageSize;
        }
        else
        {
            return Total / PageSize + 1;
        }
    }
    //sql组合

    public string ComSQL(string KeyName)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" ProId >0 ");
        if (!string.IsNullOrEmpty(KeyName))
        {
            strSql.Append(" and (ProName like '%" + KeyName + "%' or ProBianhao like '%" + KeyName + "%')");
        }
        else
        {
            strSql.Append(" and ProId =0");

        }
        return strSql.ToString();
    }
    #endregion

    public string strhtml = "";
    public void GetMobanhtml()
    {

        if (yangban == "1" || yangban == "" || yangban == "99")
        {
            strhtml += "<div class=\"update_product1\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"ProDetail.aspx?Proid=" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\" >";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"pro_img\">";
                strhtml += "<tr>";
                strhtml += "<td>";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "></td>";
                strhtml += "</tr>";
                strhtml += "</table>";
                strhtml += "<div class=\"pro_search\">";
                strhtml += "<i>";
                strhtml += "<img src=\"/images/pro_search.png\"></i>";
                strhtml += "</div>";
                strhtml += "</div>";
                strhtml += "<div class=\"pro_tit\">" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
        }
        else if (yangban == "2")
        {
            strhtml += "<div class=\"update_product2\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"ProDetail.aspx?ProId=" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\" >";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"pro_img\">";
                strhtml += "<tr>";
                strhtml += "<td valign=\"middle\">";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\"></td>";
                strhtml += "</tr>";
                strhtml += "</table>";
                strhtml += "</div>";
                strhtml += "<div class=\"pro_tit\">" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";


        }
        else if (yangban == "3")
        {
            strhtml += "<div class=\"update_product3\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"ProDetail.aspx?ProId=" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\">";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"pro_img\">";
                strhtml += "<tr>";
                strhtml += "<td valign=\"middle\">";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\"></td>";
                strhtml += "</tr>";
                strhtml += "</table>";
                strhtml += "</div>";
                strhtml += "<div class=\"pro_tit\">" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
        }
        else if (yangban == "4")
        {
            strhtml += "<div class=\"update_product4\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"ProDetail.aspx?ProId=" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\">";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\"></div>";
                strhtml += "<div class=\"pro_tit\"><strong><a href=\"ProDetail.aspx?ProId=" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\">" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</a></strong><div class=\"pro_desc\">" + dsNews.Tables[0].Rows[i]["ProKeyDescription"].ToString() + "</div>";
                strhtml += "<div class=\"pro_price\"><a href=\"tencent://message/?uin=" + mc.ShowWebsiteKeyById(1, "QQ") + "&Site=Sambow&Menu=yes\" class=\"a1\">在线咨询</a><a href=\"ProDetail.aspx?ProId=" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" class=\"a2\">查看详情</a></div>";
                strhtml += "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
        }
    }
    public void GetMobanhtml2()
    {

        if (yangban == "1" || yangban == "" || yangban == "99")
        {
            strhtml += "<div class=\"update_product1\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"/html/product/d/" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + ".html\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\" >";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"pro_img\">";
                strhtml += "<tr>";
                strhtml += "<td>";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "></td>";
                strhtml += "</tr>";
                strhtml += "</table>";
                strhtml += "<div class=\"pro_search\">";
                strhtml += "<i>";
                strhtml += "<img src=\"/images/pro_search.png\"></i>";
                strhtml += "</div>";
                strhtml += "</div>";
                strhtml += "<div class=\"pro_tit\">" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
        }
        else if (yangban == "2")
        {
            strhtml += "<div class=\"update_product2\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"/html/product/d/" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + ".html\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\" >";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"pro_img\">";
                strhtml += "<tr>";
                strhtml += "<td valign=\"middle\">";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\"></td>";
                strhtml += "</tr>";
                strhtml += "</table>";
                strhtml += "</div>";
                strhtml += "<div class=\"pro_tit\">" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";


        }
        else if (yangban == "3")
        {
            strhtml += "<div class=\"update_product3\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"/html/product/d/" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + ".html\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\">";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"pro_img\">";
                strhtml += "<tr>";
                strhtml += "<td valign=\"middle\">";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\"></td>";
                strhtml += "</tr>";
                strhtml += "</table>";
                strhtml += "</div>";
                strhtml += "<div class=\"pro_tit\">" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
        }
        else if (yangban == "4")
        {
            strhtml += "<div class=\"update_product4\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"/html/product/d/" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + ".html\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\">";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\"></div>";
                strhtml += "<div class=\"pro_tit\"><strong><a href=\"/html/product/d/" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + ".html\" title=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\">" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</a></strong><div class=\"pro_desc\">" + dsNews.Tables[0].Rows[i]["ProKeyDescription"].ToString() + "</div>";
                strhtml += "<div class=\"pro_price\"><a href=\"tencent://message/?uin=" + mc.ShowWebsiteKeyById(1, "QQ") + "&Site=Sambow&Menu=yes\" class=\"a1\">在线咨询</a><a href=\"/html/product/d/" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + ".html\" class=\"a2\">查看详情</a></div>";
                strhtml += "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
        }
    }
}

