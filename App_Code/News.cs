using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class News
    {
        /// <summary>
        /// 获取所有新闻
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetNews(int intClassID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ClassId", SqlDbType.Int, 4, intClassID) };
            db.RunProc("Pr_GetNews", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取前5条数据
        /// </summary>
        /// <param name="intClassID"></param>
        /// <returns></returns>
        public SqlDataReader GetRecentNews(int intClassID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ClassId", SqlDbType.Int, 4, intClassID)
            };
            db.RunProc("Pr_GetRecentNews", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单条新闻
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleNews(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleNews", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单条新闻
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleNews(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleNews", param));
        }
        /// <summary>
        /// 更新单条新闻
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strTitle"></param>
        /// <param name="strUrl"></param>
        /// <param name="strPath"></param>
        /// <param name="strFujian"></param>
        /// <param name="strKeyContent"></param>
        /// <param name="strContent"></param>
        /// <param name="strKeywords"></param>
        /// <param name="strPutdate"></param>
        /// <param name="intIstop"></param>
        /// <returns></returns>
        public int UpdateSingleNews(int intID, int intPaixu, string strTitle, string strUrl, string strPath, string strFujian, string strKeyContent, string strContent, string strKeywords, string strPutdate, int intIstop)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@Paixu", SqlDbType.Int, 4, intPaixu),
                db.CreateInParam("@Title", SqlDbType.NVarChar, 255, strTitle),
                db.CreateInParam("@Url", SqlDbType.NVarChar, 255, strUrl),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPath),
                db.CreateInParam("@Fujian", SqlDbType.NVarChar, 255, strFujian),
                db.CreateInParam("@KeyContent", SqlDbType.NVarChar, 500, strKeyContent),
                db.CreateInParam("@Content", SqlDbType.NText, 1073741823, strContent),
                db.CreateInParam("@Keywords", SqlDbType.NVarChar, 255, strKeywords),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate),
                db.CreateInParam("@Istop", SqlDbType.Int, 4, intIstop)
            };
            return (db.RunProc("Pr_UpdateSingleNews", param));
        }
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="strTitle"></param>
        /// <param name="strUrl"></param>
        /// <param name="strPath"></param>
        /// <param name="strFujian"></param>
        /// <param name="strKeyContent"></param>
        /// <param name="strContent"></param>
        /// <param name="strKeywords"></param>
        /// <param name="strPutdate"></param>
        /// <param name="intIstop"></param>
        /// <returns></returns>
        public int AddSingleNews(int ClassID, int intPaixu, string strTitle, string strUrl, string strPath, string strFujian, string strKeyContent, string strContent, string strKeywords, string strPutdate, int intIstop)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ClassId", SqlDbType.Int, 4, ClassID),
                db.CreateInParam("@Paixu", SqlDbType.Int, 4, intPaixu),
                db.CreateInParam("@Title", SqlDbType.NVarChar, 255, strTitle),
                db.CreateInParam("@Url", SqlDbType.NVarChar, 255, strUrl),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPath),
                db.CreateInParam("@Fujian", SqlDbType.NVarChar, 255, strFujian),
                db.CreateInParam("@KeyContent", SqlDbType.NVarChar, 500, strKeyContent),
                db.CreateInParam("@Content", SqlDbType.NText, 1073741823, strContent),
                db.CreateInParam("@Keywords", SqlDbType.NVarChar, 255, strKeywords),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate),
                db.CreateInParam("@Istop", SqlDbType.Int, 4, intIstop)
            };

            ///返回News的ID
            return (db.RunProc("Pr_AddSingleNews", param));
        }
        /// <summary>
        /// 更新新闻浏览次数
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public int UpdateNewsHits(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = {  
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID)
            };

            ///返回News的ID
            return (db.RunProc("Pr_UpdateNewsHits", param));
        }
        /// <summary>
        /// 更新新闻列表静态页面地址和状态
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strStaticUrl"></param>
        /// <param name="strStaticPage"></param>
        /// <returns></returns>
        public int UpdateNewsStaticPage(int intID, string strStaticUrl, string strStaticPage)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@StaticUrl", SqlDbType.NVarChar, 25, strStaticUrl),
                db.CreateInParam("@StaticPage", SqlDbType.NChar, 1, strStaticPage),
            };

            ///返回ID
            return (db.RunProc("Pr_UpdateNewsStaticPage", param));
        }
    }
}

