<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Check_Search" %>

<%if (intNews == 0)
  {
%>
<p style="text-align: center;">
    暂无记录...
</p>
<%
  }%>
<asp:panel id="ProZidingyi" runat="server" width="100%">
       <%=strhtml %>
       </asp:panel>

<asp:panel id="ProMoban" runat="server" width="100%">
        <%=strhtml %>
        </asp:panel>

<div class="clear">
</div>

<div class="page_box" style="width: 100%; padding-top: 5px; padding-bottom: 8px;">
    <%if (IsIndex)
      {
          //静态下分页链接替换
          string PageCon = Basic.Engine.Get.PagiNation.GetPageHtml(intTotalCount, page);
          PageCon = PageCon.ToLower().Replace("&page=null", null);
          PageCon = PageCon.ToLower().Replace("check/search.aspx?keyname=", "html/search/?q=");
          Response.Write(PageCon);
      }
      else
      {
          string PageCon = Basic.Engine.Get.PagiNation.GetPageHtml(intTotalCount, page);
          PageCon = PageCon.ToLower().Replace("&page=null", null);
          PageCon = PageCon.ToLower().Replace("check/search.aspx?keyname=", "ProSearch.aspx?q=");
          Response.Write(PageCon);
      } %>
</div>

