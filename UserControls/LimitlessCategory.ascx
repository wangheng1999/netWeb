<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LimitlessCategory.ascx.cs"
    Inherits="LimitlessCategory" %>
<%if (intLinks > 0)
  {
%>
<dd>
    ”—«È¡¥Ω”£∫
    <%for (int i = 0; i < intLinks; i++)
      {
          string title = dtLinks.Rows[i]["title"].ToString();
          string url = dtLinks.Rows[i]["url"].ToString();
    %>
    <a href="<%=url %>" target="_blank" title="<%=title %>">
        <%=title %></a>
    <%
        } %>
</dd>
<%}
%>