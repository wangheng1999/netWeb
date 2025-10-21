<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tishi.aspx.cs" ValidateRequest="false"
    Inherits="Tishi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>网站关闭提示</title>
    <style type="text/css">
        body, p, div, a, span, strong, ul, li, dl, dt, dd, img, h1, h2, h3, h4
        {
            margin: 0;
            padding: 0;
        }
        body
        {
            font-family: 宋体;
            font-size: 12px;
            color: #000;
        }
        img
        {
            border: none;
            list-style: none;
        }
        a
        {
            color: #333;
            text-decoration: none;
        }
        a:hover
        {
            color: #F00;
        }
        ul, li, dl, dt, dd
        {
            list-style: none;
        }
        h1, h2, h3, h4
        {
            font-size: 12px;
        }
        .clear
        {
            margin: 0;
            padding: 0;
            clear: both;
        }
        .content
        {
            background: #FFF;
            margin: 50px auto;
            width: 700px;
        }
        .content_left
        {
            width: 136px;
            margin: 60px 14px 0 0px;
        }
        .content_right
        {
            margin-left: 8px;
        }
        .title
        {
            height: 39px;
        }
        .xinxi ul
        {
            padding: 1px 0 1px 6px;
        }
        .xinxi ul li
        {
            line-height: 20px;
            padding: 6px 0px;
            font-family: "Arial";
            font-size: 14px;
        }
        .xinxi ul li span
        {
            line-height: 12px;
            font-family: "Arial";
            font-size: 13px;
        }
        .xinxi ul li strong
        {
            font-size: 12px;
            font-weight: normal;
        }
        .xinxi ul li b
        {
            font-family: 微软雅黑;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="35%" style="text-align: right; padding-right: 20px;" valign="middle">
                    <img src="images/apple.jpg" alt="" />
                </td>
                <td width="65%">
                    <div class="content_right">
                        <div class="title">
                            <img src="images/xinxi.jpg" alt="网站已关闭" /></div>
                        <div class="xinxi">
                            <ul>
                                <%=strMessage %>
                            </ul>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

