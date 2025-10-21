using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// SEO
    /// </summary>
    public class SEO
    {
        /// <summary>
        /// 获取网站优化数据
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSEO(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSEO", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 修改网站优化数据
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strTitle"></param>
        /// <param name="strDescription"></param>
        /// <param name="strKeywords"></param>
        public int UpdateSEO(int intID, string strTitle, string strDescription, string strKeywords)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@webTitle", SqlDbType.NVarChar, 255, strTitle),
                db.CreateInParam("@webDescription", SqlDbType.NVarChar, 255, strDescription),
                db.CreateInParam("@webKeywords", SqlDbType.NVarChar, 255, strKeywords)
            };
            return (db.RunProc("Pr_UpdateSEO", param));
        }
    }
}


