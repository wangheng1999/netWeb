<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Left.ascx.cs" Inherits="Left" %>
<%if (intColumnList == 0)
  {
%>
<aside id="archive-news-sidebar" class="sidebar widget-area w-full lg:w-1/4" role="complementary">
    <div class="h-full py-2 lg:py-12 lg:-mr-8 lg:px-4 bg-gray-100">
        <section id="nav_menu-5" class="widget widget_nav_menu">
            <div class="menu-about-menu-container">
                <ul id="menu-about-menu" class="menu">
                    <%   
      //显示产品分类
      for (int i = 0; i < intCount; i++)
      {
          string Context = dst.Tables[0].Rows[i]["Context"].ToString();
          string Id = dst.Tables[0].Rows[i]["Id"].ToString();
                    %>
                    <li class="menu-item"><a href="Product.aspx?TypeID=<%=Id %>" <%if (intTypeID == Int16.Parse(Id))
                                                                                   { %>style="color: #2b6cb0;"
                        <%} %>><%=Context %></a></li>
                    <%} %>
                </ul>
            </div>
        </section>
    </div>
</aside>
<%
  }
  else //显示二级分类
  {
%>
<aside id="archive-news-sidebar" class="sidebar widget-area w-full lg:w-1/4" role="complementary">
    <div class="h-full py-2 lg:py-12 lg:-mr-8 lg:px-4 bg-gray-100">
        <section id="nav_menu-5" class="widget widget_nav_menu">
            <div class="menu-about-menu-container">
                <ul id="menu-about-menu" class="menu">
                    <%for (int i = 0; i < intColumnList; i++)
                      {
                          string ColumnUrlClient = dsSubmenu.Tables[0].Rows[i]["ColumnUrlClient"].ToString();
                          string ColumnName = dsSubmenu.Tables[0].Rows[i]["ColumnName"].ToString();
                          string Id = dsSubmenu.Tables[0].Rows[i]["ID"].ToString();
                    %>
                    <li class="menu-item"><a href="<%=ColumnUrlClient %>" <%if (intClassID == Int16.Parse(Id))
                                                                            { %>style="color: #2b6cb0;" <%} %>><%=ColumnName %></a></li>
                    <%} %>
                </ul>
            </div>
        </section>
    </div>
</aside>
<%
  }
%>



