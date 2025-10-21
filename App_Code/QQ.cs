using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 客服系统
    /// </summary>
    public class QQ
    {
        /// <summary>
        /// 获取所有QQ
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetQQ()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetQQ", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取开启的QQ
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetQQState()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetQQState", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单个QQ
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleQQ(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleQQ", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单个QQ
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleQQ(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleQQ", param));
        }
        /// <summary>
        /// 修改单个QQ
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strQQ"></param>
        /// <param name="strName"></param>
        public int UpdateSingleQQ(int intID, string strQQ, string strName)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@qq", SqlDbType.NVarChar, 25, strQQ),
                db.CreateInParam("@name", SqlDbType.NVarChar, 25, strName)
            };
            return (db.RunProc("Pr_UpdateSingleQQ", param));
        }
        /// <summary>
        /// 添加新的QQ
        /// </summary>
        /// <param name="strQQ"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public int AddSingleQQ(string strQQ, string strName)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@qq", SqlDbType.NVarChar, 25, strQQ), db.CreateInParam("@name", SqlDbType.NVarChar, 25, strName) };

            ///返回添加新QQ的ID
            return (db.RunProc("Pr_AddSingleQQ", param));
        }
        /// <summary>
        /// 设置QQ
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public int SetQQ(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID)
            };

            ///返回受影响的行数
            return (db.RunProc("Pr_SetQQ", param));
        }
    }
}

