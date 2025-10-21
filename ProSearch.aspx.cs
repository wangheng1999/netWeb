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

public partial class ProSearch : System.Web.UI.Page
{
    public MyClass mc = new MyClass();
    public BasicPage bp = new BasicPage();
    public int ClassID;
    public string strParentColumnName = null;
    public string strColumnName = "搜索结果";
    public string KeyName = "";
    public string strPath = null;
    public SystemTools systemtools = new SystemTools();

    public int intTypeID;

    protected void Page_Load(object sender, EventArgs e)
    {
        //调用类
        Common common = new Common();
        //读取整站SEO的设置信息
        ClientSEO clientseo = common.showSEO();
        this.Title = strColumnName +"-" + mc.ShowWebsiteKeyById(1, "CompanyName");
        description.Attributes["content"] = clientseo.WebDescription;
        keywords.Attributes["content"] = strColumnName + "," + mc.ShowWebsiteKeyById(1, "CompanyName");

    }
}

