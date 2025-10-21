using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace Basic.Engine
{
    /// <summary>
    /// 检测登录状态
    /// </summary>
    public static class CheckLogin
    {
        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <param name="objUserName"></param>
        /// <returns></returns>
        public static bool UserSession(string objUserName)
        {
            bool bolSign = false;
            if (string.IsNullOrEmpty(objUserName))
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
