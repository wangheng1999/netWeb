using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 网站基本信息设置
    /// </summary>
    public static class WebSet
    {
        /// <summary>
        /// 下载中心 上传文件的最大值 单位 M
        /// </summary>
        public static int DownloadFileLength = 20;

        /// <summary>
        /// 图片空间 上传文件的最大值 单位 KB
        /// </summary>
        public static int PicManageFileLength = 900;

        /// <summary>
        /// 网站背景 上传文件的最大值 单位 KB
        /// </summary>
        public static int BackGroundFileLength = 100;

        /// <summary>
        /// 栏目 上传文件的最大值 单位 KB
        /// </summary>
        public static int NewsClassFileLength = 300;

        /// <summary>
        /// 新闻 上传文件的最大值 单位 KB
        /// </summary>
        public static int NewsFileLength = 300;

        /// <summary>
        /// 产品分类 上传文件的最大值 单位 KB
        /// </summary>
        public static int ProClassFileLength = 300;

        /// <summary>
        /// 产品 上传文件的最大值 单位 KB
        /// </summary>
        public static int ProductFileLength = 300;
    }
}


