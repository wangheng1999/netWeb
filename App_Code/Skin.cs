using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 网站风格设置
    /// </summary>
    public class Skin
    {
        /// <summary>
        /// 获取所有风格
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetSkin()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetSkin", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleSkin(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleSkin", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleSkin(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleSkin", param));
        }
        /// <summary>
        /// 更新单条数据
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strStyleName"></param>
        /// <param name="strStyleUrl"></param>
        /// <param name="intState"></param>
        /// <returns></returns>
        public int UpdateSingleSkin(int intID, string strStyleName, string strStyleUrl)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@StyleName", SqlDbType.NVarChar, 25, strStyleName),
                db.CreateInParam("@StyleUrl", SqlDbType.NVarChar, 255, strStyleUrl)
            };
            return (db.RunProc("Pr_UpdateSingleSkin", param));
        }
        /// <summary>
        /// 添加新数据
        /// </summary>
        /// <param name="strStyleName"></param>
        /// <param name="strStyleUrl"></param>
        /// <param name="intState"></param>
        /// <returns></returns>
        public int AddSingleSkin(string strStyleName, string strStyleUrl)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@StyleName", SqlDbType.NVarChar, 25, strStyleName),
                db.CreateInParam("@StyleUrl", SqlDbType.NVarChar, 255, strStyleUrl)
            };

            ///返回最新ID
            return (db.RunProc("Pr_AddSingleSkin", param));
        }
        /// <summary>
        /// 设置皮肤
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public int SetSkin(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID)
            };

            ///返回受影响的行数
            return (db.RunProc("Pr_SetSkin", param));
        }
        /// <summary>
        /// 获取设置的前台CSS样式
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetStateSkin()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetStateSkin", out dr);

            return (dr);
        }
    }
}


