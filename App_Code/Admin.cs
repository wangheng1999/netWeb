using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// Admin 的摘要说明。
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// 获取所有管理员列表
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetAdmin()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetAdmin", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单个帐号
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleAdmin(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleAdmin", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单个帐号
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleAdmin(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleAdmin", param));
        }
        /// <summary>
        /// 修改单个帐号
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strAdminName"></param>
        /// <param name="strAdminPassword"></param>
        /// <returns></returns>
        public int UpdateSingleAdmin(int intID, string strAdminPassword)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@AdminPassword", SqlDbType.NVarChar, 50, strAdminPassword)
            };
            return (db.RunProc("Pr_UpdateSingleAdmin", param));
        }
        /// <summary>
        /// 添加新的非管理员角色帐号
        /// </summary>
        /// <param name="strQQ"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public int AddSingleAdmin(string strAdminName, string strAdminPassword)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@AdminName", SqlDbType.NVarChar, 50, strAdminName), db.CreateInParam("@AdminPassword", SqlDbType.NVarChar, 50, strAdminPassword) };

            ///返回添加新QQ的ID
            return (db.RunProc("Pr_AddSingleAdmin", param));
        }
        /// <summary>
        /// 判断帐号和密码是否正确
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public SqlDataReader GetAdminLogin(String strUserName, String strPassword)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { 
                                       db.CreateInParam("@AdminName", SqlDbType.NVarChar, 50, strUserName), 
                                       db.CreateInParam("@AdminPassword", SqlDbType.NVarChar, 50, strPassword) 
                                   };
            db.RunProc("Pr_GetAdminLogin", param, out dr);
            return dr;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strOldPassword"></param>
        /// <param name="strNewPassword"></param>
        public int UpdateAdminPassword(String strUserName, String strOldPassword, String strNewPassword)
        {
            Database db = new Database();
            SqlParameter[] param ={
                db.CreateInParam("@AdminName",SqlDbType.NVarChar,50,strUserName),
                db.CreateInParam("@OldPwd",SqlDbType.NVarChar,50,strOldPassword),
                db.CreateInParam("@NewPwd",SqlDbType.NVarChar,50,strNewPassword),
            };
            return (db.RunProc("Pr_UpdateAdminPassword", param));
        }
    }
}

