using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 所有信息
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetLog()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetLog", out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单个数据
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleLog(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleLog", param));
        }
        /// <summary>
        /// 添加新的数据
        /// </summary>
        /// <param name="strIP"></param>
        /// <param name="strUserName"></param>
        /// <param name="strResult"></param>
        /// <returns></returns>
        public int AddSingleLog(string strTimes,string strIP, string strUserName, string strResult)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Times", SqlDbType.NVarChar, 19, strTimes),
                db.CreateInParam("@IP", SqlDbType.NVarChar, 15, strIP),
                db.CreateInParam("@UserName", SqlDbType.NVarChar, 50, strUserName),
                db.CreateInParam("@Result", SqlDbType.NVarChar, 255, strResult)
            };

            ///返回添加新QQ的ID
            return (db.RunProc("Pr_AddSingleLog", param));
        }
    }
}

