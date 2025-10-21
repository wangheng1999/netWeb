using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 网站基本信息设置
    /// </summary>
    public class Time
    {
        /// <summary>
        /// 读取信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetTimeLimit(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetTimeLimit", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 网站配置信息
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strBeginTime"></param>
        /// <param name="strNumber"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strEmail"></param>
        /// <param name="strType"></param>
        /// <param name="strMobile"></param>
        /// <param name="strQQ"></param>
        /// <param name="strSMSToMobile"></param>
        /// <param name="strSMSState"></param>
        /// <param name="dblPrice"></param>
        /// <param name="strPhone"></param>
        /// <returns></returns>
        public int UpdateTimeLimit(int intID, string strBeginTime, string strNumber, string strEndTime, string strEmail, string strType, string strMobile, string strQQ, string strSMSToMobile, string strSMSState, double dblPrice, string strPhone, string strBeizhu)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@Number", SqlDbType.NVarChar, 255, strNumber),
                db.CreateInParam("@BeginTime", SqlDbType.NVarChar, 19, strBeginTime),
                db.CreateInParam("@EndTime", SqlDbType.NVarChar, 19, strEndTime),
                db.CreateInParam("@Email", SqlDbType.NVarChar, 32, strEmail),
                db.CreateInParam("@Type", SqlDbType.NVarChar, 32, strType),
                db.CreateInParam("@Mobile", SqlDbType.NVarChar, 11, strMobile),
                db.CreateInParam("@QQ", SqlDbType.NVarChar, 12, strQQ),
                db.CreateInParam("@SMSToMobile", SqlDbType.NVarChar, 11, strSMSToMobile),
                db.CreateInParam("@SMSState", SqlDbType.NChar, 1, strSMSState),
                db.CreateInParam("@Price", SqlDbType.Float, 8, dblPrice),
                db.CreateInParam("@Phone", SqlDbType.NVarChar, 13, strPhone),
                db.CreateInParam("@Beizhu", SqlDbType.NVarChar, 500, strBeizhu)

            };
            return (db.RunProc("Pr_UpdateTimeLimit", param));
        }
    }
}

