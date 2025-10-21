<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News2" %>

<%@ Register Src="~/UserControls/Head.ascx" TagName="HeadControl" TagPrefix="ucHeadControl" %>
<%@ Register Src="~/UserControls/BannerControl.ascx" TagName="BannerControl" TagPrefix="ucBannerControl" %>
<%@ Register Src="~/UserControls/Link.ascx" TagName="LinkControl" TagPrefix="ucLinkControl" %>
<%@ Register Src="~/UserControls/Foot.ascx" TagName="FootControl" TagPrefix="ucFootControl" %>
<%@ Register Src="~/UserControls/Category.ascx" TagName="CategoryControl" TagPrefix="ucCategoryControl" %>
<%@ Register Src="~/UserControls/Left.ascx" TagName="LeftControl" TagPrefix="ucLeftControl" %>
<%@ Register Src="~/UserControls/Contact.ascx" TagName="ContactControl" TagPrefix="ucContactControl" %>

<%--fastcontrol 0.1--%>
<%@ Register Src="~/UserControls/Top.ascx" TagName="Top" TagPrefix="ucTop" %>
<%@ Register Src="~/UserControls/Start.ascx" TagName="Start" TagPrefix="ucStart" %>
<%@ Register Src="~/UserControls/End.ascx" TagName="End" TagPrefix="ucEnd" %>
<!doctype html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <meta name="description" id="description" content="" runat="server" />
    <meta name="keywords" id="keywords" content="" runat="server" />
    <ucTop:Top ID="Top" runat="server" />
    <%--默认--%>
    <link href="css/page.css" rel="stylesheet" type="text/css" />
    <link href="css/update.css" rel="stylesheet" type="text/css" />
</head>
<body class="archive category category-news category-2">
    <ucStart:Start ID="Start" runat="server" />
    <div class="page-wrapper container mx-auto px-8 flex flex-wrap bg-white">
        <div id="primary" class="content-area w-full lg:w-3/4 lg:pr-4 py-12">
            <!--Content Start-->
            <asp:Panel ID="NewsZidingyi" runat="server" Width="100%">
                <main id="main" class="site-main">
                    <asp:Repeater ID="DataList2" runat="server">
                        <ItemTemplate>

                            <article class="post type-post status-publish format-standard hentry category-product-news">
                                <div class="entry-card flex flex-wrap border mb-6 bg-white">
                                    <div class="entry-card-content p-6 w-full">
                                        <h2 class="entry-title"><a href="<%#CheckUrl(Eval("url", "{0}"), Eval("id", "{0}"))%>" class="text-2xl font-bold" style="color: #00a2e8;"><%#Eval("title") %> </a></h2>
                                        <div class="py-2 mb-1 text-sm text-gray-800">
                                            <i class="far fa-calendar-alt mr-1 text-blue-600"></i>
                                            <time datetime="<%#Convert.ToDateTime(Eval("putdate")).ToString("yyyy-MM-dd")%>" class=""><%#Convert.ToDateTime(Eval("putdate")).ToString("yyyy-MM-dd")%></time>
                                            <!--<i class="fas fa-folder-open mr-1 ml-2 text-blue-600"></i>
                                            <div class="inline-block entry-category"><a href="<%#CheckUrl(Eval("url", "{0}"), Eval("id", "{0}"))%>"><%#Eval("keywords") %></a></div>-->
                                        </div>
                                        <div class="excerpt leading-relaxed py-2 text-gray-800 text-sm">
                                            <p><%#Eval("keycontent") %></p>
                                            <p class="mt-4"><a class="text-sm font-semibold underline" href="<%#CheckUrl(Eval("url", "{0}"), Eval("id", "{0}"))%>">查看更多</a></p>
                                        </div>
                                        <footer class="entry-footer pt-2 flex justify-end"></footer>
                                    </div>
                                </div>
                            </article>

                        </ItemTemplate>
                    </asp:Repeater>
                </main>
            </asp:Panel>

            <asp:Panel ID="NewsMoban" runat="server" Width="100%">
                <%=strhtml %>
            </asp:Panel>

            <div class="clear">
            </div>
            <div class="page_box" style="width: 100%; padding-top: 5px; padding-bottom: 8px;">
                <%=Basic.Engine.Get.PagiNation.GetPageHtml(intTotalCount, page)%>
            </div>

            <!--Content End-->
        </div>
        <ucLeftControl:LeftControl ID="LeftControl" runat="server" />
    </div>
    <ucEnd:End ID="End" runat="server" />
</body>
</html>
