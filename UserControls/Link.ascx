<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Link.ascx.cs" Inherits="Link" %>
<%if (string.IsNullOrEmpty(Path))
  { 
%>
<header class="page-title py-8 bg-white bg-cover border" style="background-image: url(<%=mc.SelectPicByClassID(5) %>);">
<%
    }
  else
  {
%>
<header class="page-title py-8 bg-white bg-cover border" style="background-image: url(<%=Path %>);">
<%
    } %>
