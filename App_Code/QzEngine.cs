using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using basic;

/// <summary>
/// 企智引擎
/// </summary>
namespace Basic.Engine.Get.Table
{
    #region 栏目表

    /// <summary>
    /// 栏目表
    /// </summary>
    public static class ColumnList
    {
        static BasicPage bp = new BasicPage();
        /// <summary>
        /// 栏目名称
        /// </summary>
        public static string ColumnName(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select ColumnName from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 栏目备注名称
        /// </summary>
        public static string ColumnSubName(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select ColumnSubName from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public static string Path(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Path from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public static string Remarks(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Remarks from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 链接
        /// </summary>
        public static string ColumnUrlClient(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select ColumnUrlClient from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 栏目类别
        /// </summary>
        public static string ColumnType(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select ColumnType from ColumnList where ID=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
    }
    #endregion

    #region 新闻表

    /// <summary>
    /// 新闻表
    /// </summary>
    public static class News
    {
        static BasicPage bp = new BasicPage();
        /// <summary>
        /// 内容
        /// </summary>
        public static string Content(int ClassId)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Content from News where ClassId=" + ClassId + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
    }
    #endregion

    #region 网站设置

    /// <summary>
    /// 网站设置
    /// </summary>
    public static class Website
    {
        static BasicPage bp = new BasicPage();
        /// <summary>
        /// 公司名称
        /// </summary>
        public static string CompanyName(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select CompanyName from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 传真
        /// </summary>
        public static string Fax(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Fax from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 电话
        /// </summary>
        public static string Phone(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Phone from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public static string Zip(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Zip from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 网址
        /// </summary>
        public static string WebUrl(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select WebUrl from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 手机
        /// </summary>
        public static string Mobile(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Mobile from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public static string Contact(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Contact from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 地址
        /// </summary>
        public static string Address(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Address from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public static string Email(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Email from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// QQ
        /// </summary>
        public static string QQ(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select QQ from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 备案号
        /// </summary>
        public static string ICP(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select ICP from Website where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
    }
    #endregion

    #region 友情链接分类

    /// <summary>
    /// 友情链接
    /// </summary>
    public static class LinksType
    {
        static BasicPage bp = new BasicPage();
        /// <summary>
        /// 分类名称
        /// </summary>
        public static string TypeTitle(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select TypeTitle from LinksType where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
    }
    #endregion

    #region 图片空间

    /// <summary>
    /// 图片空间
    /// </summary>
    public static class TbPic
    {
        static BasicPage bp = new BasicPage();
        /// <summary>
        /// 图片路径
        /// </summary>
        public static string Path(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Path from TbPic where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 图片备注
        /// </summary>
        public static string Beizhu(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Beizhu from TbPic where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 链接
        /// </summary>
        public static string Url(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Url from TbPic where Id=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public static string PathByClassID(int ClassID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Path from TbPic where ClassID=" + ClassID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 链接
        /// </summary>
        public static string UrlByClassID(int ClassID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Url from TbPic where ClassID=" + ClassID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
    }
    #endregion

    #region 流量统计

    /// <summary>
    /// 流量统计
    /// </summary>
    public static class tb_tongji
    {
        static BasicPage bp = new BasicPage();
        /// <summary>
        /// 流量
        /// </summary>
        public static string Number()
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Number from tb_tongji");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
    }
    #endregion

    #region 产品分类表
    /// <summary>
    /// 产品分类表
    /// </summary>
    public static class ProClass
    {
        static BasicPage bp = new BasicPage();
        /// <summary>
        /// 栏目名称
        /// </summary>
        public static string Context(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select Context from ProClass where ID=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }
        /// <summary>
        /// 父级阿第
        /// </summary>
        public static string ParentId(int ID)
        {
            string Con = "";
            SqlDataReader myread = bp.getRead("select ParentId from ProClass where ID=" + ID + "");
            if (myread.Read())
            {
                Con = myread[0].ToString();
            }
            myread.Close();
            return Con;
        }

    }
    #endregion
}
