<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact2" %>

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
    <script src="js/jquery-1-7-2.js"></script>
    <%--默认--%>
    <style>
        .clear {
            clear: both;
        }
    </style>
    <link href="css/update.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/contact.js"></script>
</head>
<body class="page-template-default page page-id-23043">
    <ucStart:Start ID="Start" runat="server" />
    <!--Content Start-->
    <asp:Panel ID="ContactZidingyi" runat="server" Width="100%">
        <div class="contact-us-wrapper">
            <div class="container mx-auto px-4 md:px-8 py-8 lg:py-12 bg-white">
                <div class="flex flex-wrap -mx-4 text-sm text-gray-800">
                    <div class="w-full lg:w-1/2 px-4">
                        <div role="form" class="wpcf7" id="wpcf7-f23040-o1" lang="en-US" dir="ltr">
                            <div class="screen-reader-response">
                                <p role="status" aria-live="polite" aria-atomic="true"></p>
                                <ul>
                                </ul>
                            </div>
                            <div class="wpcf7-form init">
                                <div class="mb-6">
                                    <span class="font-semibold mb-4">You are:</span>
                                    <span class="wpcf7-form-control-wrap your-type">
                                        <span class="wpcf7-form-control wpcf7-radio">
                                            <span class="wpcf7-list-item first">
                                                <input type="radio" name="your-type" value="Distributor" checked="checked" />
                                                <span class="wpcf7-list-item-label">Distributor</span>
                                            </span>
                                            <span class="wpcf7-list-item last">
                                                <input type="radio" name="your-type" value="End User" />
                                                <span class="wpcf7-list-item-label">End User</span>
                                            </span>
                                        </span>
                                    </span>
                                </div>
                                <div class="mb-6">
                                    <span class="block font-semibold mb-4">Full Name:</span>
                                    <span class="wpcf7-form-control-wrap your-name">
                                        <input type="text" name="your-name" id="name" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" aria-required="true" aria-invalid="false" />
                                    </span>
                                </div>
                                <div class="mb-6">
                                    <span class="block font-semibold mb-4">Email:</span>
                                    <span class="wpcf7-form-control-wrap your-email">
                                        <input type="email" name="your-email" id="email" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email" aria-required="true" aria-invalid="false" />
                                    </span>
                                </div>
                                <div class="mb-6">
                                    <span class="block md:inline-block font-semibold">To:</span>
                                    <span class="wpcf7-form-control-wrap your-subject">
                                        <span class="wpcf7-form-control wpcf7-radio">
                                            <span class="wpcf7-list-item first">
                                                <input type="radio" name="your-subject" value="Sales" checked="checked" />
                                                <span class="wpcf7-list-item-label">Sales</span>
                                            </span>
                                            <span class="wpcf7-list-item">
                                                <input type="radio" name="your-subject" value="Tech Support" />
                                                <span class="wpcf7-list-item-label">Tech Support</span>
                                            </span>
                                            <span class="wpcf7-list-item">
                                                <input type="radio" name="your-subject" value="After-sales" />
                                                <span class="wpcf7-list-item-label">After-sales</span>
                                            </span>
                                            <span class="wpcf7-list-item last">
                                                <input type="radio" name="your-subject" value="Promotion" />
                                                <span class="wpcf7-list-item-label">Promotion</span>
                                            </span>
                                        </span>
                                    </span>
                                </div>
                                <div class="mb-6">
                                    <span class="block font-semibold mb-4">Messages:</span>
                                    <textarea name="your-message" id="content1" cols="40" rows="10" class="wpcf7-textarea"></textarea>
                                </div>
                                <p>
                                    <input type="submit" value="Send" id="Button1" onclick="Submit()" class="wpcf7-form-control wpcf7-submit" />
                                </p>
                                <div class="wpcf7-response-output" aria-hidden="true"></div>
                            </div>
                            <script>
                                function Submit() {

                                    var type = $("input[name='your-type']:checked").val();
                                    if (type == undefined) { alert("请选择类型!"); return false; }

                                    var name = $("#name").val();
                                    if (name == "") { alert("请输入您的姓名！"); $("#name").focus(); return false; }

                                    var email = $("#email").val();
                                    if (email == "") { alert("请输入邮箱！"); $("#email").focus(); return false; }

                                    var subject = $("input[name='your-subject']:checked").val();
                                    if (subject == undefined) { alert("请选择产品!"); return false; }

                                    var content = $("#content1").val();
                                    if (content == "") { alert("请输入留言！"); $("#content1").focus(); return false; }

                                    //防止用户多次点击
                                    document.getElementById('Button1').disabled = true;
                                    document.getElementById('Button1').value = "Submit...";
                                    //提交信息开始
                                    $.ajax({
                                        type: "get",
                                        url: "Check/CheckSubmit.aspx?All=" + escape("类型：" + type + "，姓名：" + name + "，邮箱：" + email + " ，主题： " + subject + "，留言：" + content),
                                        success: function (msg) {
                                            if (msg == "success") {
                                                document.getElementById('Button1').value = "Send";
                                                alert("恭喜你，资料提交成功！");
                                                location.reload();
                                            }
                                            else {
                                                document.getElementById('Button1').value = "Send";
                                                document.getElementById('Button1').disabled = false;
                                                alert("含非法字符，资料提交失败！");
                                            }
                                        }
                                    });
                                    //提交信息结束
                                }
                            </script>
                        </div>
                    </div>
                    <div class="w-full lg:w-1/2 px-4 pt-6 lg:pt-0 leading-loose">
                        <a href="<%=mc.SelectPicKeyByClassID(1,"Url") %>" class="block items-center block pb-4">
                            <img class="h-24" src="<%=mc.SelectPicByClassID(1) %>" alt="<%=mc.SelectPicKeyByClassID(1,"Beizhu") %>">
                        </a>
                        <div class="text-2xl py-2 font-bold"><%=strCompanyName %> </div>
                        <div class="py-2 mb-2"><%=strAddress1 %> </div>
                        <div class="tel"><i class="fas fa-phone mx-1"></i>Tel: <a href="tel:<%=strPhone1 %>"><%=strPhone1 %></a> </div>
                        <div class="fax"><i class="fas fa-fax mx-1"></i>Fax: <a href="fax:<%=strFax1 %>"><%=strFax1 %> </a></div>
                        <div class="email"><i class="fas fa-envelope mx-1"></i>Email: <a href="mailto:<%=strEmail1 %>"><%=strEmail1 %> </a></div>
                        <div class="website"><i class="fas fa-link mx-1"></i>Web: <%=strWebUrl1 %></div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="ContactMoban" runat="server" Width="100%">
        <div class="contact-us-wrapper">
            <div class="container mx-auto px-4 md:px-8 py-8 lg:py-12 bg-white">
                <%=strhtml %>
            </div>
        </div>
    </asp:Panel>
    <!--Content End-->
    <ucEnd:End ID="End" runat="server" />
</body>
</html>
