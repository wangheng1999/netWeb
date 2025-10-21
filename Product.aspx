<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

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
    </style>
    <link href="css/update.css" rel="stylesheet" type="text/css" />
</head>
<body class="archive post-type-archive post-type-archive-ft_product">
    <ucStart:Start ID="Start" runat="server" />
    <div class="page-wrapper container mx-auto px-8 flex flex-wrap bg-white">
        <div id="primary" class="content-area w-full lg:w-3/4 lg:pr-4 py-12">
            <!--Content Start-->
            <asp:Panel ID="ProZidingyi" runat="server" Width="100%">
                <main id="main" class="site-main">
                    <%for (int i = 0; i < intNews; i++)
                      {
                          string _path = dsNews.Tables[0].Rows[i]["ProPath"].ToString();
                          string _title = dsNews.Tables[0].Rows[i]["ProName"].ToString();
                          string _id = dsNews.Tables[0].Rows[i]["ProId"].ToString();
                          string _url = "ProDetail.aspx?ProID=" + _id;

                          string ProBianhao = dsNews.Tables[0].Rows[i]["ProBianhao"].ToString();
                          string ProChandi = dsNews.Tables[0].Rows[i]["ProChandi"].ToString();
                          string ProPrice = dsNews.Tables[0].Rows[i]["ProPrice"].ToString();
                          string Keywords = dsNews.Tables[0].Rows[i]["Keywords"].ToString();
                          string ProKeyDescription = dsNews.Tables[0].Rows[i]["ProKeyDescription"].ToString();
                          string Keywords2 = dsNews.Tables[0].Rows[i]["Keywords2"].ToString();
                          string Keywords3 = dsNews.Tables[0].Rows[i]["Keywords3"].ToString();
                    %>
                    <article id="post-37914" class="post-37914 ft_product type-ft_product status-publish hentry product_species-rat ft_product_category-rat">
                        <div class="entry-card flex flex-wrap flex-col-reverse md:flex-row border mb-6 bg-white p-6">
                            <div class="entry-card-content w-full pt-6 md:pt-0 md:w-3/4">
                                <h2 class="entry-title text-lg font-bold pb-3"><a href="<%=_url%>" class="text-gray-700"><%=_title %> </a></h2>
                                <div class="excerpt text-sm leading-relaxed my-2">
                                    <dl class="flex flex-row flex-wrap">
                                        <%if (!string.IsNullOrEmpty(ProBianhao))
                                          { %>
                                        <dt class="w-1/2 md:w-1/4 capitalize text-gray-600 py-1"><i class="fas fa-tags mr-1"></i>Catalogue No. </dt>
                                        <dd class="w-1/2 md:w-1/4 p-1"><%=ProBianhao %></dd>
                                        <%} %>
                                        <%if (!string.IsNullOrEmpty(ProChandi))
                                          { %>
                                        <dt class="w-1/2 md:w-1/4 capitalize text-gray-600 py-1"><i class="fas fa-tags mr-1"></i>Reactivity </dt>
                                        <dd class="w-1/2 md:w-1/4 p-1"><%=ProChandi %></dd>
                                        <%} %>
                                        <%if (!string.IsNullOrEmpty(ProPrice))
                                          { %>
                                        <dt class="w-1/2 md:w-1/4 capitalize text-gray-600 py-1"><i class="fas fa-tags mr-1"></i>Range </dt>
                                        <dd class="w-1/2 md:w-1/4 p-1"><%=ProPrice %></dd>
                                         <%} %>
                                        <%if (!string.IsNullOrEmpty(Keywords))
                                          { %>
                                        <dt class="w-1/2 md:w-1/4 capitalize text-gray-600 py-1"><i class="fas fa-tags mr-1"></i>Sensitivity </dt>
                                        <dd class="w-1/2 md:w-1/4 p-1"><%=Keywords %></dd>
                                        <%} %>
                                        <%if (!string.IsNullOrEmpty(ProKeyDescription))
                                          { %>
                                        <dt class="w-1/2 md:w-1/4 capitalize text-gray-600 py-1"><i class="fas fa-tags mr-1"></i>Cas </dt>
                                        <dd class="w-1/2 md:w-1/4 p-1"><%=ProKeyDescription %></dd>
                                        <%} %>
                                        <%if (!string.IsNullOrEmpty(Keywords2))
                                          { %>
                                        <dt class="w-1/2 md:w-1/4 capitalize text-gray-600 py-1"><i class="fas fa-tags mr-1"></i>Linear Formula </dt>
                                        <dd class="w-1/2 md:w-1/4 p-1"><%=Keywords2 %></dd>
                                        <%} %>
                                        <%if (!string.IsNullOrEmpty(Keywords3))
                                          { %>
                                        <dt class="w-1/2 md:w-1/4 capitalize text-gray-600 py-1"><i class="fas fa-tags mr-1"></i>Molecular Weight </dt>
                                        <dd class="w-1/2 md:w-1/4 p-1"><%=Keywords3 %></dd>
                                        <%} %>
                                    </dl>
                                </div>
                            </div>
                            <div class="w-full md:w-1/4 md:flex-1 overflow-x-hidden">
                                <div class="border bg-white p-2">
                                    <img src="<%=_path %>" class="object-contain w-full h-64 md:h-40">
                                </div>
                            </div>
                        </div>
                    </article>
                    <%} %>
                </main>
            </asp:Panel>

            <asp:Panel ID="ProMoban" runat="server" Width="100%">
                <%=strhtml %>
            </asp:Panel>

            <div class="clear">
            </div>
            <div class="page_box" style="width: 100%; padding-top: 5px; padding-bottom: 8px;">
                <%=Basic.Engine.Get.PagiNation.GetPageHtml(intTotalCount, page)%>
            </div>
            <!--Content End-->
        </div>
        <!--<aside id="archive-ft_product-sidebar" class="sidebar widget-area w-full lg:w-1/4" role="complementary">
            <div class="h-full py-2 lg:py-12 lg:-mr-8 lg:px-4 bg-gray-100">
                <ucCategoryControl:CategoryControl ID="CategoryControl" runat="server" />
            </div>
        </aside>-->
    </div>
    <ucEnd:End ID="End" runat="server" />
</body>
</html>

