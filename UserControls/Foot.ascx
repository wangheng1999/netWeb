<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Foot.ascx.cs" Inherits="Foot" %>
<%if (intQQ > 0)
  {%>
<link rel="stylesheet" type="text/css" href="css/kefu.css">
<div class="scrollsidebar" id="scrollsidebar">
    <div class="side_content">
        <div class="side_list">
            <div class="side_title">
                <div class="titlet">联系我们</div>
                <a title="隐藏" class="close_btn">
                    <span>关闭</span>
                </a>
            </div>
            <div class="side_center">
                <div class="custom_service">
                    <%for (int i = 0; i < intQQ; i++)
                      {
                          string qq = dstQQ.Tables[0].Rows[i]["qq"].ToString();
                    %>
                    <p>
                        <a title="点击这里给我发消息" href="http://wpa.qq.com/msgrd?v=3&uin=<%=qq %>&Site=qq&Menu=yes" target="_blank">
                            <img src="http://wpa.qq.com/pa?p=2:8983659:41"></a>
                    </p>
                    <%} %>
                </div>
                <div class="other">
                    <p>
                        <img src="<%=mc.SelectPicByClassID(7) %>" width="120" />
                    </p>
                    <p>客户服务热线</p>
                    <p><%=mc.ShowWebsiteKeyById(1,"Phone") %></p>
                </div>
                <div class="msgserver">
                    <p><a href="<%=ContactUrl %>">联系我们</a></p>
                </div>
            </div>
            <div class="side_bottom"></div>
        </div>
    </div>
    <div class="show_btn">
        <div class="show_title">
            <p style="color: white; line-height: 18px; font-size: 14px; text-align: center;">在线客服</p>
        </div>
        <span>在线客服</span>
    </div>
</div>
<script type="text/javascript" src="js/kefu.js"></script>
<%} %>

<!--<footer id="colophon" class="site-footer py-12 bg-gray-200 text-gray-800 text-sm border-t">
    <div class="container mx-auto px-4 overflow-hidden">
        <div class="flex flex-wrap md:-mx-4 justify-center">
            <div class="w-full md:w-1/2 xl:w-1/4 py-4 xl:py-0 md:px-4">
                <div class="title pb-4 text-xl uppercase font-bold"><%=mc.ShowColumnName(3) %></div>
                <p class="description leading-loose"><%=mc.ShowColumnKeyById(3,"Remarks") %> </p>
            </div>
            <div class="w-full md:w-1/2 xl:w-1/4 py-4 xl:py-0 md:px-4">
                <div class="title pb-4 text-xl uppercase font-bold">產品中心</div>
                <ul class="leading-loose">
                    <%for (int i = 0; i < intNews3; i++)
                      {
                          string Context = dtblNew3.Rows[i]["Context"].ToString();
                          string Id = dtblNew3.Rows[i]["Id"].ToString();
                          string Url = "Product.aspx?TypeID=" + Id;
                    %>
                    <li><i class="fas fa-angle-right mr-2 text-blue-600"></i><a href="<%=Url %>" class="hover:text-blue-600"><%=Context %></a></li>
                    <%} %>
                </ul>
            </div>
            <div class="w-full md:w-1/2 xl:w-1/4 py-4 xl:py-0 md:px-4">
                <div class="title pb-4 text-xl uppercase font-bold">導航</div>
                <div class="leading-loose">
                    <ul id="menu-footer-support-menu" class="menu">
                        <%for (int i = 0; i < intMenu; i++)
                          {
                              string ColumnName = dstMenu.Tables[0].Rows[i]["ColumnName"].ToString();
                              string ColumnUrlClient = dstMenu.Tables[0].Rows[i]["ColumnUrlClient"].ToString();
                        %>
                        <li class="menu-item"><i class="fas fa-angle-right mr-2 text-blue-600"></i><a href="<%=ColumnUrlClient %>" title="<%=ColumnName %>"><%=ColumnName %></a></li>
                        <%} %>
                    </ul>
                </div>
            </div>
            <div class="w-full md:w-1/2 xl:w-1/4 py-4 xl:py-0 md:px-4">
                <div class="title pb-4 text-xl uppercase font-bold">聯系我們</div>
                <div class="tel leading-loose"><i class="fas fa-phone mx-1 text-blue-600"></i>電話: <a href="tel:<%=strPhone %>"><%=strPhone %></a> </div>
                <div class="fax leading-loose"><i class="fas fa-fax mx-1 text-blue-600"></i>傳真: <a href="fax:<%=strFax %>"><%=strFax %> </a></div>
                <div class="email leading-loose"><i class="fas fa-envelope mx-1 text-blue-600"></i>郵箱: <a href="mailto:<%=strEmail %>"><%=strEmail %> </a></div>
                <!--<div class="font-bold py-4">Stay connected</div>
            </div>
        </div>
    </div>
</footer>-->
<footer class="site-footer-copyright bg-gray-200 text-gray-700 text-sm">
    <div class="container mx-auto p-4 border-t border-gray-500">
        <span style="font-family: Arial, Helvetica, sans-serif;">Copyright &copy; 2023 -<script type="text/javascript">var myDate = new Date(); document.write(myDate.getFullYear());</script>
        </span>
        <%=strCompanyName %>
        <%=strICP %>
        <%if (strStateManage == "1")
          {%>
        <a href="qzkeyadmin/login.aspx">管理入口</a>&nbsp;&nbsp;
            <%} %>
        <%if (strSupportState == "1")
          {%>
        <a href="<%=strWebSite %>" title="<%=strTitle %>" target="_blank"><%=strSupportName %></a>
        <%} %>
        <%if (strStateSitemap == "1")
          {%>
        <a href="/sitemap.xml" title="网站地图" target="_blank">网站地图</a>
        <%} %>
        <%if (strState == "1")
          {%>
        <object data="<%=strPath %>" type="application/x-mplayer2" width="0" height="0">
            <param name="src" value="<%=strPath %>" />
            <param name="autostart" value="1" />
            <param name="loop" value="-1" />
            <param name="playcount" value="infinite" />
        </object>
        <%} %>
        <%if (strCodeState == "1") { Response.Write(strContent); }%>
    </div>
</footer>
