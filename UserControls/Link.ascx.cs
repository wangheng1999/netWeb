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
using WebApp.Components;
using System.Data.SqlClient;
using basic;

public partial class Link : System.Web.UI.UserControl
{
    public int intClassID;
    public int intID;
    public string Path;
    public MyClass mc = new MyClass();
    BasicPage bp = new BasicPage();
    protected void Page_Load(object sender, EventArgs e)
    {
        string strWebUrl = HttpContext.Current.Request.Url.AbsolutePath;
        intClassID = basic.Tools.RequestClass.GetQueryInt("ClassID", 0);
        intID = basic.Tools.RequestClass.GetQueryInt("ID", 0);
        if (intID > 0)
        {
            if (!string.IsNullOrEmpty(mc.ShowNewsKeyById(intID, "ClassID")))
            {
                intClassID = int.Parse(mc.ShowNewsKeyById(intID, "ClassID"));
            }
        }
        Path = mc.ShowColumnKeyById(intClassID, "path");
        if (strWebUrl.ToLower().Contains("product.aspx") || strWebUrl.ToLower().Contains("prodetail.aspx"))
        {
            SqlDataReader myread = bp.getRead("select top 1 Path from ColumnList where ColumnType='产品列表' order by ColumnNo desc,id asc");
            if (myread.Read())
            {
                Path = myread[0].ToString();
            }
            myread.Close();
        }
    }
}

