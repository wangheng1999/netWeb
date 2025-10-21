using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebApp.Components;
using basic;

public partial class Check_news_view : System.Web.UI.Page
{
    public int intID = 0;
    public string Hits = "1";
    protected void Page_Load(object sender, EventArgs e)
    {
        BasicPage bp = new BasicPage();
        intID = basic.Tools.RequestClass.GetQueryInt("id", 0);
        bp.doExecute("update News set hits=hits+1 where id=" + intID);
        SqlDataReader myread = bp.getRead("select hits from News where id=" + intID);
        if (myread.Read())
        {
            Hits = myread[0].ToString();
        }
        myread.Close();
        Response.Write("document.write(" + Hits + ")");
    }
}
