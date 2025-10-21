<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Head.ascx.cs" Inherits="Head" %>
<script type="text/javascript" src="https://tyw.key.400301.com/js/replace_word_limit.js"></script>
<script type="text/javascript" src="js/lannew.js"></script>
<script type="text/javascript" language="javascript">
    //①搜索开始
    function checkSearch() {
        if ($("#KeyName").val() == "" || $("#KeyName").val() == null) {
            alert("请输入搜索关键词");
            $("#KeyName").val("");
            $("#KeyName").focus();
            return false;
        }
        var Search_url = $("#key-Search").attr("value");
        window.location.href = Search_url + "?q=" + escape($("#KeyName").val());
    }

    //②按下回车键出发某个按钮开始
    document.onkeydown = function (event) {
        e = event ? event : (window.event ? window.event : null);
        if (e.keyCode == 13) {
            document.getElementById("SearchButton").click();
            return false;
        }
    }
</script>
<!--④设置网站背景开始-->
<%=str_Bg%>

<header id="masthead" class="site-header w-full bg-white">
    <div class="site-header-top border-b text-gray-700">
        <div class="border-t border-b-2 border-blue-500"></div>
        <div class="container mx-auto px-4 py-2 flex justify-between">
            <div class="flex">
                <a href="mailto:<%=strEmail %>"><i class="fas fa-envelope mr-1"></i><span class="hover:underline text-xs uppercase"><%=strEmail %></span></a>
                <a href="tel:<%=strPhone %>"><i class="fas fa-phone ml-2 mr-1"></i><span class="hover:underline text-xs"><%=strPhone %></span></a>
            </div>
            <div class="flex">
                <ul class="social-brand hidden lg:flex">
                    <li><a href="#" class="social-twitter"><i class="fab fa-twitter"></i></a></li>
                    <li><a href="#" class="social-facebook"><i class="fab fa-facebook-f"></i></a></li>
                    <li><a href="#" class="social-qq"><i class="fab fa-qq"></i></a></li>
                    <li><a href="#" class="social-skype"><i class="fab fa-skype"></i></a></li>
                    <li><a href="#" class="social-linkedin"><i class="fab fa-linkedin"></i></a></li>
                </ul>

            </div>
        </div>
    </div>
    <div class="site-header-nav w-full bg-white z-50">
        <div class="container mx-auto px-4 py-2 lg:py-0 flex flex-wrap justify-between items-center relative">
            <div class="nav w-full md:w-auto lg:w-full xl:w-auto flex justify-center items-center md:justify-between xl:justify-start lg:relative xl:static my-2 md:my-0">
                <a href="<%=mc.SelectPicKeyByClassID(1,"Url") %>" class="navbar-brand inline-block">
                    <img class="h-16 md:h-12 xl:h-16" src="<%=mc.SelectPicByClassID(1) %>" alt="<%=mc.SelectPicKeyByClassID(1,"Beizhu") %>">
                </a>
                <nav class="navbar">
                    <div class="flex justify-between items-center mx-auto ml-6">
                        <div class="main-navigation hidden lg:block">
                            <ul id="menu-header-nav-menu" class="menu">
                                <%for (int i = 0; i < intMenu; i++)
                                  {
                                      string Id = dstMenu.Tables[0].Rows[i]["Id"].ToString();
                                      string ColumnUrlClient = dstMenu.Tables[0].Rows[i]["ColumnUrlClient"].ToString();
                                      string ColumnStaticPage = dstMenu.Tables[0].Rows[i]["ColumnStaticPage"].ToString();
                                      string StaticPage = dstMenu.Tables[0].Rows[i]["StaticPage"].ToString();
                                      string ColumnName = dstMenu.Tables[0].Rows[i]["ColumnName"].ToString();
                                      showMenuSub(Int32.Parse(Id));
                                      string sClass = "menu-item-has-children";
                                      if (intMenuSub == 0)
                                      {
                                          sClass = null;
                                      }
                                      string cClass = "";
                                      if (intClassID == Int16.Parse(Id) || strParentId == Id)
                                      {
                                          cClass = "color: #1f98f5;";
                                      }
                                      else if (Request.Url.ToString().ToLower().Contains("default.aspx") && ColumnUrlClient == "Default.aspx")
                                      {
                                          cClass = "color: #1f98f5;";
                                      }
                                      else if (Request.Url.ToString().ToLower().Contains("product.aspx") && ColumnUrlClient == "Product.aspx")
                                      {
                                          cClass = "color: #1f98f5;";
                                      }
                                      if (ColumnUrlClient.ToLower().Contains("product.aspx"))
                                      {
                                %>
                                <li class="menu-item menu-item-has-children megamenu">
                                    <a href="<%=returnUrl(ColumnUrlClient, ColumnStaticPage, StaticPage)%>" title="<%=ColumnName %>" style="<%=cClass %>"><%=ColumnName %></a>
                                    <ul class="sub-menu">
                                        <%   
                                          //显示产品分类
                                          for (int w = 0; w < intCount; w++)
                                          {
                                              string _Context = dst.Tables[0].Rows[w]["Context"].ToString();
                                              string _Id = dst.Tables[0].Rows[w]["Id"].ToString();
                                              string _Url = "Product.aspx?TypeID=" + _Id;
                                              showContentSub(Int32.Parse(_Id));
                                        %>
                                        <li class="menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children">
                                            <a href="<%=_Url %>" title="<%=_Context %>"><%=_Context %></a>
                                            <%if (intCountSub > 0)
                                              { %>
                                            <ul class="sub-menu">
                                                <%   
                                                  for (int j = 0; j < intCountSub; j++)
                                                  {
                                                      string Context2 = dstSub.Tables[0].Rows[j]["Context"].ToString();
                                                      string Id2 = dstSub.Tables[0].Rows[j]["Id"].ToString();
                                                      string Url2 = "Product.aspx?TypeID=" + Id2;
                                                %>
                                                <li class="menu-item menu-item-type-taxonomy menu-item-object-ft_product_category"><a href="<%=Url2 %>"><%=Context2 %></a></li>
                                                <%} %>
                                            </ul>
                                            <%} %>
                                        </li>
                                        <%} %>
                                    </ul>
                                </li>
                                <%}
                                      else
                                      { %>
                                <li class="menu-item <%=sClass%>">
                                    <a href="<%=returnUrl(ColumnUrlClient, ColumnStaticPage, StaticPage)%>" style="<%=cClass %>"><%=ColumnName%></a>
                                    <%if (intMenuSub > 0)
                                      { %>
                                    <ul class="sub-menu">
                                        <%for (int j = 0; j < intMenuSub; j++)
                                          {
                                              string ColumnUrlClient2 = dstMenuSub.Tables[0].Rows[j]["ColumnUrlClient"].ToString();
                                              string ColumnStaticPage2 = dstMenuSub.Tables[0].Rows[j]["ColumnStaticPage"].ToString();
                                              string StaticPage2 = dstMenuSub.Tables[0].Rows[j]["StaticPage"].ToString();
                                              string ColumnName2 = dstMenuSub.Tables[0].Rows[j]["ColumnName"].ToString();
                                        %>
                                        <li class="menu-item menu-item-type-taxonomy menu-item-object-ft_research_area"><a href="<%=returnUrl(ColumnUrlClient2, ColumnStaticPage2, StaticPage2)%>"><%=ColumnName2%></a> </li>
                                        <%} %>
                                    </ul>
                                    <% } %>
                                </li>
                                <%}
                                  } %>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
            <div class="w-full md:w-auto lg:w-full xl:w-auto lg:mb-4 xl:mb-0 flex flex-grow py-2 md:py-0">
                <div class="flex flex-row items-center justify-center w-full bg-white">
                    <div class="search-form w-full">
                        <div class="search-box border flex rounded bg-gray-100 p-1">
                            <div class="relative flex align-middle">
                                <select name="product_cat" class="appearance-none block bg-gray-100 pl-2 pr-8 py-1 text-gray-600 font-medium text-sm focus:outline-none focus:text-gray-800">
                                    <option value="">所有</option>
                                </select>
                                <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-600">
                                    <svg class="fill-current h-4 w-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20">
                                        <path d="M9.293 12.95l.707.707L15.657 8l-1.414-1.414L10 10.828 5.757 6.586 4.343 8z"></path>
                                    </svg>
                                </div>
                            </div>
                            <a href="ProSearch.aspx" style="display: none;" value="ProSearch.aspx" id="key-Search"></a>
                            <input type="search" id="KeyName" placeholder="請輸入" class="appearance-none text-sm text-gray-700 focus:outline-none border-l px-2 w-32 lg:w-auto flex-grow bg-gray-100" value="" />
                            <button class="flex-grow-0 block search-submit focus:outline-none px-2" type="button" id="SearchButton" onclick="checkSearch()"><i class="fas fa-search text-gray-600"></i><span class="hidden">搜索</span> </button>
                        </div>
                    </div>
                </div>
                <div class="main-navigation-md-switch focus:outline-none text-gray-600 hover:text-gray-900 ml-4 md:py-4 leading-none lg:hidden"><i class="fas fa-bars text-2xl"></i></div>
                <div class="main-navigation-md z-50">
                    <ul id="menu-header-nav-menu-1" class="menu">
                        <%for (int i = 0; i < intMenu; i++)
                          {
                              string Id = dstMenu.Tables[0].Rows[i]["Id"].ToString();
                              string ColumnUrlClient = dstMenu.Tables[0].Rows[i]["ColumnUrlClient"].ToString();
                              string ColumnStaticPage = dstMenu.Tables[0].Rows[i]["ColumnStaticPage"].ToString();
                              string StaticPage = dstMenu.Tables[0].Rows[i]["StaticPage"].ToString();
                              string ColumnName = dstMenu.Tables[0].Rows[i]["ColumnName"].ToString();
                              showMenuSub(Int32.Parse(Id));
                              string sClass = "menu-item-has-children";
                              if (intMenuSub == 0)
                              {
                                  sClass = null;
                              }
                              if (ColumnUrlClient.ToLower().Contains("product.aspx"))
                              {
                        %>
                        <li class="menu-item menu-item-has-children megamenu">
                            <a href="javascript:;">Products</a>
                            <ul class="sub-menu">
                                <%   
                                  //显示产品分类
                                  for (int w = 0; w < intCount; w++)
                                  {
                                      string _Context = dst.Tables[0].Rows[w]["Context"].ToString();
                                      string _Id = dst.Tables[0].Rows[w]["Id"].ToString();
                                      string _Url = "Product.aspx?TypeID=" + _Id;
                                      showContentSub(Int32.Parse(_Id));
                                %>
                                <li class="menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children">
                                    <a href="<%=_Url %>"><%=_Context %></a>
                                    <%if (intCountSub > 0)
                                      { %>
                                    <ul class="sub-menu">
                                        <%   
                                          for (int j = 0; j < intCountSub; j++)
                                          {
                                              string Context2 = dstSub.Tables[0].Rows[j]["Context"].ToString();
                                              string Id2 = dstSub.Tables[0].Rows[j]["Id"].ToString();
                                              string Url2 = "Product.aspx?TypeID=" + Id2;
                                        %>
                                        <li class="menu-item menu-item-type-taxonomy menu-item-object-ft_product_category"><a href="<%=Url2 %>"><%=Context2 %></a></li>
                                        <%} %>
                                    </ul>
                                    <%} %>
                                </li>
                                <%} %>
                            </ul>
                        </li>
                        <%}
                              else
                              { %>
                        <li class="menu-item <%=sClass %>">
                            <%if (intMenuSub > 0)
                              { %>
                            <a href="javascript:;"><%=ColumnName %></a>
                            <ul class="sub-menu">
                                <%for (int j = 0; j < intMenuSub; j++)
                                  {
                                      string ColumnUrlClient2 = dstMenuSub.Tables[0].Rows[j]["ColumnUrlClient"].ToString();
                                      string ColumnStaticPage2 = dstMenuSub.Tables[0].Rows[j]["ColumnStaticPage"].ToString();
                                      string StaticPage2 = dstMenuSub.Tables[0].Rows[j]["StaticPage"].ToString();
                                      string ColumnName2 = dstMenuSub.Tables[0].Rows[j]["ColumnName"].ToString();
                                %>
                                <li class="menu-item menu-item-type-taxonomy menu-item-object-ft_research_area"><a href="<%=returnUrl(ColumnUrlClient2, ColumnStaticPage2, StaticPage2) %>"><%=ColumnName2 %></a> </li>
                                <%} %>
                            </ul>
                            <%}
                              else
                              { %>
                            <a href="<%=returnUrl(ColumnUrlClient, ColumnStaticPage, StaticPage) %>"><%=ColumnName %></a>
                            <%} %>
                        </li>
                        <%}
                          }%>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</header>
