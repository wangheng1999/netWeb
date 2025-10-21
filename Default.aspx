<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/UserControls/Head.ascx" TagName="HeadControl" TagPrefix="ucHeadControl" %>
<%@ Register Src="~/UserControls/BannerControl.ascx" TagName="BannerControl" TagPrefix="ucBannerControl" %>
<%@ Register Src="~/UserControls/Link.ascx" TagName="LinkControl" TagPrefix="ucLinkControl" %>
<%@ Register Src="~/UserControls/Foot.ascx" TagName="FootControl" TagPrefix="ucFootControl" %>
<%@ Register Src="~/UserControls/Category.ascx" TagName="CategoryControl" TagPrefix="ucCategoryControl" %>
<%@ Register Src="~/UserControls/Left.ascx" TagName="LeftControl" TagPrefix="ucLeftControl" %>
<%@ Register Src="~/UserControls/Contact.ascx" TagName="ContactControl" TagPrefix="ucContactControl" %>
<!doctype html>
<html>
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <meta name="description" id="description" content="" runat="server" />
    <meta name="keywords" id="keywords" content="" runat="server" />
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="css/theme.css" type="text/css" media="all" />
    <link rel="stylesheet" href="css/all.min.css" type="text/css" media="all" />
    <script type="text/javascript" src="js/jquery.js" id="jquery-core-js"></script>
    <script type="text/javascript" src="js/jquery-1-7-2.js"></script>
    <link rel="stylesheet" href="css/swiper.min.css" type="text/css" media="all" />
</head>
<body class="home page-template-default page page-id-23041">
    <div id="page" class="site">
        <ucHeadControl:HeadControl ID="HeadControl" runat="server" />
        <div id="content" class="site-content bg-gray-100">
            <ucBannerControl:BannerControl ID="BannerControl" runat="server" />
            <div class="products-wrapper bg-gray-100">
                <div class="container mx-auto px-4 pt-16 text-center">
                    <h2 class="text-2xl md:text-3xl text-gray-900 font-bold leading-tight mb-2"><%=mc.ShowColumnName(10) %></h2>
                    <span class="line-header"></span>
                    <p class="text-gray-600 mt-4 font-light text-base md:text-base"></p>
                </div>
                <div class="container mx-auto px-4 flex flex-wrap pt-8 pb-16">
                    <%showNews(10, 4); %>
                    <%for (int j = 0; j < intNews; j++)
                      {
                          string path = dtblNews.Rows[j]["path"].ToString();
                          string title = dtblNews.Rows[j]["title"].ToString();
                          string id = dtblNews.Rows[j]["id"].ToString();
                          string putdate = dtblNews.Rows[j]["putdate"].ToString();
                          string url = dtblNews.Rows[j]["url"].ToString();
                          string keywords = dtblNews.Rows[j]["keywords"].ToString();
                          string keycontent = dtblNews.Rows[j]["keycontent"].ToString();

                          int classid = int.Parse(dtblNews.Rows[j]["classid"].ToString());
                          string columntype = mc.ShowColumnKeyById(classid, "ColumnType");
                          if (url == "")
                          {
                              if (columntype == "新闻列表") { url = "NewsDetail.aspx?ID=" + id; }
                              else if (columntype == "图片列表") { url = "PicDetail.aspx?ID=" + id; }
                              else { url = "DownloadDetail.aspx?ID=" + id; }
                          }
                    %>
                    <div class="product-item w-1/2 md:w-1/2 lg:w-1/4">
                        <div class="block overflow-hidden relative text-center m-0">
                            <a class="w-full h-full absolute top-0 left-0 z-40" href="<%=url %>" title="<%=title %>"></a>
                            <div class="product-item-overlay absolute text-center z-40 inset-0 opacity-50 xl:bg-indigo-400 bg-black"></div>
                            <div class="product-item-title absolute z-40 text-white text-lg w-full">
                                <h5 class="text-lg md:text-2xl lg:text-lg xl:text-3xl font-bold uppercase"><%=title %></h5>
                                <p class="hidden md:block xl:hidden my-4 lg:my-2 text-sm xl:text-base font-light px-4"></p>
                                <a href="<%=url %>" title="<%=title %>" class="inline-block xl:hidden btn btn-small btn-blue mt-4 md:mt-0 rounded-full text-xs">查看更多 </a>
                            </div>
                            <img src="<%=path %>" alt="<%=title %>" class="block object-cover max-w-full mx-auto w-full" sizes="(max-width: 600px) 100vw, 600px">
                        </div>
                    </div>
                    <%} %>
                </div>
            </div>
            <!--<div class="services-wrapper bg-gray-100">
                <div class="container mx-auto px-4 pt-16 text-center">
                    <h2 class="text-2xl md:text-3xl text-gray-900 font-bold leading-tight mb-2"><%=mc.ShowColumnName(12) %> </h2>
                    <span class="line-header"></span>
                    <p class="text-gray-600 mt-4 font-light text-base md:text-base"></p>
                </div>
                <div class="container mx-auto px-4 overflow-hidden">
                    <div class="md:flex md:flex-wrap mt-8 mb-16 md:-mx-4">
                        <%showNews(12, 4); %>
                        <%for (int j = 0; j < intNews; j++)
                          {
                              string path = dtblNews.Rows[j]["path"].ToString();
                              string title = dtblNews.Rows[j]["title"].ToString();
                              string id = dtblNews.Rows[j]["id"].ToString();
                              string putdate = dtblNews.Rows[j]["putdate"].ToString();
                              string url = dtblNews.Rows[j]["url"].ToString();
                              string keywords = dtblNews.Rows[j]["keywords"].ToString();
                              string keycontent = dtblNews.Rows[j]["keycontent"].ToString();

                              int classid = int.Parse(dtblNews.Rows[j]["classid"].ToString());
                              string columntype = mc.ShowColumnKeyById(classid, "ColumnType");
                              if (url == "")
                              {
                                  if (columntype == "新闻列表") { url = "NewsDetail.aspx?ID=" + id; }
                                  else if (columntype == "图片列表") { url = "PicDetail.aspx?ID=" + id; }
                                  else { url = "DownloadDetail.aspx?ID=" + id; }
                              }
                        %>
                        <div class="service-item lg:w-1/2 w-full md:px-4 py-4">
                            <div class="flex w-full h-full border hover:shadow-md px-4 py-8 bg-white">
                                <div class="flex-shrink-0 fa-stack fa-2x">
                                    <img src="<%=path %>" alt="<%=title %>" style="width: 64px; height: 64px;">
                                </div>
                                <div class="service-body ml-6">
                                    <h5 class="text-xl font-bold text-gray-700"><%=title %> </h5>
                                    <div class="text-gray-600 py-2 font-light text-sm"><%=keycontent %> </div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                    </div>
                </div>
            </div>-->
        </div>
        <ucFootControl:FootControl ID="FootControl" runat="server" />
    </div>
    <script type="text/javascript" src="js/theme.js" id="main-script-js"></script>
    <script type="text/javascript" src="js/swiper.min.js" id="swiper-script-js"></script>
    <script type="text/javascript" src="js/swiperanimation.min.js" id="swiper-animation-script-js"></script>
</body>
</html>
