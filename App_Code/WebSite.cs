using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 网站基本信息设置
    /// </summary>
    public class WebSite
    {
        /// <summary>
        /// 获取网站基本信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetWesSite(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetWesSite", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取网站开关信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetWebSiteControl(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetWebSiteControl", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取技术支持信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSupport(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSupport", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取代码信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSetupCode(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSetupCode", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 修改网站基本信息
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strICP"></param>
        /// <param name="strWebUrl"></param>
        /// <param name="strCompanyName"></param>
        /// <param name="strAddress"></param>
        /// <param name="strPhone"></param>
        /// <param name="strMobile"></param>
        /// <param name="strEmail"></param>
        /// <param name="strFax"></param>
        /// <param name="strContact"></param>
        public int UpdateWesSite(int intID, string strICP, string strWebUrl, string strCompanyName, string strNameState, string strAddress, string strPhone, string strMobile, string strEmail, string strFax, string strContact, string strQQ, string strMap, string strWeChat, string strZip)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@ICP", SqlDbType.NVarChar, 25, strICP),
                db.CreateInParam("@WebUrl", SqlDbType.NVarChar, 50, strWebUrl),
                db.CreateInParam("@CompanyName", SqlDbType.NVarChar, 255, strCompanyName),
                db.CreateInParam("@NameState", SqlDbType.NChar, 1, strNameState),
                db.CreateInParam("@Address", SqlDbType.NVarChar, 255, strAddress),
                db.CreateInParam("@Phone", SqlDbType.NVarChar, 50, strPhone),
                db.CreateInParam("@Mobile", SqlDbType.NVarChar, 50, strMobile),
                db.CreateInParam("@Email", SqlDbType.NVarChar, 50, strEmail),
                db.CreateInParam("@Fax", SqlDbType.NVarChar, 25, strFax),
                db.CreateInParam("@Contact", SqlDbType.NVarChar, 25, strContact),
                db.CreateInParam("@QQ", SqlDbType.NVarChar, 12, strQQ),
                db.CreateInParam("@Map", SqlDbType.NText, 800, strMap),
                db.CreateInParam("@WeChat", SqlDbType.NVarChar, 50, strWeChat),
                 db.CreateInParam("@Zip", SqlDbType.NVarChar, 50, strZip)

            };
            return (db.RunProc("Pr_UpdateWesSite", param));
        }
        /// <summary>
        /// 设置开关设置
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strState"></param>
        /// <param name="strTishi"></param>
        /// <returns></returns>
        public int UpdateWebSiteControl(int intID, string strState, string strTishi)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@State", SqlDbType.NChar,1,strState),
                db.CreateInParam("@Tishi", SqlDbType.NText,8000, strTishi)
            };
            return (db.RunProc("Pr_UpdateWebSiteControl", param));
        }
        /// <summary>
        /// 设置代码
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strState"></param>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public int UpdateSetupCode(int intID, string strState, string strContent)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@State", SqlDbType.NChar,1,strState),
                db.CreateInParam("@Content", SqlDbType.NText,8000, strContent)
            };
            return (db.RunProc("Pr_UpdateSetupCode", param));
        }
        /// <summary>
        /// 设置技术支持信息
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strState"></param>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public int UpdateSupport(int intID, string strSupportName, string strTitle, string strWebSite, string strState, string strStateManage, string strStateSitemap)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@SupportName", SqlDbType.NVarChar,100,strSupportName),
                db.CreateInParam("@Title", SqlDbType.NVarChar,100, strTitle),
                db.CreateInParam("@WebSite", SqlDbType.NVarChar,50, strWebSite),
                db.CreateInParam("@State", SqlDbType.NChar,1, strState),
                db.CreateInParam("@StateManage", SqlDbType.NChar,1, strStateManage),
                db.CreateInParam("@StateSitemap", SqlDbType.NChar,1, strStateSitemap)
            };
            return (db.RunProc("Pr_UpdateSupport", param));
        }
    }
}


