using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using basic;
using System.Xml;
using System.Web;

namespace space
{
    public class spacename : System.Web.UI.Page
    {
        public BasicPage bp = new BasicPage();
        public static string strconfig = HttpRuntime.AppDomainAppPath.ToString() + "/upload/config/space.config";
        /// <summary>
        /// 限制域名访问
        /// </summary>
        public void restrict()
        {
            string url = System.Web.HttpContext.Current.Request.Url.Host;
            string content = GetIndexConfigValue("domainn");
            string[] yuming = { "" };
            bool bsign = false;
            if (content != "" && content != null)
            {
                if (content.IndexOf(",") != (-1))
                {
                    yuming = content.Split(',');
                }
                else
                {
                    yuming[0] = content;
                }
            }
            else
            {
                bsign = true;
            }
            for (int i = 0; i < yuming.Length; i++)
            {
                if (url == yuming[i])
                {
                    bsign = true;
                }
            }
            if (!bsign)
            {
                System.Web.HttpContext.Current.Response.Redirect("/Tishi.aspx?Message=<li><b>域名权限不足，请联系服务商<%2fb><%2fli>", false);
            }

        }


        /// <summary>
        /// 判断会员功能权限
        /// </summary>
        public void GetVipControl()
        {
            restrict();
            string VipControl = GetIndexConfigValue("VIPControl");
            if(VipControl!="1")
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('您的权限不足，无法打开该功能页面。请联系管理员！');window.location.href='/home'</script>");
            }
        }

        /// <summary>
        /// xml节点值获取
        /// </summary>
        /// <param name="key">节点名称</param>
        /// <returns></returns>
        /// <param name="key">节点名称</param>
        /// <returns>节点名称的值</returns>
        public static string GetIndexConfigValue(string key)
        {
            string flag = "";
            string indexConfigPath = strconfig;
            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = indexConfigPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            flag = config.AppSettings.Settings[key].Value;

            return flag;
        }


        /// <summary>
        /// 设置自定义 appsetting 节点值
        /// </summary>
        /// <param name="key">节点名称</param>
        /// <param name="value">需要修改的值</param>
        /// <returns>true：修改成功 false：修改失败</returns>
        public static bool SetIndexConfigValue(string key, string value)
        {
            string indexConfigPath = strconfig;

            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = indexConfigPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save();
            return true;
        }



        /// <summary>
        /// 给xlm指定的节点添加节点和值
        /// </summary>
        /// <param name="key">添加的key值</param>
        /// <param name="value">添加的value值</param>
        public static void AddIndexConfigValue(string key, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strconfig); //加载xml文件
            XmlNode rootXml = xmlDoc.SelectSingleNode("configuration"); //查询XML文件的根节点("siteMapPath")
            XmlNodeList xnl = rootXml.SelectNodes("appSettings"); //获取所有节点为"siteMapNode"的节点
            foreach (XmlNode xnItem in xnl)
            {
                XmlElement xe = (XmlElement)xnItem; //将子节点类型转换为XmlElement类型
                XmlElement newXE = xmlDoc.CreateElement("add");
                newXE.SetAttribute("key", key);
                newXE.SetAttribute(@"value", value);
                xnItem.AppendChild(newXE);
            }
            xmlDoc.Save(strconfig);
        }


        /// <summary>
        /// 按xml路径删除指定节点
        /// </summary>
        /// <param name="key">要删除的节点key值</param>
        /// <returns>0：删除失败，1:删除成功，-1：配置文件异常，-2系统异常，</returns>
        public static string DeleteIndexConfigValue(string key)
        {
            string flag = "0";
            string indexConfigPath = strconfig;
            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = indexConfigPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            try
            {
                config.AppSettings.Settings.Remove(key);
                config.Save(ConfigurationSaveMode.Modified);
                flag = "1";
            }
            catch (Exception)
            {
                flag = "-2";//系统异常
            }
            return flag;
        }
    }
}


