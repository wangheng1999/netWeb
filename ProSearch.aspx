<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProSearch.aspx.cs" Inherits="ProSearch" %>

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
    <script src="js/Zhishiying.js" type="text/javascript"></script>
    <style type="text/css">
        .img_list_301 ul li {
            float: left;
            border: #e4e4e4 solid 1px;
            display: inline;
            margin-bottom: 15px;
            margin-right: 15px;
            width: 150px;
            height: 180px;
            overflow: hidden;
        }

        .NewList {
            margin-top: 10px;
        }

        .clear {
            clear: both;
        }
    </style>
    <link href="css/update.css" rel="stylesheet" type="text/css" />
</head>
<body class="archive post-type-archive post-type-archive-ft_product">
    <ucStart:Start ID="Start" runat="server" />
    <div class="page-wrapper container mx-auto px-8 flex flex-wrap bg-white">
        <div id="primary" class="content-area w-full lg:w-3/4 lg:pr-4 py-12">
            <!--Content Start-->
            <script src="js/Search.js" type="text/javascript"></script>
            <div id="Search_Content">
            </div>
            <!--Content End-->
        </div>
        <aside id="archive-ft_product-sidebar" class="sidebar widget-area w-full lg:w-1/4" role="complementary">
            <div class="h-full py-2 lg:py-12 lg:-mr-8 lg:px-4 bg-gray-100">
                <ucCategoryControl:CategoryControl ID="CategoryControl" runat="server" />
            </div>
        </aside>
    </div>
    <ucEnd:End ID="End" runat="server" />
</body>
</html>

