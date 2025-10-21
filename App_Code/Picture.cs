using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 客服系统
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// 获取所有图片
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetPic()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetPic", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSinglePic(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSinglePic", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单个数据
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSinglePic(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@ID", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSinglePic", param));
        }
        /// <summary>
        /// 修改单个数据
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="intClassID"></param>
        /// <param name="strType"></param>
        /// <param name="intLength"></param>
        /// <param name="intWidth"></param>
        /// <param name="strPath"></param>
        /// <param name="strUrl"></param>
        /// <param name="strBeizhu"></param>
        /// <returns></returns>
        public int UpdateSinglePic(int intID, int intClassID, int intPaixu, string strType, int intLength, int intWidth, string strPath, string strUrl, string strBeizhu)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@ClassID", SqlDbType.Int, 4, intClassID),
                db.CreateInParam("@Paixu", SqlDbType.Int, 4, intPaixu),
                db.CreateInParam("@Type", SqlDbType.NVarChar, 25, strType),
                db.CreateInParam("@Length", SqlDbType.Int, 4, intLength),
                db.CreateInParam("@Width", SqlDbType.Int, 4, intWidth),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPath),
                db.CreateInParam("@Url", SqlDbType.NVarChar, 255, strUrl),
                db.CreateInParam("@Beizhu", SqlDbType.NVarChar, 255, strBeizhu)
            };
            return (db.RunProc("Pr_UpdateSinglePic", param));
        }
        /// <summary>
        /// 添加新的数据
        /// </summary>
        /// <param name="intClassID"></param>
        /// <param name="strType"></param>
        /// <param name="intLength"></param>
        /// <param name="intWidth"></param>
        /// <param name="strPath"></param>
        /// <param name="strUrl"></param>
        /// <param name="strBeizhu"></param>
        /// <param name="strPutdate"></param>
        /// <returns></returns>
        public int AddSinglePic(int intClassID, int intPaixu, string strType, int intLength, int intWidth, string strPath, string strUrl, string strBeizhu, string strPutdate)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ClassID", SqlDbType.Int, 4, intClassID),
                db.CreateInParam("@Paixu", SqlDbType.Int, 4, intPaixu),
                db.CreateInParam("@Type", SqlDbType.NVarChar, 25, strType),
                db.CreateInParam("@Length", SqlDbType.Int, 4, intLength),
                db.CreateInParam("@Width", SqlDbType.Int, 4, intWidth),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPath),
                db.CreateInParam("@Url", SqlDbType.NVarChar, 255, strUrl),
                db.CreateInParam("@Beizhu", SqlDbType.NVarChar, 255, strBeizhu),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate)
            };

            ///返回添加新数据ID
            return (db.RunProc("Pr_AddSinglePic", param));
        }
    }
}

