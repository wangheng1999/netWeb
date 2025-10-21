using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace Basic.Engine.Get
{
    /// <summary>
    /// 获取分页代码
    /// </summary>
    public static class PagiNation
    {
        /// <summary>
        /// 获取分页代码（总页数，当前页）
        /// </summary>
        /// <param name="TotelPage"></param>
        /// <param name="NowPage"></param>
        public static string GetPageHtml(int TotelPage, int NowPage)
        {

            string NowUrl = HttpContext.Current.Request.RawUrl;
            Regex Rzz = new Regex(@"\?page=\d+|\&page=\d+", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            NowUrl = Rzz.Replace(NowUrl, "", 1);

            if (NowUrl.ToLower().Contains("?"))
            {
                NowUrl = NowUrl + "&page=";
            }
            else
            {
                NowUrl = NowUrl + "?page=";
            }
            int prevPage = NowPage - 1;
            int nextPage = NowPage + 1;
            StringBuilder strFenye = new StringBuilder();
            if (TotelPage > 1)
            {
                strFenye.Append("<div id=\"PageContent\" class=\"flickr\" style=\"text-align: center;\">");
                strFenye.Append("<div class=\"pages\">");

                if (NowPage > 1)//第一页的时候 不显示上一页
                {
                    strFenye.Append("<span><a href=\"" + NowUrl + prevPage + "\">«上一页</a></span>");
                }
                if (NowPage != 1)//当前页不是第一页的时候始终显示 第一页
                {
                    strFenye.Append("<span><a href=\"" + NowUrl + "1\">1</a></span>");
                }
                if (NowPage >= 5)//当前页大于5时候 显示 ...
                {
                    strFenye.Append("<span>...</span>");

                    for (int i = 2; i <= NowPage - 3; i++)
                    {
                        strFenye.Append("<span class=\"pageyc\"><a  href=\"" + NowUrl + i + "\">" + i + "</a></span>");
                    }
                }
                if (TotelPage < 6)
                {
                    #region 总页数小于5时

                    //
                    for (int i = 0; i < (TotelPage + 1); i++)
                    {
                        if (i > 0)
                        {
                            if (i == NowPage)
                            {
                                strFenye.Append("<span class=\"number\">" + i + "</span>");
                            }
                            else
                            {
                                if (i != 1)
                                {
                                    strFenye.Append("<span><a href=\"" + NowUrl + i + "\">" + i + "</a></span>");
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 总页数大于5时
                    //
                    int endPage = 0;
                    if (TotelPage > NowPage + 2)
                    {
                        endPage = NowPage + 2;
                    }
                    else
                    {
                        endPage = NowPage;
                    }



                    //
                    for (int i = NowPage - 2; i <= endPage; i++)
                    {
                        if (i > 0)
                        {
                            if (i == NowPage)
                            {
                                strFenye.Append("<span class=\"number\">" + i + "</span>");
                            }
                            else
                            {
                                if (i != 1 && i != TotelPage)
                                {
                                    strFenye.Append("<span><a href=\"" + NowUrl + i + "\">" + i + "</a></span>");
                                }
                            }
                        }
                    }

                    if (NowPage == TotelPage - 2)
                    {
                        strFenye.Append("<span><a href=\"" + NowUrl + (NowPage + 1) + "\">" + (NowPage + 1) + "</a></span>");
                    }

                    if (NowPage + 3 < TotelPage)
                    {
                        strFenye.Append("<span>...</span>");
                        for (int i = NowPage + 3; i <= TotelPage - 1; i++)
                        {
                            strFenye.Append("<span class=\"pageyc\"><a  href=\"" + NowUrl + i + "\">" + i + "</a></span>");
                        }
                    }

                    if (NowPage != TotelPage)
                    {
                        strFenye.Append("<span><a href=\"" + NowUrl + TotelPage + "\">" + TotelPage + "</a></span>");
                    }
                    #endregion
                }

                if (NowPage < TotelPage)//最后一页 不显示下一页
                {
                    strFenye.Append("<span><a href=\"" + NowUrl + nextPage + "\">下一页»</a></span>");
                }
                strFenye.Append("</div>");
                strFenye.Append("</div>");
            }
            return strFenye.ToString();
        }
    }
}
