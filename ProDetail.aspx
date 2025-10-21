<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProDetail.aspx.cs" Inherits="ProDetail" %>

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
    <link href="css/update.css" rel="stylesheet" type="text/css" />
    <!--jquery库-->
    <!--滚动、切换插件-->
    <script type="text/javascript" src="js/jQuery.blockUI.js"></script>
    <script type="text/javascript" src="js/jquery.SuperSlide.js"></script>
    <link href="css/swiper-bundle.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/swiper-bundle.min.js"></script>
    <style>
        .proDetail2 {
            margin-top: 10px;
        }

            .proDetail2 table {
                border-collapse: collapse;
                border: 1px solid #ccc;
            }

                .proDetail2 table th {
                    background: #e2e8f0;
                    text-align: center;
                    font-weight: bold;
                    font-size: 14px;
                    line-height: 1.5em;
                    padding: 5px 10px;
                    border: 1px solid #ccc;
                }

                .proDetail2 table td {
                    text-align: center;
                    font-size: 14px;
                    line-height: 1.5em;
                    padding: 10px 10px;
                    border: 1px solid #ccc;
                }
    </style>
</head>
<body class="ft_product-template-default single single-ft_product postid-37884">
    <ucStart:Start ID="Start" runat="server" />
    <div class="page-wrapper container mx-auto px-8 flex flex-wrap bg-white">
        <div id="primary" class="content-area w-full py-4 lg:w-3/4 lg:pr-4 lg:py-12">
            <!--Content Start-->
            <asp:Panel ID="ProZidingyi" runat="server" Width="100%">
                <main id="main" class="site-main">
                        <article id="post-37884" class="post-37884 ft_product type-ft_product status-publish hentry product_host-rabbit product_clonality-polyclonal product_reactivity-mouse product_tested_application-elisa product_tested_application-ihc product_tested_application-wb ft_product_category-primary-antibody">
                            <header class="entry-header pb-6 font-title">
                                <h1 class="entry-title"><%=strProName %> </h1>
                            </header>
                            <div class="entry-details">
                                <div class="w-full">
                                    <div class="product-minicard flex flex-wrap">
                                        <div class="w-full md:w-2/5 md:flex-1 overflow-x-hidden">
                                            <div class="border bg-white p-2 shadow-md">
                                                <div class="overflow-hidden">
                                                    <div class="entry-card-thumbnails swiper-style relative">
                                                        <div class="swiper-wrapper">
                                                            <%for (int i = 0; i < ConImg.Length; i++)
                                                              {%>
                                                            <div class="swiper-slide w-full bg-gray-900">
                                                                <img src="<%=ConImg[i] %>" class="object-cover h-64 w-full" />
                                                            </div>
                                                            <%} %>
                                                        </div>
                                                        <div class="swiper-button-prev"><span class="fas fa-angle-left"></span></div>
                                                        <div class="swiper-button-next"><span class="fas fa-angle-right"></span></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="w-full md:w-3/5 py-4 md:pl-8 md:py-0 flex flex-col">
                                            <div class="w-full text-2xl text-gray-800"><%=strProBianhao %> <span class="text-xs text-gray-600">型号</span> </div>
                                            <div class="flex-1 py-4 text-sm leading-relaxed align-baseline">
                                                <dl class="flex flex-row flex-wrap">
                                                    <%if (!string.IsNullOrEmpty(strProChandi))
                                                      { %>
                                                    <dt class="w-1/3 capitalize text-gray-600 py-1"><i class="fas fa-tags"></i>Reactivity </dt>
                                                    <dd class="w-2/3 p-1"><%=strProChandi %></dd>
                                                    <%} %>
                                                    <%if (!string.IsNullOrEmpty(strProPrice))
                                                      { %>
                                                    <dt class="w-1/3 capitalize text-gray-600 py-1"><i class="fas fa-tags"></i>Range </dt>
                                                    <dd class="w-2/3 p-1"><%=strProPrice %></dd>
                                                    <%} %>
                                                    <%if (!string.IsNullOrEmpty(strKeywords))
                                                      { %>
                                                    <dt class="w-1/3 capitalize text-gray-600 py-1"><i class="fas fa-tags"></i>Sensitivity </dt>
                                                    <dd class="w-2/3 p-1"><%=strKeywords %></dd>
                                                    <%} %>
                                                    <%if (!string.IsNullOrEmpty(strProKeyDescription))
                                                      { %>
                                                    <dt class="w-1/3 capitalize text-gray-600 py-1"><i class="fas fa-tags"></i>Cas </dt>
                                                    <dd class="w-2/3 p-1"><%=strProKeyDescription %></dd>
                                                    <%} %>
                                                    <%if (!string.IsNullOrEmpty(strKeywords2))
                                                      { %>
                                                    <dt class="w-1/3 capitalize text-gray-600 py-1"><i class="fas fa-tags"></i>Linear Formula </dt>
                                                    <dd class="w-2/3 p-1"><%=strKeywords2 %></dd>
                                                    <%} %>
                                                    <%if (!string.IsNullOrEmpty(strKeywords3))
                                                      { %>
                                                    <dt class="w-1/3 capitalize text-gray-600 py-1"><i class="fas fa-tags"></i>Molecular weight </dt>
                                                    <dd class="w-2/3 p-1"><%=strKeywords3 %></dd>
                                                     <%} %>
                                                </dl>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="proDetail2">
                                    <%=content1 %>
                                </div>

                                <div class="product-tab-slider w-full mt-6">
                                    <div class="product-tab-slider--nav pb-2 text-sm">
                                        <ul class="product-tab-slider--tabs flex flex-wrap justify-center">
                                            <li class="product-tab-slider--trigger mr-4 active" rel="specifications"><a class="border-b-2 border-gray-500 text-gray-500 hover:border-indigo-500 hover:text-indigo-500 py-2">詳情介紹 </a></li>
                                            <!--<li class="product-tab-slider--trigger mr-4" rel="faqs"><a class="border-b-2 border-gray-500 text-gray-500 hover:border-indigo-500 hover:text-indigo-500 py-2">FAQs </a></li>-->
                                        </ul>
                                    </div>
                                    <div class="product-tab-slider--container">
                                        <div id="specifications" class="product-tab-slider--body">
                                            <%=strProDescription %>
                                        </div>
                                        <div id="faqs" class="product-tab-slider--body">
                                            <div class="border my-4 bg-white p-4">
                                                <%=content2 %>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <footer class="entry-footer my-2"></footer>
                        </article>
                    </main>
            </asp:Panel>

            <asp:Panel ID="ProMoban1" runat="server" Width="100%">
                <div class="update_prodetail_1">
                    <div class="update_prodetail_1_top">
                        <div class="swiper-container gallery-top update_gallery-top1">
                            <div class="swiper-wrapper">
                                <%for (int i = 0; i < ConImg.Length; i++)
                                  {%>
                                <div class="swiper-slide">
                                    <img src="<%=ConImg[i] %>">
                                </div>
                                <%} %>
                            </div>
                            <!-- Add Arrows -->
                            <div class="swiper-button-next swiper-button-white"></div>
                            <div class="swiper-button-prev swiper-button-white"></div>
                        </div>
                        <div class="swiper-container gallery-thumbs  update_gallery-thumbs1">
                            <div class="swiper-wrapper">
                                <%for (int i = 0; i < ConImg.Length; i++)
                                  {%>
                                <div class="swiper-slide">
                                    <img src="<%=ConImg[i] %>">
                                </div>
                                <%} %>
                            </div>
                        </div>
                        <script>
                            var galleryThumbs = new Swiper('.update_gallery-thumbs1', {
                                spaceBetween: 10,
                                slidesPerView: 4,
                                freeMode: true,
                                loopedSlides: 5, //looped slides should be the same
                                watchSlidesVisibility: true,
                                watchSlidesProgress: true,
                            });
                            var galleryTop = new Swiper('.update_gallery-top1', {
                                spaceBetween: 10,
                                loop: true,
                                loopedSlides: 5, //looped slides should be the same
                                navigation: {
                                    nextEl: '.swiper-button-next',
                                    prevEl: '.swiper-button-prev',
                                },
                                thumbs: {
                                    swiper: galleryThumbs,
                                },
                            });
                        </script>

                    </div>
                    <div class="update_prodetail_1_con">
                        <div class="update_slideTxtBox_02">
                            <div class="hd">
                                <ul>
                                    <li>详细资料</li>
                                    <li>规格参数</li>
                                    <li>包装</li>
                                </ul>
                            </div>
                            <div class="bd">
                                <div class="xiangqing"><%=strProDescription %></div>
                                <div class="xiangqing"><%=content1 %></div>
                                <div class="xiangqing"><%=content2 %></div>
                            </div>
                        </div>
                        <script type="text/javascript">jQuery(".update_slideTxtBox_02").slide({ trigger: "click" });</script>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="ProMoban2" runat="server" Width="100%">
                <div class="update_prodetail_2">
                    <div class="update_prodetail_2_top">
                        <div class="update_prodetail_1_top_left">
                            <div class="swiper-container gallery-top update_gallery-top2">
                                <div class="swiper-wrapper">
                                    <%for (int i = 0; i < ConImg.Length; i++)
                                      {%>
                                    <div class="swiper-slide">
                                        <img src="<%=ConImg[i] %>">
                                    </div>
                                    <%} %>
                                </div>
                                <!-- Add Arrows -->
                                <div class="swiper-button-next swiper-button-white"></div>
                                <div class="swiper-button-prev swiper-button-white"></div>
                            </div>
                            <div class="swiper-container gallery-thumbs update_gallery-thumbs2">
                                <div class="swiper-wrapper">
                                    <%for (int i = 0; i < ConImg.Length; i++)
                                      {%>
                                    <div class="swiper-slide">
                                        <img src="<%=ConImg[i] %>">
                                    </div>
                                    <%} %>
                                </div>
                            </div>
                            <script>
                                var galleryThumbs = new Swiper('.update_gallery-thumbs2', {
                                    spaceBetween: 10,
                                    slidesPerView: 4,
                                    freeMode: true,
                                    loopedSlides: 5, //looped slides should be the same
                                    watchSlidesVisibility: true,
                                    watchSlidesProgress: true,
                                });
                                var galleryTop = new Swiper('.update_gallery-top2', {
                                    spaceBetween: 10,
                                    loop: true,
                                    loopedSlides: 5, //looped slides should be the same
                                    navigation: {
                                        nextEl: '.swiper-button-next',
                                        prevEl: '.swiper-button-prev',
                                    },
                                    thumbs: {
                                        swiper: galleryThumbs,
                                    },
                                });
                            </script>
                        </div>
                        <div class="update_prodetail_1_top_right">
                            <dl>
                                <dt><%=strProName %></dt>
                                <dd>产品型号：<%=strProBianhao %></dd>
                                <dd>产品产地：<%=strProChandi %></dd>
                                <dd>发布日期：<%=strPutdate %></dd>
                                <dd>浏览次数：<script language="javascript" src="/check/pro_view.aspx?proid=<%=intID %>"></script>次</dd>
                            </dl>
                            <div class="update_detail_bot"><a class="prev" href="<%=strPreviousUrl %>">上一个：<%=strPrevious %></a><a class="next" href="<%=strNextUrl %>">下一个：<%=strNext %></a></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="update_prodetail_2_con">
                        <div class="update_slideTxtBox_03">
                            <div class="hd">
                                <ul>
                                    <li>详细资料</li>
                                    <li>规格参数</li>
                                    <li>包装</li>
                                </ul>
                            </div>
                            <div class="bd">
                                <div class="xiangqing"><%=strProDescription %></div>
                                <div class="xiangqing"><%=content1 %></div>
                                <div class="xiangqing"><%=content2 %></div>
                            </div>
                        </div>
                        <script type="text/javascript">jQuery(".update_slideTxtBox_03").slide({ trigger: "click" });</script>
                        <div class="clear"></div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="ProMoban3" runat="server" Width="100%">
                <div class="update_prodetail_3">
                    <div class="update_prodetail_3_top">
                        <div class="update_prodetail_3_top_left">
                            <div class="swiper-container update_swiper-container">
                                <div class="swiper-wrapper">
                                    <%for (int i = 0; i < ConImg.Length; i++)
                                      {%>
                                    <div class="swiper-slide">
                                        <img src="<%=ConImg[i] %>">
                                    </div>
                                    <%} %>
                                </div>
                                <!-- Add Pagination -->
                                <div class="swiper-pagination"></div>
                                <!-- Add Arrows -->
                                <div class="swiper-button-next"></div>
                                <div class="swiper-button-prev"></div>
                            </div>

                            <!-- Initialize Swiper -->
                            <script>
                                var swiper = new Swiper('.update_swiper-container', {
                                    pagination: {
                                        el: '.swiper-pagination',
                                        type: 'fraction',
                                    },
                                    navigation: {
                                        nextEl: '.swiper-button-next',
                                        prevEl: '.swiper-button-prev',
                                    },
                                });
                            </script>
                        </div>
                        <div class="update_prodetail_3_top_right">
                            <dl>
                                <dt><%=strProName%></dt>
                                <dd class="update_prodetail_3_jj"><%=strProKeyDescription %></dd>
                                <dd class="update_prodetail_3_tel"><strong>全国热线<br />
                                    <%=strPhone %></strong><a href="tencent://message/?uin=<%=strQQ %>&Site=Sambow&Menu=yes">在线咨询</a></dd>
                            </dl>
                            <div class="update_detail_bot"><a class="prev" href="<%=strPreviousUrl %>">上一个：<%=strPrevious %></a><a class="next" href="<%=strNextUrl %>">下一个：<%=strNext %></a></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="update_prodetail_3_con">
                        <div class="update_prodetail_3_nr">
                            <h2><span>详细资料</span></h2>
                            <div class="update_prodetail_3_desc"><%=strProDescription %></div>
                        </div>
                        <div class="update_prodetail_3_nr">
                            <h2><span>规格参数</span></h2>
                            <div class="update_prodetail_3_desc"><%=content1 %></div>
                        </div>
                        <div class="update_prodetail_3_nr">
                            <h2><span>包装</span></h2>
                            <div class="update_prodetail_3_desc"><%=content2 %></div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <!--Content End-->
        </div>

        <aside id="archive-ft_product-sidebar" class="sidebar widget-area w-full lg:w-1/4" role="complementary">
            <div class="h-full py-2 lg:py-12 lg:-mr-8 lg:px-4 bg-gray-100">
                <ucCategoryControl:CategoryControl ID="CategoryControl" runat="server" />
                <section id="products_list_widget-2" class="widget widget_product_list">
                    <h2 class="widget-title">相關產品</h2>
                    <ul class="product_list__default">
                        <%for (int i = 0; i < intPro; i++)
                          {
                              string ProName = dtPro.Rows[i]["ProName"].ToString();
                              string ProBianhao = dtPro.Rows[i]["ProBianhao"].ToString();
                              string ProChandi = dtPro.Rows[i]["ProChandi"].ToString();
                              string ProPrice = dtPro.Rows[i]["ProPrice"].ToString();
                              string Keywords = dtPro.Rows[i]["Keywords"].ToString();
                              string ProId = dtPro.Rows[i]["ProId"].ToString();
                              string ProPath = dtPro.Rows[i]["ProPath"].ToString();
                              string Url = "ProDetail.aspx?Proid=" + ProId;
                        %>
                        <li><a href="<%=Url %>"><%=ProName %> </a></li>
                        <%} %>
                    </ul>
                </section>
            </div>
        </aside>
    </div>
    <ucEnd:End ID="End" runat="server" />
</body>
</html>

