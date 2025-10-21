using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 会员系统
    /// </summary>
    public class User
    {
        /// <summary>
        /// 获取所有会员列表
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetUser()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetUser", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单个会员信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleUser(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@UserID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleUser", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单个会员信息
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleUser(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@UserID", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleUser", param));
        }
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="dblUserAccount"></param>
        /// <param name="strUserName"></param>
        /// <param name="strUserPassword"></param>
        /// <param name="strUserEmail"></param>
        /// <param name="strUserQQ"></param>
        /// <param name="strUserPhone"></param>
        /// <param name="strUserState"></param>
        /// <returns></returns>
        public int UpdateSingleUser(int intID, double dblUserAccount, string strUserName, string strUserPassword, string strUserEmail, string strUserQQ, string strUserPhone, string strUserState, string strUserRealName, string strUserAddress, string strUserCompany)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@UserID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@UserAccount", SqlDbType.Float, 8, dblUserAccount),
                db.CreateInParam("@UserName", SqlDbType.NVarChar, 16, strUserName),
                db.CreateInParam("@UserPassword", SqlDbType.NVarChar, 16, strUserPassword),
                db.CreateInParam("@UserEmail", SqlDbType.NVarChar, 32, strUserEmail),
                db.CreateInParam("@UserQQ", SqlDbType.NVarChar, 18, strUserQQ),
                db.CreateInParam("@UserPhone", SqlDbType.NVarChar, 13, strUserPhone),
                db.CreateInParam("@UserState", SqlDbType.NChar, 1, strUserState),
                db.CreateInParam("@UserRealName", SqlDbType.NVarChar, 8, strUserRealName),
                db.CreateInParam("@UserAddress", SqlDbType.NVarChar, 255, strUserAddress),
                db.CreateInParam("@UserCompany", SqlDbType.NVarChar, 50, strUserCompany)
            };
            return (db.RunProc("Pr_UpdateSingleUser", param));
        }
        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="dblUserAccount"></param>
        /// <param name="strUserName"></param>
        /// <param name="strUserPassword"></param>
        /// <param name="strUserEmail"></param>
        /// <param name="strUserQQ"></param>
        /// <param name="strUserPhone"></param>
        /// <param name="strUserState"></param>
        /// <param name="strPutdate"></param>
        /// <returns></returns>
        public int AddSingleUser(double dblUserAccount, string strUserName, string strUserPassword, string strUserEmail, string strUserQQ, string strUserPhone, string strUserState, string strUserRealName, string strUserAddress, string strUserCompany, string strPutdate)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@UserAccount", SqlDbType.Float, 8, dblUserAccount),
                db.CreateInParam("@UserName", SqlDbType.NVarChar, 16, strUserName),
                db.CreateInParam("@UserPassword", SqlDbType.NVarChar, 16, strUserPassword),
                db.CreateInParam("@UserEmail", SqlDbType.NVarChar, 32, strUserEmail),
                db.CreateInParam("@UserQQ", SqlDbType.NVarChar, 18, strUserQQ),
                db.CreateInParam("@UserPhone", SqlDbType.NVarChar, 13, strUserPhone),
                db.CreateInParam("@UserState", SqlDbType.NChar, 1, strUserState),
                db.CreateInParam("@UserRealName", SqlDbType.NVarChar, 8, strUserRealName),
                db.CreateInParam("@UserAddress", SqlDbType.NVarChar, 255, strUserAddress),
                db.CreateInParam("@UserCompany", SqlDbType.NVarChar, 50, strUserCompany),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate)
            };

            ///返回注册ID
            return (db.RunProc("Pr_AddSingleUser", param));
        }

    }
}

