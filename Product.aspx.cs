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

public partial class Product : System.Web.UI.Page
{
    public MyClass mc = new MyClass();
    public BasicPage bp = new BasicPage();
    public int ClassID;
    public string strParentColumnName = null;
    public string strColumnName = "PRODUCTS";
    public string strColumnSubName = "PRODUCTS";
    public string strPath = null;
    public SystemTools systemtools = new SystemTools();
    public string yangban;
    public int intTypeID;

    protected void Page_Load(object sender, EventArgs e)
    {

        //调用类
        Common common = new Common();
        //读取整站SEO的设置信息
        ClientSEO clientseo = common.showSEO();
        this.Title = strColumnName + "-" + mc.ShowWebsiteKeyById(1, "CompanyName");
        description.Attributes["content"] = clientseo.WebDescription;
        keywords.Attributes["content"] = clientseo.WebKeywords;
        intTypeID = basic.Tools.RequestClass.GetQueryInt("TypeID", 0);
        page = basic.Tools.RequestClass.GetQueryInt("page", 1);

        if (!Page.IsPostBack)
        {
            strsql = ComSQL(intTypeID);
            orderby = "Paixu desc,ProId desc";
            RptBind(strsql, orderby);
            showseo();
        }
        ProZidingyi.Visible = false;
        ProMoban.Visible = false;
        yangban = mc.ShowWebsiteKeyById(1, "ProSample");
        if (yangban == "" || yangban == "99")
        {
            ProZidingyi.Visible = true;
        }
        else
        {
            ProMoban.Visible = true;
            GetMobanhtml();
        }
    }

    //显示seo
    public void showseo()
    {
        if (intTypeID > 0)
        {
            SqlDataReader reader = bp.getRead("select content,context from ProClass where id=" + intTypeID);
            if (reader.Read())
            {
                string neiron = reader["content"].ToString();
                string context = reader["context"].ToString();

                this.Title = context + "-" + mc.ShowWebsiteKeyById(1, "CompanyName");
                //seo
                int len = neiron.Split('^').Length;
                if (len > 1)
                {
                    if (!string.IsNullOrEmpty(neiron.Split('^')[1].ToString()))
                        this.Title = neiron.Split('^')[1];
                    if (!string.IsNullOrEmpty(neiron.Split('^')[2].ToString()))
                        description.Attributes["content"] = neiron.Split('^')[2];
                    if (!string.IsNullOrEmpty(neiron.Split('^')[3].ToString()))
                        keywords.Attributes["content"] = neiron.Split('^')[3];
                }
            }
            reader.Close();
        }
        else
        {
            SqlDataReader reader = bp.getRead("select ColumnTitle,ColumnDescription,ColumnKeywords from ColumnList where ColumnType='产品列表' order by ColumnNo desc,id asc");
            if (reader.Read())
            {
                string ColumnTitle = reader["ColumnTitle"].ToString();
                string ColumnDescription = reader["ColumnDescription"].ToString();
                string ColumnKeywords = reader["ColumnKeywords"].ToString();
                //seo
                if (!string.IsNullOrEmpty(ColumnTitle))
                    this.Title = ColumnTitle;
                if (!string.IsNullOrEmpty(ColumnDescription))
                    description.Attributes["content"] = ColumnDescription;
                if (!string.IsNullOrEmpty(ColumnKeywords))
                    keywords.Attributes["content"] = ColumnKeywords;
            }
            reader.Close();

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
        strSql1.Append("select top " + pageNum + " * from Product ");
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

    public string ComSQL(int classid)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(" ProId >0 ");
        if (classid > 0)
            strSql.Append(" and ClassId like '%," + classid + ",%'");
        return strSql.ToString();
    }
    #endregion

    public string strhtml = "";
    public void GetMobanhtml()
    {

        if (yangban == "1")
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
                strhtml += "<img src=\"images/pro_search.png\"></i>";
                strhtml += "</div>";
                strhtml += "</div>";
                strhtml += "<div class=\"pro_tit\">"+ dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
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
                strhtml += "<div class=\"pro_tit\">"+ dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
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
                strhtml += "<div class=\"pro_tit\">"+ dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</div>";
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
                strhtml += "<li><a href=\"ProDetail.aspx?ProId="+ dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" title=\""+ dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\">";
                strhtml += "<div class=\"pro_pic\">";
                strhtml += "<img src=\"/" + dsNews.Tables[0].Rows[i]["ProPath"].ToString() + "\" alt=\"" + dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\"></div>";
                strhtml += "<div class=\"pro_tit\"><strong><a href=\"ProDetail.aspx?ProId="+ dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" title=\""+ dsNews.Tables[0].Rows[i]["ProName"].ToString() + "\">"+ dsNews.Tables[0].Rows[i]["ProName"].ToString() + "</a></strong><div class=\"pro_desc\">"+ dsNews.Tables[0].Rows[i]["ProKeyDescription"].ToString() + "</div>";
                strhtml += "<div class=\"pro_price\"><a href=\"tencent://message/?uin="+ mc.ShowWebsiteKeyById(1, "QQ") + "&Site=Sambow&Menu=yes\" class=\"a1\">在线咨询</a><a href=\"ProDetail.aspx?ProId=" + dsNews.Tables[0].Rows[i]["Proid"].ToString() + "\" class=\"a2\">查看详情</a></div>";
                strhtml += "</div>";
                strhtml += "</a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
        }
    }

}
