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

public partial class Head : System.Web.UI.UserControl
{

    public BasicPage bp = new BasicPage();
    public MyClass mc = new MyClass();
    public int intClassID;
    public string strParentId;

    public DataSet dstMenu = new DataSet();
    public DataSet dstMenuSub = new DataSet();
    public int intMenu;
    public int intMenuSub;

    public string strLogo;
    public string strPhone;
    public string strEmail;
    public string strWebUrl = "http://" + HttpContext.Current.Request.Url.Host;
    public string strCompanyName;
    public string strNameState;

    public string str_Bg = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        Common common = new Common();
        Contact contact = new Contact();
        contact = common.showContact();
        strPhone = contact.Phone;
        strEmail = contact.Email;
        strCompanyName = contact.CompanyName;
        strNameState = contact.NameState;
        intClassID = basic.Tools.RequestClass.GetQueryInt("ClassID", 0);
        if (intClassID > 0)
        {
            SqlDataReader myread = bp.getRead("select ParentId from ColumnList where ID=" + intClassID);
            if (myread.Read())
            {
                strParentId = myread["ParentId"].ToString();
            }
            myread.Close();
        }

        showMenu();
        showLogo();
        showBg();
        showContent();
    }
    protected void showMenu()
    {
        dstMenu = bp.SelectDataBase("News", "select Id,ParentId,ColumnType,ColumnName,ColumnNo,ColumnUrlClient,ColumnStaticPage,StaticPage from ColumnList where ParentId=0 and IndexStatus=0 order by ColumnNo desc,Id asc");
        intMenu = dstMenu.Tables[0].Rows.Count;
    }
    protected void showMenuSub(int ID)
    {
        dstMenuSub = bp.SelectDataBase("News", "select Id,ParentId,ColumnType,ColumnName,ColumnNo,ColumnUrlClient,ColumnStaticPage,StaticPage from ColumnList where ParentId=" + ID + " and IndexStatus=0 order by ColumnNo desc,Id asc");
        intMenuSub = dstMenuSub.Tables[0].Rows.Count;
    }
    protected void showLogo()
    {
        SqlDataReader reader = bp.getRead("select * from TbPic where ClassID=1");
        if (reader.Read())
        {
            strLogo = reader["Path"].ToString();
        }
        reader.Close();
        if (strNameState == "1")
        {
            strLogo = "<a href='" + strWebUrl + "' title='" + strCompanyName + "'>" + strCompanyName + "</a>";
        }
        else
        {
            strLogo = "<a href='" + strWebUrl + "' title='" + strCompanyName + "'><img src='/" + strLogo + "' alt='" + strCompanyName + "' /></a>";
        }
    }
    protected void showBg()
    {
        SqlDataReader reader = bp.getRead("select * from TbWebSiteBg where ID=1");
        if (reader.Read())
        {
            if (reader["bgState"].ToString() == "1")
            {
                if (reader["bgPath"].ToString() != "")
                {
                    if (reader["bgDisplayMode"].ToString() == "0")
                    {
                        str_Bg = "<style type='text/css'>body{ background:url(/" + reader["bgPath"].ToString() + ");}</style>";
                    }
                    else if (reader["bgDisplayMode"].ToString() == "1")
                    {
                        str_Bg = "<style type='text/css'>body{ background:url(/" + reader["bgPath"].ToString() + ") center top no-repeat;}</style>";
                    }
                    else if (reader["bgDisplayMode"].ToString() == "2")
                    {
                        str_Bg = "<style type='text/css'>body{ background:url(/" + reader["bgPath"].ToString() + ")  repeat-x;}</style>";
                    }
                }
            }
            else
            {
                if (reader["path"].ToString() != "")
                {
                    str_Bg = "<style type='text/css'>body{ background:url(/" + reader["path"].ToString() + ");}</style>";
                }
            }
        }
        reader.Close();
    }
    protected string returnUrl(string strDynamicUrl, string strStaticUrl, string strStaticPage)
    {
        string strUrl = null;
        if (strStaticPage == "1")
        {
            strUrl = strStaticUrl;
        }
        else
        {
            strUrl = strDynamicUrl;
        }
        return strUrl;
    }

    //产品分类
    public DataSet dst = new DataSet();
    public int intCount = 0;
    protected void showContent()
    {
        dst = bp.SelectDataBase("ProClass", "select * from ProClass where ParentId=0 and State=0 order by Paixu desc,Id asc");
        intCount = dst.Tables[0].Rows.Count;
    }
    public DataSet dstSub = new DataSet();
    public int intCountSub = 0;
    protected void showContentSub(int Id)
    {
        dstSub = bp.SelectDataBase("ProClass", "select * from ProClass where ParentId=" + Id + " and State=0 order by Paixu desc,Id asc");
        intCountSub = dstSub.Tables[0].Rows.Count;
    }
}

