<%@ WebHandler Language="C#" Class="Submit" %>

using System;
using System.Web;

public class Submit : IHttpHandler
{
    WebApp.Components.Submit submit = new WebApp.Components.Submit();
    WebApp.Components.SystemTools systemtools = new WebApp.Components.SystemTools();
    public void ProcessRequest(HttpContext context)
    {
        string strResult = null;
        string strInfo = null;
        if (context.Request["info"] != null)
        {
            strInfo = context.Request["info"].ToString();
            bool pro = systemtools.ProcessSqlStr(strInfo);
            if (pro == true)
            {
                string IP = context.Request.UserHostAddress;

                int m = submit.InsertSubmitform(strInfo + "_IP:" + IP, DateTime.Now.ToString());
                if (m > 0)
                {
                    strResult = "success";
                }
            }
            else
            {
                strResult = "failure";
            }
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write(strResult);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
