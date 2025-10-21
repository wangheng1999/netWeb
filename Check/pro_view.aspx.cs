using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebApp.Components;
using basic;

public partial class Check_pro_view : System.Web.UI.Page
{
    public int intID = 0;
    public string Hits = "1";
    protected void Page_Load(object sender, EventArgs e)
    {
        BasicPage bp = new BasicPage();
        intID = basic.Tools.RequestClass.GetQueryInt("ProId", 0);
        bp.doExecute("update Product set Hits=Hits+1 where ProId=" + intID);
        SqlDataReader myread = bp.getRead("select Hits from Product where ProId=" + intID);
        if (myread.Read())
        {
            Hits = myread[0].ToString();
        }
        myread.Close();
        Response.Write("document.write(" + Hits + ")");
    }
}
