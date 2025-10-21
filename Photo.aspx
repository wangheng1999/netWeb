<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Photo.aspx.cs" Inherits="Photo" %>

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
    <!--默认-->
    <link href="css/page.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.lightbox-0.5.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#gallery a').lightBox();
        });
    </script>
    <!--相册效果结束-->
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
    </style>
</head>
<body>
    <form id="form1">
        <ucStart:Start ID="Start" runat="server" />
        <!--Content Start-->
        <div class="NewList img_list_301">
            <ul id="gallery">
                <asp:Repeater ID="DataList2" runat="server">
                    <ItemTemplate>
                        <li>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center" class="show_img">
                                        <a href="/<%#Eval("path") %>" title="<%#Eval("title") %>">
                                            <img src="/<%#Eval("path") %>" style="display: block;" alt="<%#Eval("title")%>"></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 30px; line-height: 30px;" class="show_img_title">
                                        <a href="/<%#Eval("path") %>" title="<%#Eval("title") %>">
                                            <%#Eval("Title")%></a>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
            <div class="page_box" style="width: 100%; padding-top: 5px; padding-bottom: 8px;">
                <%=Basic.Engine.Get.PagiNation.GetPageHtml(intTotalCount, page)%>
            </div>
        </div>
        <!--Content End-->
        <ucEnd:End ID="End" runat="server" />
    </form>
</body>
</html>

