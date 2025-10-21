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

public partial class CheckSubmit : System.Web.UI.Page
{
    BasicPage bp = new BasicPage();
    protected void Page_Load(object sender, EventArgs e)
    {

        string All = basic.Tools.RequestClass.GetQueryString("All");
        if (bp.doExecute("insert into TbFormContent values('" + All + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')"))
        {
            Response.Write("success");
        }

    }
}
