using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 产品分类
    /// </summary>
    public class ProClass
    {
        /// <summary>
        /// 获取所有产品分类列表
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetProClass()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetProClass", out dr);

            return (dr);
        }
        /// <summary>
        /// 判断该父级下是否有子级
        /// </summary>
        /// <param name="intParentID"></param>
        /// <returns></returns>
        public SqlDataReader GetProClassSub(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ParentId", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetProClassSub", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单条产品分类信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleProClass(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleProClass", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除某个分类
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleProClass(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleProClass", param));
        }
        /// <summary>
        /// 修改单条分类信息
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="intPaixu"></param>
        /// <param name="intParentId"></param>
        /// <param name="strContext"></param>
        /// <param name="strContent"></param>
        /// <param name="strPath"></param>
        /// <param name="intState"></param>
        public int UpdateSingleProClass(int intID, int intPaixu, int intParentId, string strContext, string strContent, string strPath, int intState)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@Paixu", SqlDbType.Int, 4, intPaixu),
                db.CreateInParam("@ParentId", SqlDbType.Int, 4, intParentId),
                db.CreateInParam("@Context", SqlDbType.NVarChar, 255, strContext),
                db.CreateInParam("@Content", SqlDbType.NVarChar, 4000, strContent),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPath),
                db.CreateInParam("@State", SqlDbType.Int, 4, intState)
            };
            return (db.RunProc("Pr_UpdateSingleProClass", param));
        }
        /// <summary>
        /// 添加新的产品分类
        /// </summary>
        /// <param name="intPaixu"></param>
        /// <param name="intParentId"></param>
        /// <param name="strContext"></param>
        /// <param name="strContent"></param>
        /// <param name="intState"></param>
        /// <returns></returns>
        public int AddSingleProClass(int intPaixu, int intParentId, string strContext)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Paixu", SqlDbType.Int, 4, intPaixu),
                db.CreateInParam("@ParentId", SqlDbType.Int, 4, intParentId),
                db.CreateInParam("@Context", SqlDbType.NVarChar, 255, strContext)
            };

            ///返回添加新产品分类的ID
            return (db.RunProc("Pr_AddSingleProClass", param));
        }
    }
}

