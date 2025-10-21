using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 友情链接
    /// </summary>
    public class Links
    {
        /// <summary>
        /// 获取所有友情链接
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetLinks()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetLinks", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取某分类下友情链接
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetLinks_TypeID(int intTypeID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@TypeID", SqlDbType.Int, 4, intTypeID) };
            db.RunProc("Pr_GetLinks_TypeID", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单个友情链接
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleLinks(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleLinks", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单个友情链接
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleLinks(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleLinks", param));
        }
        /// <summary>
        /// 修改单个友情链接
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strTitle"></param>
        /// <param name="strUrl"></param>
        /// <param name="strPutdate"></param>
        public int UpdateSingleLinks(int intID, string strTitle, string strUrl, string strPutdate, int intTypeID)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@Title", SqlDbType.NVarChar, 255, strTitle),
                db.CreateInParam("@Url", SqlDbType.NVarChar, 255, strUrl),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate),
                db.CreateInParam("@TypeID", SqlDbType.Int, 4, intTypeID)
            };
            return (db.RunProc("Pr_UpdateSingleLinks", param));
        }
        /// <summary>
        /// 添加新的友情链接
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strUrl"></param>
        /// <param name="strPutdate"></param>
        /// <returns></returns>
        public int AddSingleLinks(string strTitle, string strUrl, string strPutdate, int intTypeID)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Title", SqlDbType.NVarChar, 255, strTitle),
                db.CreateInParam("@Url", SqlDbType.NVarChar, 255, strUrl),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate),
                db.CreateInParam("@TypeID", SqlDbType.Int, 4, intTypeID)
            };

            ///返回添加新友情链接的ID
            return (db.RunProc("Pr_AddSingleLinks", param));
        }

        /// <summary>
        /// 获取所有友链分类
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetLinksType()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetLinksType", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单个友链分类
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleLinksType(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleLinksType", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单个友链分类
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleLinksType(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleLinksType", param));
        }
        /// <summary>
        /// 修改单个友链分类
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strTitle"></param>
        /// <param name="strUrl"></param>
        /// <param name="strPutdate"></param>
        public int UpdateSingleLinksType(int intID, string strTypeTitle)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@TypeTitle", SqlDbType.NVarChar, 255, strTypeTitle)
            };
            return (db.RunProc("Pr_UpdateSingleLinksType", param));
        }
        /// <summary>
        /// 添加新的友链分类
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strUrl"></param>
        /// <param name="strPutdate"></param>
        /// <returns></returns>
        public int AddSingleLinksType(string strTypeTitle)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@TypeTitle", SqlDbType.NVarChar, 255, strTypeTitle)
            };

            ///返回添加新友情链接的ID
            return (db.RunProc("Pr_AddSingleLinksType", param));
        }
    }
}

