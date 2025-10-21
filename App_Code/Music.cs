using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 网站基本信息设置
    /// </summary>
    public class Music
    {
        /// <summary>
        /// 读取信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetWebMusic(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetWebMusic", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strPath"></param>
        /// <param name="strState"></param>
        /// <returns></returns>
        public int UpdateWebMusic(int intID, string strPath, string strState)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPath),
                db.CreateInParam("@State", SqlDbType.NChar, 1, strState)
            };
            return (db.RunProc("Pr_UpdateWebMusic", param));
        }
    }
}


