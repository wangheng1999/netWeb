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

public partial class CheckMessage : System.Web.UI.Page
{
    Feedback feedback = new Feedback();
    SystemTools systemtools = new SystemTools();
    Time time = new Time();
    protected void Page_Load(object sender, EventArgs e)
    {
        string strVNum = Session["serverCode"].ToString();
        Session.Remove("VNum");
        ViewState["VNum"] = strVNum;
        string strResult = null;
        if (Request["Code"] == ViewState["VNum"].ToString())
        {
            string strTitle = null;
            string strRealname = null;
            string strPhone = null;
            string strEmail = null;
            string strContent = null;

            bool returnValue = false;
            returnValue = systemtools.StartProcessRequest();
            if (returnValue == true)
            {
                strTitle = Request["Title"];
                strRealname = Request["Realname"];
                strPhone = Request["Phone"];
                strEmail = Request["Email"];
                strContent = Request["Content"];

                if (feedback.AddSingleMessage(strTitle, strRealname, strPhone, strEmail, strContent, DateTime.Now.ToString()) > 0)
                {
                    strResult = "success";
                }
                else
                {
                    strResult = "failure";
                }
            }
            else
            {
                strResult = "error";
            }
        }
        else
        {
            strResult = "false";
        }
        Response.Write(strResult);
        Response.End();
    }
}

