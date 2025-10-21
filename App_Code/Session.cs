using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace WebApp.Components
{
    /// <summary>
    /// 判断管理员是否登录
    /// </summary>
    public class Session
    {
        /// <summary>
        /// 判断是否登录
        /// </summary>
        /// <param name="objUserName"></param>
        /// <returns></returns>
        public bool AdminSession(object objUserName)
        {
            bool bolSign = false;
            if (objUserName == null)
            {
                 System.Web.HttpContext.Current.Response.Write("<script>");
                System.Web.HttpContext.Current.Response.Write("parent.location.href='login.aspx'");
                System.Web.HttpContext.Current.Response.Write("</script>");
            }
            else
            {
                bolSign = true;
            }
            return bolSign;
        }
    }
}

