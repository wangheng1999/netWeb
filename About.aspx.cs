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

public partial class Content : System.Web.UI.Page
{
    public BasicPage bp = new BasicPage();
    public MyClass mc = new MyClass();

    int intClassID;
    public string strParentColumnName = null;
    public string strParentColumnSubName = null;
    public string strColumnName = null;
    public string strColumnSubName = null;
    public string strPath = null;

    public string url2 = HttpContext.Current.Request.Url.AbsoluteUri;
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemTools systemtools = new SystemTools();
        if (systemtools.IsNumberic(Request["ClassID"]))
        {
            intClassID = Int32.Parse(Request["ClassID"]);
            //调用类
            Common common = new Common();

            showNews1();

            //根据ClassID显示内容
            showContent(intClassID);
            //显示栏目名称
            ClientColumnName clientcolumnname = new ClientColumnName();
            clientcolumnname = common.showColumnName(intClassID);
            strColumnName = clientcolumnname.ColumnName;
            strColumnSubName = clientcolumnname.ColumnSubName;
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
            //显示父级栏目名称
            ClientParentColumnName clientparentcolumnname = new ClientParentColumnName();
            clientparentcolumnname = common.showParentColumnName(intClassID);
            strParentColumnName = clientparentcolumnname.ParentColumnName;
            strParentColumnSubName = clientparentcolumnname.ParentColumnSubName;

            
            //读取整站SEO的设置信息
            ClientSEO clientseo = common.showSEO();
            this.Title = strColumnName + "-" + mc.ShowWebsiteKeyById(1, "CompanyName");
            description.Attributes["content"] = clientseo.WebDescription;
            keywords.Attributes["content"] = strColumnName + "," + mc.ShowWebsiteKeyById(1, "CompanyName");


            //读取某个栏目的SEO设置信息
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
        }

    }


    protected void showContent(int ClassID)
    {

        About about = new About();
        SqlDataReader reader = about.GetAbout(ClassID);
        if (reader.Read())
        {
            lContent.Text = reader["content"].ToString();
        }
        reader.Close();

    }



    //友情链接
    public DataTable dstNews1 = new DataTable();
    public int intNews1;
    private void showNews1()
    {
        dstNews1 = bp.SelectDataBase("Links", "select top 100 id,title,url from Links").Tables[0];
        intNews1 = dstNews1.Rows.Count;
    }
}

