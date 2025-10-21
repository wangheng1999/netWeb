using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 最终页面通用类
    /// </summary>
    public class About
    {
        /// <summary>
        /// 获取最终页面内容
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetAbout(int intClassID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ClassId", SqlDbType.Int, 4, intClassID) };
            db.RunProc("Pr_GetAbout", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="intClassID"></param>
        /// <param name="strContent"></param>
        /// <param name="strPutdate"></param>
        public int UpdateAbout(int intClassID, string strContent, string strPutdate)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ClassId", SqlDbType.Int, 4, intClassID),
                db.CreateInParam("@Content", SqlDbType.NText, 1073741823, strContent),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate)
            };
            return (db.RunProc("Pr_UpdateAbout", param));
        }
    }
}

