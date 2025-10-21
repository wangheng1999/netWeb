using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 支付接口
    /// </summary>
    public class PayMentInterface
    {
        /// <summary>
        /// 获取接口信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetAliPay(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetAliPay", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 设置接口信息
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strPayState"></param>
        /// <param name="strPayName"></param>
        /// <param name="strPayDescription"></param>
        /// <param name="strPaySellerID"></param>
        /// <param name="strPayKeyID"></param>
        /// <param name="strPayPartnerID"></param>
        /// <param name="strPayType"></param>
        /// <returns></returns>
        public int UpdateAliPay(int intID, string strPayState, string strPayName, string strPayDescription, string strPaySellerID, string strPayKeyID, string strPayPartnerID, string strPayType)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@PayState", SqlDbType.NChar, 1, strPayState),
                db.CreateInParam("@PayName", SqlDbType.NVarChar, 16, strPayName),
                db.CreateInParam("@PayDescription", SqlDbType.NVarChar, 8000, strPayDescription),
                db.CreateInParam("@PaySellerID", SqlDbType.NVarChar, 32, strPaySellerID),
                db.CreateInParam("@PayKeyID", SqlDbType.NVarChar, 32, strPayKeyID),
                db.CreateInParam("@PayPartnerID", SqlDbType.NVarChar, 16, strPayPartnerID),
                db.CreateInParam("@PayType", SqlDbType.NVarChar, 12, strPayType)
            };
            return (db.RunProc("Pr_UpdateAliPay", param));
        }
    }
}


