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

public partial class Tishi : System.Web.UI.Page
{
    public string strMessage = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        strMessage = Request["Message"];
    }
}

