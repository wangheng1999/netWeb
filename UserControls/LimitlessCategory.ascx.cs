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

public partial class LimitlessCategory : System.Web.UI.UserControl
{
    public BasicPage bp = new BasicPage();
    public string strlist = null;
    public string strStaticPage = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        showLinks();
    }
    public DataTable dtLinks = new DataTable();
    public int intLinks;
    protected void showLinks()
    {
        dtLinks = bp.SelectDataBase("Links", "select * from Links order by id desc").Tables[0];
        intLinks = dtLinks.Rows.Count;
    }
}

