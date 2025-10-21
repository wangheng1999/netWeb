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
using WebApp.Components;
using basic;

public partial class Left : System.Web.UI.UserControl
{
    public BasicPage bp = new BasicPage();
    public MyClass mc = new MyClass();
    public int intClassID;
    public int intID;
    public int intTypeID;
    public int intProId;
    protected void Page_Load(object sender, EventArgs e)
    {
        intClassID = basic.Tools.RequestClass.GetQueryInt("ClassID", 0);
        intID = basic.Tools.RequestClass.GetQueryInt("ID", 0);
        intTypeID = basic.Tools.RequestClass.GetQueryInt("TypeID", 0);
        intProId = basic.Tools.RequestClass.GetQueryInt("ProId", 0);

        if (intTypeID > 0 || intProId > 0)
        {
            //显示产品分类
            showContent();
        }
        else
        {
            if (intID > 0)//新闻id
            {
                intClassID = int.Parse(mc.ShowNewsKeyById(intID, "ClassId"));
            }
            ShowSubmenu(intClassID);
            //没有二级分类的时候
            if (intColumnList == 0)
            {
                //显示产品分类
                showContent();
            }
        }
    }
    //子栏目
    public int intColumnList;
    public DataSet dsSubmenu = new DataSet();
    public string strColumnName;
    public string strColumnSubName;
    protected void ShowSubmenu(int CLASSID)
    {
        dsSubmenu = mc.SelectAllSubMenu(CLASSID);
        intColumnList = dsSubmenu.Tables[0].Rows.Count;

        if (intColumnList > 0)
        {
            //父级栏目名称
            SqlDataReader myreader = bp.getRead("select ColumnName,ColumnSubName from ColumnList where ID = (select ParentId from ColumnList where ID=" + CLASSID + ")");
            if (myreader.Read())
            {
                strColumnName = myreader["ColumnName"].ToString();
                strColumnSubName = myreader["ColumnSubName"].ToString();
            }
            myreader.Close();
        }
        else
        {
            //父级栏目名称
            SqlDataReader myreader = bp.getRead("select ColumnName,ColumnSubName from ColumnList where ID = " + CLASSID);
            if (myreader.Read())
            {
                strColumnName = myreader["ColumnName"].ToString();
                strColumnSubName = myreader["ColumnSubName"].ToString();
            }
            myreader.Close();
        }

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

