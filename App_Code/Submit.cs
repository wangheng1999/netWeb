using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 创建表单
    /// </summary>
    public class Submit
    {
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="strFormContent"></param>
        /// <returns></returns>
        public int InsertSubmitform(string strFormContent, string strPutdate)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@FormContent", SqlDbType.NText, 8000, strFormContent),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate)
            };
            return (db.RunProc("Pr_InsertSubmitform", param));
        }
        /// <summary>
        /// 更新表单内容
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strFormContent"></param>
        /// <param name="strPutdate"></param>
        /// <returns></returns>
        public int UpdateSubmitform(int intID, string strFormContent, string strPutdate)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@FormContent", SqlDbType.NText,8000,strFormContent),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate)
            };
            return (db.RunProc("Pr_UpdateSubmitform", param));
        }
        /// <summary>
        /// 获取单条表单信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSubmitform(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSubmitform", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取表单列表
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetSubmitList()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetSubmitList", out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单条表单信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public int DeleteSingleSubmit(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleSubmit", param));
        }
        /// <summary>
        /// 设置表单代码
        /// </summary>
        /// <param name="intFormID"></param>
        /// <param name="strFormState"></param>
        /// <param name="strFormContent"></param>
        /// <returns></returns>
        public int UpdateSetForm(int intFormID, string strFormState, string strFormContent)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@FormID", SqlDbType.Int, 4, intFormID),
                db.CreateInParam("@FormState", SqlDbType.NChar,1,strFormState),
                db.CreateInParam("@FormContent", SqlDbType.NText,32000, strFormContent)
            };
            return (db.RunProc("Pr_UpdateSetForm", param));
        }
        /// <summary>
        /// 获取表单内容代码
        /// </summary>
        /// <param name="intFormID"></param>
        /// <returns></returns>
        public SqlDataReader GetForm(int intFormID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@FormID", SqlDbType.Int, 4, intFormID) };
            db.RunProc("Pr_GetForm", param, out dr);

            return (dr);
        }
    }
}


