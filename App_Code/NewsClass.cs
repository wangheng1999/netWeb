using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;

namespace WebApp.Components
{
    /// <summary>
    /// 网站栏目
    /// </summary>
    public class NewsClass
    {
        /// <summary>
        /// 获取所有栏目列表
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetColumnList()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetColumnList", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取栏目当前最大ID
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetColumnListMaxId()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetColumnListMaxId", out dr);

            return (dr);
        }
        /// <summary>
        /// 判断该父级下是否有子级
        /// </summary>
        /// <param name="intParentID"></param>
        /// <returns></returns>
        public SqlDataReader GetColumnListSub(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@ParentId", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetColumnListSub", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取单个栏目名称
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleColumnList(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleColumnList", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 获取父级栏目名称
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleParentColumnList(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleParentColumnList", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单个栏目
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleColumnList(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleColumnList", param));
        }
        /// <summary>
        /// 修改单个栏目名称
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strColumnType"></param>
        /// <param name="strColumnName"></param>
        /// <param name="intColumnNo"></param>
        public int UpdateSingleColumnList(int intID, int intParentId, string strColumnType, string strColumnName, string strColumnSubName, int intColumnNo, string strColumnUrlClient, int intRole, int intIndexStatus, string strRemarks, string strPath, int intLength, int intWidth)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@ParentId", SqlDbType.Int, 4, intParentId),
                db.CreateInParam("@ColumnType", SqlDbType.NVarChar, 25, strColumnType),
                db.CreateInParam("@ColumnName", SqlDbType.NVarChar, 50, strColumnName),
                db.CreateInParam("@ColumnSubName", SqlDbType.NVarChar, 50, strColumnSubName),
                db.CreateInParam("@ColumnNo", SqlDbType.Int, 4, intColumnNo),
                db.CreateInParam("@ColumnUrlClient", SqlDbType.NVarChar, 100, strColumnUrlClient),
                db.CreateInParam("@Role", SqlDbType.Int, 4, intRole),
                db.CreateInParam("@IndexStatus", SqlDbType.Int, 4, intIndexStatus),
                db.CreateInParam("@Remarks", SqlDbType.NVarChar, 4000, strRemarks),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPath),
                db.CreateInParam("@Length", SqlDbType.Int, 4, intLength),
                db.CreateInParam("@Width", SqlDbType.Int, 4, intWidth)
            };
            return (db.RunProc("Pr_UpdateSingleColumnList", param));
        }
        /// <summary>
        /// 为每个栏目设置SEO优化
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strColumnTitle"></param>
        /// <param name="strColumnDescription"></param>
        /// <param name="strColumnKeywords"></param>
        /// <returns></returns>
        public int SetColumnSEO(int intID, string strColumnTitle, string strColumnDescription, string strColumnKeywords)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@ColumnTitle", SqlDbType.NVarChar, 255, strColumnTitle),
                db.CreateInParam("@ColumnDescription ", SqlDbType.NVarChar, 255, strColumnDescription),
                db.CreateInParam("@ColumnKeywords", SqlDbType.NVarChar, 255, strColumnKeywords),
            };
            return (db.RunProc("Pr_SetColumnSEO", param));
        }
        /// <summary>
        /// 添加新的栏目
        /// </summary>
        /// <param name="strColumnType"></param>
        /// <param name="strColumnName"></param>
        /// <param name="intColumnNo"></param>
        /// <param name="intParentId"></param>
        /// <returns></returns>
        public int AddSingleColumnList(int intID, string strColumnType, string strColumnName, string strColumnSubName, int intColumnNo, string strColumnUrlClient, int intParentId, int intRole, int intIndexStatus, string strRemarks, string strPicPath,int intLength,int intWidth)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@Id", SqlDbType.Int, 4, intID),
                db.CreateInParam("@ColumnType", SqlDbType.NVarChar, 25, strColumnType),
                db.CreateInParam("@ColumnName", SqlDbType.NVarChar, 50, strColumnName),
                db.CreateInParam("@ColumnSubName", SqlDbType.NVarChar, 50, strColumnSubName),
                db.CreateInParam("@ColumnNo", SqlDbType.Int, 4, intColumnNo),
                db.CreateInParam("@ColumnUrlClient", SqlDbType.NVarChar, 100, strColumnUrlClient),
                db.CreateInParam("@ParentId", SqlDbType.Int, 4, intParentId),
                db.CreateInParam("@Role", SqlDbType.Int, 4, intRole),
                db.CreateInParam("@IndexStatus", SqlDbType.Int, 4, intIndexStatus),
                db.CreateInParam("@Remarks", SqlDbType.NVarChar, 4000, strRemarks),
                db.CreateInParam("@Path", SqlDbType.NVarChar, 255, strPicPath),
                db.CreateInParam("@Length", SqlDbType.Int, 4, intLength),
                db.CreateInParam("@Width", SqlDbType.Int, 4, intWidth)
            };

            ///返回添加新栏目的ID
            return (db.RunProc("Pr_AddSingleColumnList", param));
        }
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static string GetWebContent(string strUrl)
        {
            string strResult = "";
            //声明一个HttpWebRequest请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            //设置连接超时时间
            request.Timeout = 30000;
            request.Headers.Set("Pragma", "no-cache");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            strResult = streamReader.ReadToEnd();
            return strResult;
        }
        /// <summary>
        /// 更新静态页面地址和状态
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strColumnStaticPage"></param>
        /// <param name="strStaticPage"></param>
        /// <returns></returns>
        public int UpdateColumnStaticPage(int intID, string strColumnStaticPage, string strStaticPage)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@ColumnStaticPage", SqlDbType.NVarChar, 25, strColumnStaticPage),
                db.CreateInParam("@StaticPage", SqlDbType.NChar, 1, strStaticPage),
            };

            ///返回ID
            return (db.RunProc("Pr_UpdateColumnStaticPage", param));
        }
        /// <summary>
        /// 返回图片或者Flash
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public string change(string strType, string strPath)
        {
            string str = null;
            if (strType == "swf")
            {
                str = "<script type=\"text/javascript\">F_viewSwf('150','110','transparent','transparent','../" + strPath + "');</script>";
            }
            else
            {
                str = "<a href='../" + strPath + "' target='_blank'><img src='../" + strPath + "' alt='' style='border:0px;'/></a>";
            }
            return str;
        }
    }
}

