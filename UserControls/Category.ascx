<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Category.ascx.cs" Inherits="Category" %>

<section id="nav_menu-5" class="widget widget_nav_menu">
    <div class="menu-about-menu-container">
        <ul id="menu-about-menu" class="menu">
            <%for (int i = 0; i < intCount; i++)
              {
                  string Context = dst.Tables[0].Rows[i]["Context"].ToString();
                  string Id = dst.Tables[0].Rows[i]["Id"].ToString();
                  showContentSub(Int32.Parse(Id));
            %>
            <%if (intCountSub > 0)
              { %>
            <li class="menu-item menu-item-has-children"><a href="Product.aspx?TypeID=<%=Id %>" <%if (intTypeID == Int16.Parse(Id) || strParentId == Id)
                                                                                                  {%>style="color: #2b6cb0;"
                <%} %>><%=Context %></a>
                <ul class="sub-menu">
                    <%for (int j = 0; j < intCountSub; j++)
                      {
                          string Context2 = dstSub.Tables[0].Rows[j]["Context"].ToString();
                          string Id2 = dstSub.Tables[0].Rows[j]["Id"].ToString();
                    %>
                    <li class="menu-item menu-item-type-taxonomy menu-item-object-category"><a href="Product.aspx?TypeID=<%=Id2 %>" <%if (intTypeID == Int16.Parse(Id2))
                                                                                                                                      { %>style="color: #2b6cb0;"
                        <%} %>><%=Context2 %></a></li>
                    <%} %>
                </ul>
            </li>
            <%}
              else
              { %>
            <li class="menu-item"><a href="Product.aspx?TypeID=<%=Id %>"><%=Context %></a></li>
            <%} %>
            <%} %>
        </ul>
    </div>
</section>
