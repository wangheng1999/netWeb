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

public partial class NewsClass : System.Web.UI.Page
{
    public MyClass mc = new MyClass();
    int intClassID;
    public string strParentColumnName = null;
    public string strParentColumnSubName = null;
    public string strColumnName = null;
    public string strColumnSubName = null;
    public string strPath = null;
    int intRowCount;//用来记录总记录数
    public BasicPage bp = new BasicPage();
    public SystemTools systemtools = new SystemTools();
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

        if (!Page.IsPostBack)
        {
            strsql = ComSQL(intClassID);
            orderby = "ColumnNo desc,id desc";
            RptBind(strsql, orderby);
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
        strSql1.Append("select top " + pageNum + " id,ColumnName,ColumnUrlClient from ColumnList ");
        strSql1.Append(" where ");
        strSql1.Append(_strWhere);
        strSql1.Append(" and Id not in ");
        strSql1.Append(" ( ");
        strSql1.Append(" select top " + Num + " id from ColumnList ");
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
        SqlDataReader myread = bp.getRead("select count(id) as CountId from ColumnList where " + strsql);
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
        strSql.Append(" IndexStatus =0 ");
        if (classid > 0)
            strSql.Append(" and ParentId=" + classid);
        return strSql.ToString();
    }
    #endregion


    protected string ChangeGif(string data)
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
}

