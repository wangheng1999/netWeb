using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 留言系统
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// 获取所有留言列表
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetMessage()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetMessage", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单条留言数据
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleMessage(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleMessage", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleMessage(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleMessage", param));
        }
        /// <summary>
        /// 回复留言
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="intStateShenhe"></param>
        /// <param name="intStateHuifu"></param>
        /// <param name="strReply"></param>
        public int UpdateSingleMessage(int intID, int intStateShenhe, int intStateHuifu, string strReply)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@StateShenhe", SqlDbType.Int, 4, intStateShenhe),
                db.CreateInParam("@StateHuifu", SqlDbType.Int, 4, intStateHuifu),
                db.CreateInParam("@Reply", SqlDbType.NVarChar, 255, strReply)
            };
            return (db.RunProc("Pr_UpdateSingleMessage", param));
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strRealname"></param>
        /// <param name="strPhone"></param>
        /// <param name="strEmail"></param>
        /// <param name="strContent"></param>
        /// <param name="strPutdate"></param>
        /// <returns></returns>
        public int AddSingleMessage(string strTitle, string strRealname, string strPhone, string strEmail, string strContent, string strPutdate)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Title", SqlDbType.NVarChar, 255, strTitle),
                db.CreateInParam("@Realname", SqlDbType.NVarChar, 25, strRealname),
                db.CreateInParam("@Phone", SqlDbType.NVarChar, 25, strPhone),
                db.CreateInParam("@Email", SqlDbType.NVarChar, 25, strEmail),
                db.CreateInParam("@Content", SqlDbType.NVarChar, 4000, strContent),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate)
            };

            ///返回新添加数据的ID
            return (db.RunProc("Pr_AddSingleMessage", param));
        }
    }
}

