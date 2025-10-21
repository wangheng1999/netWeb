<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

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
    <%--д╛хо--%>
    <link href="css/page.css" rel="stylesheet" type="text/css" />
    <link href="css/update.css" rel="stylesheet" type="text/css" />
</head>
<body class="archive post-type-archive post-type-archive-ft_download">
    <ucStart:Start ID="Start" runat="server" />
    <div class="page-wrapper container mx-auto px-8 flex flex-wrap bg-white">
        <div id="primary" class="content-area w-full lg:w-3/4 lg:pr-4 pt-12">
            <main id="main" class="site-main">
                    <div class="download-center">
                        <div class="download-cat w-full mb-16">
                            <div class="download-cat--name text-gray-800 text-2xl font-bold uppercase mb-4"><%=strColumnName %> </div>
    <!--Content Start-->
    <asp:Panel ID="DownLoadZidingyi" runat="server" Width="100%">
                            <div class="download-files flex flex-wrap -mx-2">
                                  <asp:Repeater ID="DataList2" runat="server">
                        <ItemTemplate>
                                <div class="download-file w-1/2 md:w-1/4 text-center pb-4">
                                    <div class="download-file__title text-sm text-gray-700 font-bold my-2"><%#Eval("title") %></div>
                                    <div class="download-file--cover mx-2">
                                        <img width="150" height="150" src="<%#Eval("Path") %>" alt="<%#Eval("title") %>" class="border p-2 bg-white mx-auto" loading="lazy" />
                                    </div>
                                    <div class="download-file--link mt-4"><a class="btn btn-small btn-blue rounded" href="<%#Eval("fujian") %>" target="_blank" >Download</a> </div>
                                </div>
                                   </ItemTemplate>
                    </asp:Repeater>
                            </div>
    </asp:Panel>
    <asp:Panel ID="DownLoadMoban" runat="server" Width="100%">
        <%=strhtml %>
    </asp:Panel>
    <div class="page_box" style="width: 100%; padding-top: 5px; padding-bottom: 8px;">
        <%=Basic.Engine.Get.PagiNation.GetPageHtml(intTotalCount, page)%>
    </div>
    <!--Content End-->
     </div>
                    </div>
                </main>
        </div>
        <ucLeftControl:LeftControl ID="LeftControl" runat="server" />
    </div>
    <ucEnd:End ID="End" runat="server" />
</body>
</html>
