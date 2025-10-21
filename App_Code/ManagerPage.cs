using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Basic
{
    public class ManagerPage : System.Web.UI.Page
    {
        public ManagerPage()
        {
            this.Load += new EventHandler(HuiyuanPage_Load);
        }

        private void HuiyuanPage_Load(object sender, EventArgs e)
        {
            //判断管理员是否登录
            if (!IsUserLogin())
            {
                System.Web.HttpContext.Current.Response.Write("<script>parent.location.href='login.aspx'</script>");
                Response.End();
            }
        }

        /// <summary>
        /// 判断会员是否登录
        /// </summary>
        public bool IsUserLogin()
        {
            bool bolSign = false;
            if (Session[Basic.Keys.SessonAdminModel] != null)
            {
                bolSign = true;
            }
            else
            {
                string objUserName = Basic.Engine.CookieDo.GetCookie("UserID", "KEY");
                string objRole = Basic.Engine.CookieDo.GetCookie("Role", "KEY");
                string objPassword = Basic.Engine.CookieDo.GetCookie("Password", "KEY");
                if (!string.IsNullOrEmpty(objUserName) && !string.IsNullOrEmpty(objRole) && !string.IsNullOrEmpty(objPassword))
                {
                    objPassword = Basic.Tools.DESEncrypt.Decrypt(objPassword);

                    if (objRole == "1" && objPassword == Basic.Keys.LoginPassword)
                    {
                        Basic.Model.ManagerInfo model = new Basic.Model.ManagerInfo();
                        model.UserID = "管理员";
                        model.Password = Basic.Tools.DESEncrypt.Encrypt(Basic.Keys.LoginPassword);
                        model.Role = "1";
                        Session[Basic.Keys.SessonAdminModel] = model;

                        bolSign = true;
                    }
                    else
                    {
                        WebApp.Components.Admin admin = new WebApp.Components.Admin();
                        SqlDataReader reader = admin.GetAdminLogin(objUserName, objPassword);
                        if (reader.Read())
                        {
                            Basic.Model.ManagerInfo model = new Basic.Model.ManagerInfo();
                            model.UserID = objUserName;
                            model.Password = Basic.Tools.DESEncrypt.Encrypt(objPassword);
                            model.Role = "1";
                            Session[Basic.Keys.SessonAdminModel] = model;
                            bolSign = true;
                        }
                        reader.Close();
                    }
                }

            }
            return bolSign;
        }


        /// <summary>
        /// 取得管理员信息
        /// </summary>
        public Model.ManagerInfo GetAdminInfo()
        {
            if (IsUserLogin())
            {
                Model.ManagerInfo model = Session[Keys.SessonAdminModel] as Model.ManagerInfo;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }
    }
}