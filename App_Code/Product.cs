using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 产品类
    /// </summary>
    public class Products
    {
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetAllProducts()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetAllProducts", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取置顶产品
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetStateProducts()
        {
            Database db = new Database();
            SqlDataReader dr = null;
            db.RunProc("Pr_GetStateProducts", out dr);

            return (dr);
        }
        /// <summary>
        /// 获取该分类下所有产品
        /// </summary>
        /// <param name="intClassID"></param>
        /// <returns></returns>
        public SqlDataReader GetProducts(object strClassID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            if (strClassID != null)
            {
                SqlParameter[] param = { db.CreateInParam("@ClassId", SqlDbType.NVarChar, 500, strClassID) };
                db.RunProc("Pr_GetProducts", param, out dr);
            }
            else
            {
                db.RunProc("Pr_GetAllProducts", out dr);
            }

            return (dr);
        }
        /// <summary>
        /// 获取单条产品信息
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public SqlDataReader GetSingleProduct(int intID)
        {
            Database db = new Database();
            SqlDataReader dr = null;
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            db.RunProc("Pr_GetSingleProduct", param, out dr);

            return (dr);
        }
        /// <summary>
        /// 删除单条产品信息
        /// </summary>
        /// <param name="intID"></param>
        public int DeleteSingleProduct(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@Id", SqlDbType.Int, 4, intID) };
            return (db.RunProc("Pr_DeleteSingleProduct", param));
        }
        /// <summary>
        /// 模糊查询，删除产品信息
        /// </summary>
        /// <param name="intClassID"></param>
        /// <returns></returns>
        public int DeleteLikeProduct(string strClassID)
        {
            Database db = new Database();
            SqlParameter[] param = { db.CreateInParam("@ClassId", SqlDbType.NVarChar, 500, strClassID) };
            return (db.RunProc("Pr_DeleteLikeProduct", param));
        }
        /// <summary>
        /// 更新单个产品信息
        /// </summary>
        /// <param name="intProId"></param>
        /// <param name="intClassId"></param>
        /// <param name="intPaixu"></param>
        /// <param name="strProName"></param>
        /// <param name="strProBianhao"></param>
        /// <param name="strProChandi"></param>
        /// <param name="strProPrice"></param>
        /// <param name="strProPath"></param>
        /// <param name="strProKeyDescription"></param>
        /// <param name="strProDescription"></param>
        /// <param name="strPutdate"></param>
        /// <param name="intState"></param>
        public int UpdateSingleProduct(int intProId, string strClassId, int intPaixu, string strProName, string strProBianhao, string strProChandi, string strProPrice, string strProPath, string strProKeyDescription, string strProDescription,string strKeywords, int intState)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ProId", SqlDbType.Int, 4, intProId),
                db.CreateInParam("@ClassId", SqlDbType.NVarChar, 500, strClassId),
                db.CreateInParam("@Paixu", SqlDbType.Int, 4, intPaixu),
                db.CreateInParam("@ProName", SqlDbType.NVarChar, 255, strProName),
                db.CreateInParam("@ProBianhao", SqlDbType.NVarChar, 100, strProBianhao),
                db.CreateInParam("@ProChandi", SqlDbType.NVarChar, 100, strProChandi),
                db.CreateInParam("@ProPrice", SqlDbType.NVarChar, 100, strProPrice),
                db.CreateInParam("@ProPath", SqlDbType.NVarChar, 255, strProPath),
                db.CreateInParam("@ProKeyDescription", SqlDbType.NText, 1073741823, strProKeyDescription),
                db.CreateInParam("@ProDescription", SqlDbType.NText, 1073741823, strProDescription),
                db.CreateInParam("@Keywords", SqlDbType.NVarChar, 255, strKeywords),
                db.CreateInParam("@State", SqlDbType.Int, 4, intState)
            };
            return (db.RunProc("Pr_UpdateSingleProduct", param));
        }
        /// <summary>
        /// 添加新产品
        /// </summary>
        /// <param name="intClassId"></param>
        /// <param name="intPaixu"></param>
        /// <param name="strProName"></param>
        /// <param name="strProBianhao"></param>
        /// <param name="strProChandi"></param>
        /// <param name="strProPrice"></param>
        /// <param name="strProPath"></param>
        /// <param name="strProKeyDescription"></param>
        /// <param name="strProDescription"></param>
        /// <param name="strKeywords"></param>
        /// <param name="strPutdate"></param>
        /// <param name="intState"></param>
        /// <returns></returns>
        public int AddSingleProduct(string strClassId, int intPaixu, string strProName, string strProBianhao, string strProChandi, string strProPrice, string strProPath, string strProKeyDescription, string strProDescription, string strKeywords,string strPutdate, int intState)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ClassId", SqlDbType.NVarChar, 500, strClassId),
                db.CreateInParam("@Paixu", SqlDbType.Int, 4, intPaixu),
                db.CreateInParam("@ProName", SqlDbType.NVarChar, 255, strProName),
                db.CreateInParam("@ProBianhao", SqlDbType.NVarChar, 100, strProBianhao),
                db.CreateInParam("@ProChandi", SqlDbType.NVarChar, 100, strProChandi),
                db.CreateInParam("@ProPrice", SqlDbType.NVarChar, 100, strProPrice),
                db.CreateInParam("@ProPath", SqlDbType.NVarChar, 255, strProPath),
                db.CreateInParam("@ProKeyDescription", SqlDbType.NText, 1073741823, strProKeyDescription),
                db.CreateInParam("@ProDescription", SqlDbType.NText, 1073741823, strProDescription),
                db.CreateInParam("@Keywords", SqlDbType.NVarChar, 255, strKeywords),
                db.CreateInParam("@Putdate", SqlDbType.NVarChar, 19, strPutdate),
                db.CreateInParam("@State", SqlDbType.Int, 4, intState)
            };

            ///返回新添加产品的ID
            return (db.RunProc("Pr_AddSingleProduct", param));
        }
        /// <summary>
        /// 更新产品浏览次数
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>
        public int UpdateProductHits(int intID)
        {
            Database db = new Database();
            SqlParameter[] param = {  
                db.CreateInParam("@ProId", SqlDbType.Int, 4, intID)
            };

            ///返回受影响的行数
            return (db.RunProc("Pr_UpdateProductHits", param));
        }
        /// <summary>
        /// 更新产品列表静态页面地址和状态
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="strStaticUrl"></param>
        /// <param name="strStaticPage"></param>
        /// <returns></returns>
        public int UpdateProStaticPage(int intID, string strStaticUrl, string strStaticPage)
        {
            Database db = new Database();
            SqlParameter[] param = {
                db.CreateInParam("@ProID", SqlDbType.Int, 4, intID),
                db.CreateInParam("@StaticUrl", SqlDbType.NVarChar, 25, strStaticUrl),
                db.CreateInParam("@StaticPage", SqlDbType.NChar, 1, strStaticPage),
            };

            ///返回ID
            return (db.RunProc("Pr_UpdateProStaticPage", param));
        }
    }
}

