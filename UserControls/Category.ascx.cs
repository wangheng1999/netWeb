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

public partial class Category : System.Web.UI.UserControl
{
    public BasicPage bp = new BasicPage();
    public DataSet dst = new DataSet();
    public int intCount = 0;
    public DataSet dstSub = new DataSet();
    public int intCountSub = 0;
    public DataSet dstSub2 = new DataSet();
    public int intCountSub2 = 0;
    public int intTypeID;
    public string strParentId;
    protected void Page_Load(object sender, EventArgs e)
    {
        intTypeID = basic.Tools.RequestClass.GetQueryInt("TypeID", 0);
        if (intTypeID > 0)
        {
            SqlDataReader myread = bp.getRead("select ParentId from ProClass where ID=" + intTypeID);
            if (myread.Read())
            {
                strParentId = myread["ParentId"].ToString();
            }
            myread.Close();
        }
        showContent();
    }
    protected void showContent()
    {
        dst = bp.SelectDataBase("ProClass", "select * from ProClass where ParentId=0 and State=0 order by Paixu desc,Id asc");
        intCount = dst.Tables[0].Rows.Count;
    }
    protected void showContentSub(int Id)
    {
        dstSub = bp.SelectDataBase("ProClass", "select * from ProClass where ParentId=" + Id + " and State=0 order by Paixu desc,Id asc");
        intCountSub = dstSub.Tables[0].Rows.Count;
    }
    protected void showContentSub2(int Id)
    {
        dstSub2 = bp.SelectDataBase("ProClass", "select * from ProClass where ParentId=" + Id + " and State=0 order by Paixu desc,Id asc");
        intCountSub2 = dstSub2.Tables[0].Rows.Count;
    }
}

