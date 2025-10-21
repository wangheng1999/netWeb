using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 网站基本信息设置
    /// </summary>
    public class BackGround
    {
        /// <summary>
        /// 读取信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetBackGround(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetBackGround", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 设置网站背景图片
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strPath"></param>
        /// <param name="strState"></param>
        /// <param name="strbgState"></param>
        /// <param name="strbgPath"></param>
        /// <param name="bgDisplayMode"></param>
        /// <returns></returns>
        public int UpdateBackGround(int intID, string strPath, string strState, string strbgState, string strbgPath, string bgDisplayMode)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPath),
                db.CreateInParam("@State", SqlDbType.NChar, 1, strState),
                db.CreateInParam("@bgState", SqlDbType.NChar, 1, strbgState),
                db.CreateInParam("@bgPath", SqlDbType.NVarChar, 255, strbgPath),
                db.CreateInParam("@bgDisplayMode", SqlDbType.NChar, 1, bgDisplayMode)
            };
            return (db.RunProc("Pr_UpdateBackGround", param));
        }
        /// <summary>
        /// 删除网站背景
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteBackGround(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteBackGround", param));
        }
    }
}

