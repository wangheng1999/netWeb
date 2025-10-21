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
using System.Text.RegularExpressions;
using WebApp.Components;
using System.Text;
using basic;

public partial class News2 : System.Web.UI.Page
{
    public MyClass mc = new MyClass();
    public int intClassID;
    public string strParentColumnName = null;
    public string strParentColumnSubName = null;
    public string strColumnName = null;
    public string strColumnSubName = null;
    public string strPath = null;
    int intRowCount;//用来记录总记录数
    public BasicPage bp = new BasicPage();
    public SystemTools systemtools = new SystemTools();
    public string yangban;
    protected void Page_Load(object sender, EventArgs e)
    {

        intClassID = basic.Tools.RequestClass.GetQueryInt("ClassID", 0);
        page = basic.Tools.RequestClass.GetQueryInt("page", 1);

        //调用类
        Common common = new Common();

        #region 显示栏目名称

        //显示栏目名称
        ClientColumnName clientcolumnname = new ClientColumnName();
        clientcolumnname = common.showColumnName(intClassID);
        strColumnName = clientcolumnname.ColumnName;
        strColumnSubName = clientcolumnname.ColumnSubName;
        #endregion

        #region 显示父级栏目名称

        //显示父级栏目名称
        ClientParentColumnName clientparentcolumnname = new ClientParentColumnName();
        clientparentcolumnname = common.showParentColumnName(intClassID);
        strParentColumnName = clientparentcolumnname.ParentColumnName;
        strParentColumnSubName = clientparentcolumnname.ParentColumnSubName;

        #endregion

        if (!Page.IsPostBack)
        {
            strsql = ComSQL(intClassID);
            orderby = "Paixu desc,Istop desc,CONVERT(varchar(100),Putdate,23) desc,id desc";
            RptBind(strsql, orderby);
        }

        //读取整站SEO的设置信息
        ClientSEO clientseo = common.showSEO();
        this.Title = strColumnName + "-" + mc.ShowWebsiteKeyById(1, "CompanyName");
        description.Attributes["content"] = clientseo.WebDescription;
        keywords.Attributes["content"] = strColumnName + "," + mc.ShowWebsiteKeyById(1, "CompanyName");

        #region 读取某个栏目的SEO设置信息

        ClientColumnSEO clientcolumnseo = common.showColumnSEO(intClassID);
        if (clientcolumnseo.ColumnTitle.Length > 0)
        {
            this.Title = clientcolumnseo.ColumnTitle;
        }
        if (clientcolumnseo.ColumnDescription.Length > 0)
        {
            description.Attributes["content"] = clientcolumnseo.ColumnDescription;
        }
        if (clientcolumnseo.ColumnKeywords.Length > 0)
        {
            keywords.Attributes["content"] = clientcolumnseo.ColumnKeywords;
        }
        #endregion



        NewsZidingyi.Visible = false;
        NewsMoban.Visible = false;
        yangban = mc.ShowColumnKeyById(intClassID, "Sample");
        if (yangban == "" || yangban == "99")
        {
            NewsZidingyi.Visible = true;
        }
        else
        {
            NewsMoban.Visible = true;
            GetMobanhtml();
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
    public int pageNum = 10;//每页的页数
    private void RptBind(string _strWhere, string _orderby)
    {
        Num = (page - 1) * pageNum;
        showpageNum();//总数
        intTotalCount = ShowintTotalCount(intUnm, pageNum);

        StringBuilder strSql1 = new StringBuilder();
        strSql1.Append("select top " + pageNum + " keywords,keycontent,path,id,title,url,putdate,Istop from News ");
        strSql1.Append(" where ");
        strSql1.Append(_strWhere);
        strSql1.Append(" and Id not in ");
        strSql1.Append(" ( ");
        strSql1.Append(" select top " + Num + " id from News ");
        strSql1.Append(" where  ");
        strSql1.Append(_strWhere);
        strSql1.Append(" order by ");
        strSql1.Append(_orderby);
        strSql1.Append(" ) ");
        strSql1.Append(" order by ");
        strSql1.Append(_orderby);

        dsNews = bp.SelectDataBase("News", strSql1.ToString());
        intNews = dsNews.Tables[0].Rows.Count;

        this.DataList2.DataSource = dsNews;
        this.DataList2.DataBind();

    }
    //总条数
    protected void showpageNum()
    {
        SqlDataReader myread = bp.getRead("select count(id) as CountId from News where " + strsql);
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
        strSql.Append(" Id >0 ");
        if (classid > 0)
            strSql.Append(" and ClassId=" + classid);
        return strSql.ToString();
    }
    #endregion

    public string CheckUrl(string url, string id)
    {
        if (!string.IsNullOrEmpty(url) && url.Contains("http"))
        {
            return url + "\" target=\"_blank";
        }
        return "NewsDetail.aspx?ID=" + id;
    }
    public string strhtml = "";
    public void GetMobanhtml() {
        
        if (yangban == "1")
        {
            strhtml += "<div class=\"update_news1\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><strong><a href=\"" + CheckUrl(dsNews.Tables[0].Rows[i]["Url"].ToString(), dsNews.Tables[0].Rows[i]["Id"].ToString()) + "\">" + dsNews.Tables[0].Rows[i]["title"].ToString() + "</a><em>" + Convert.ToDateTime(dsNews.Tables[0].Rows[i]["putdate"]).ToString("yyyy-MM-dd") + "</em></strong><span>" + dsNews.Tables[0].Rows[i]["keycontent"].ToString() + "</span></li>";
            }
            strhtml += "</ul>";
            strhtml += "</div>";
        }
        else if (yangban == "2")
        {
            strhtml += "<div class=\"update_news2\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><div class=\"date\"><strong>" + Convert.ToDateTime(dsNews.Tables[0].Rows[i]["putdate"]).ToString("dd") + "</strong><span>" + Convert.ToDateTime(dsNews.Tables[0].Rows[i]["putdate"]).ToString("yyyy/MM") + "</span></div><div class=\"news_desc\"><a href=\"" + CheckUrl(dsNews.Tables[0].Rows[i]["Url"].ToString(), dsNews.Tables[0].Rows[i]["Id"].ToString()) + "\">" + dsNews.Tables[0].Rows[i]["title"].ToString() + "</a><span>" + dsNews.Tables[0].Rows[i]["keycontent"].ToString() + "</span></div></li>";
            }
            strhtml += "</ul>";
            strhtml += "</div>";
        }
        else if (yangban == "3")
        {
            strhtml += "<div class=\"update_news3\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><div class=\"news_con\"><div class=\"news_pic\"><img src=\"" + dsNews.Tables[0].Rows[i]["Path"].ToString() + "\"></div><div class=\"news_desc\"><strong><a href=\"" + CheckUrl(dsNews.Tables[0].Rows[i]["Url"].ToString(), dsNews.Tables[0].Rows[i]["Id"].ToString()) + "\">" + dsNews.Tables[0].Rows[i]["title"].ToString() + "</a><em>" + Convert.ToDateTime(dsNews.Tables[0].Rows[i]["putdate"]).ToString("yyyy-MM-dd") + "</em></strong><span>" + dsNews.Tables[0].Rows[i]["keycontent"].ToString() + "</span></div></div></li>";
            }
            strhtml += "</ul>";
            strhtml += "</div>";
        }
        else if (yangban == "4")
        {
            strhtml += "<div class=\"update_news4bg\">";
            strhtml += "<div class=\"update_news4\">";
            strhtml += "<ul>";
            for (int i = 0; i < intNews; i++)
            {
                strhtml += "<li><a href=\"" + CheckUrl(dsNews.Tables[0].Rows[i]["Url"].ToString(), dsNews.Tables[0].Rows[i]["Id"].ToString()) + "\"><div class=\"news_pic\"><img src=\"" + dsNews.Tables[0].Rows[i]["Path"].ToString() + "\"></div><div class=\"news_desc\"><strong>" + dsNews.Tables[0].Rows[i]["title"].ToString() + "</strong><em>" + Convert.ToDateTime(dsNews.Tables[0].Rows[i]["putdate"]).ToString("yyyy-MM-dd") + "</em><span>" + dsNews.Tables[0].Rows[i]["keycontent"].ToString() + "</span></div></a></li>";
            }
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
            strhtml += "</div>";
        }
        else if (yangban == "5")
        {
            strhtml += "<div class=\"update_news5\">";
            for (int i = 0; i < intNews; i++)
            {
                if (i < 2)
                {
                    if (i == 0)
                    {
                        strhtml += "<dl>";
                    }
                    strhtml += "<dd><a href=\"" + CheckUrl(dsNews.Tables[0].Rows[i]["Url"].ToString(), dsNews.Tables[0].Rows[i]["Id"].ToString()) + "\"><div class=\"news_pic\"><img src=\""+ dsNews.Tables[0].Rows[i]["Path"].ToString() + "\"></div><div class=\"news_desc\"><strong>" + dsNews.Tables[0].Rows[i]["title"].ToString() + "</strong><span>" + dsNews.Tables[0].Rows[i]["keycontent"].ToString() + "</span></div></a></dd>";
                    if (i == 1 || i == intNews-1)
                    {
                        strhtml += "<div class=\"clear\"></div></dl>";
                    }
                }
                else
                {
                    if (i == 2)
                    {
                        strhtml += "<ul>";
                    }
                    strhtml += "<li><div class=\"date\"><strong>" + Convert.ToDateTime(dsNews.Tables[0].Rows[i]["putdate"]).ToString("MM/dd") + "</strong><span>" + Convert.ToDateTime(dsNews.Tables[0].Rows[i]["putdate"]).ToString("yyyy") + "</span></div><div class=\"news_line\"></div><div class=\"news_desc\"><a href = \"" + CheckUrl(dsNews.Tables[0].Rows[i]["Url"].ToString(), dsNews.Tables[0].Rows[i]["Id"].ToString()) + "\">" + dsNews.Tables[0].Rows[i]["title"].ToString() + "</a><span>" + dsNews.Tables[0].Rows[i]["keycontent"].ToString() + "</span></div></li>";
                    if (i == intNews-1)
                    {
                        strhtml += "</ul>";
                    }
                }
            }
            strhtml += "</div>";
        }
    }
}


