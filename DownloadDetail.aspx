<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadDetail.aspx.cs" Inherits="DownloadDetail" %>

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
    <style type="text/css">
        .dpic {
            background: #f3f5f7;
            text-align: center;
        }

            .dpic img {
                max-width: 300px;
                max-height: 300px;
                width: expression(this.width >300 && this.height < this.width ? 300: true);
                height: expression(this.height > 300 ? 300: true);
            }

        .xiangxi {
            margin-top: 20px;
        }

            .xiangxi h2 {
                height: 28px;
                font-size: 12px;
                line-height: 28px;
                color: #005895;
                border-bottom: #ddd solid 2px;
            }

                .xiangxi h2 strong {
                    float: left;
                    display: block;
                    border-bottom: #005895 solid 2px;
                    height: 28px;
                    padding: 0 0px;
                }
    </style>
</head>
<body>
    <form id="form1">
        <ucStart:Start ID="Start" runat="server" />
        <!--Content Start-->
        <table width="100%" align="center" cellspacing="10" cellpadding="0" border="0">
            <tr>
                <td align="center" style="font-size: 14px; font-weight: bold; border-top: #ddd dashed 1px; padding-top: 5px;"
                    colspan="2">
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" style="border-bottom: #ddd dashed 1px; padding-bottom: 5px;" colspan="2">发表时间：<asp:Label ID="lblPutdate" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                            阅读次数：<script language="javascript" src="/check/news_view.aspx?id=<%=intID %>"></script>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <table>
                        <tr>
                            <td>
                                <div style="width: 320px; height: 320px;" class="dpic">
                                    <table width="100%" border="0" cellspacing="5" cellpadding="0" style="width: 320px; text-align: center;">
                                        <tr>
                                            <td style="height: 320px;">
                                                <img src="/<%=strNewsPath %>" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td style="padding: 30px;">
                                <a onclick="javascript:window.open('/<%=strNewsFujian %>', '_blank');" style="cursor: pointer;">
                                    <img src="/Upload/down.jpg" /></a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="xiangxi">
            <h2>
                <strong>详细介绍</strong></h2>
            <div class="xiangxi_con">
                <asp:Label ID="lblContent" runat="server"></asp:Label>
            </div>
        </div>
        <!--Content end-->
        <ucEnd:End ID="End" runat="server" />
    </form>
</body>
</html>

