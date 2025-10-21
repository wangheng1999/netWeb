<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PicList.aspx.cs" Inherits="PicList" %>

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
    <%--Ä¬ÈÏ--%>
    <link href="css/page.css" rel="stylesheet" type="text/css" />
    <link href="css/update.css" rel="stylesheet" type="text/css" />
</head>
<body class="archive post-type-archive post-type-archive-ft_publication">
    <ucStart:Start ID="Start" runat="server" />
    <div class="page-wrapper container mx-auto px-8 flex flex-wrap bg-white">
        <div id="primary" class="content-area w-full lg:w-3/4 lg:pr-4 py-12">
            <!--Content Start-->
            <asp:Panel ID="PicZidingyi" runat="server" Width="100%">
                <main id="main" class="site-main">
                    <asp:Repeater ID="DataList2" runat="server">
                        <ItemTemplate>
                            <article class="ft_publication type-ft_publication status-publish hentry">
                                <div class="entry-card flex flex-wrap border mb-6 bg-white">
                                    <div class="entry-card-cover mx-auto md:w-1/4">
                                        <div class="cover-inner md:mx-5 my-6">
                                            <a href="<%#CheckUrl(Eval("url", "{0}"), Eval("id", "{0}"))%>" title="<%#Eval("Title") %>" class="block p-2 border bg-white w-36">
                                                <img width="167" height="217" src="<%#Eval("Path") %>" alt="<%#Eval("Title") %>" class="object-cover h-48 w-full" loading="lazy" />
                                            </a>
                                        </div>
                                    </div>
                                    <div class="entry-card-content px-6 py-6 md:pl-0 w-full md:w-3/4">
                                        <div class="entry-meta text-sm text-gray-800 pb-2 md:text-right">
                                            <i class="fas fa-calendar md:ml-2 font-bold text-blue-600"></i>&nbsp;&nbsp;ÈÕÆÚ:
									<time class="text-gray-700"><%#Convert.ToDateTime(Eval("putdate")).ToString("yyyy-MM-dd")%> </time>
                                        </div>
                                        <h2 class="entry-title text-lg md:text-xl text-gray-800 font-bold pb-6 capitalize"><a href="<%#CheckUrl(Eval("url", "{0}"), Eval("id", "{0}"))%>" title="<%#Eval("Title") %>"><%#Eval("Title") %></a></h2>
                                        <h3 class="publication-title text-sm text-gray-800 pb-6"><%#Eval("Keycontent") %></h3>
                                    </div>
                                </div>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                </main>
            </asp:Panel>

            <asp:Panel ID="PicMoban" runat="server" Width="100%">
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
