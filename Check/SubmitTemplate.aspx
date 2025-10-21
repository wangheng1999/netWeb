<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitTemplate.aspx.cs" Inherits="SubmitTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="js/jquery-1-7-2.js"></script>
    <script type="text/javascript" charset="gb2312">
        function checkContent() {
            //姓名
            var strName = document.getElementById("txtName").value;
            if (strName == "") { alert("请输入姓名"); document.getElementById("txtName").focus(); return false; }
            //身份证号
            var strIDCard = document.getElementById("txtIDCard").value;
            if (strIDCard == "") { alert("请输入身份证号码"); document.getElementById("txtIDCard").focus(); return false; }
            else {
                var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
                if (reg.test(strIDCard) == false) {
                    alert("身份证号码不合法");
                    document.getElementById("txtIDCard").focus();
                    return false;
                }
            }
            //性别
            var sexID = document.getElementById("Sex");
            var Sex = sexID.options[sexID.selectedIndex].value;
            if (Sex == "请选择") { alert("请选择性别"); document.getElementById("Sex").focus(); return false; }
            //手机号码
            var strPhone = document.getElementById("txtPhone").value;
            if (strPhone == "") { alert("请输入手机号码"); document.getElementById("txtPhone").focus(); return false; }
            else if (!(/^13\d{9}$/g.test(strPhone)) && !(/^15\d{9}$/g.test(strPhone)) && !(/^18\d{9}$/g.test(strPhone))) {
                alert("手机号码格式不对"); document.getElementById("txtPhone").focus(); return false;
            }
            //QQ
            var strQQ = document.getElementById("txtQQ").value;
            if (strQQ == "") { alert("请输入QQ"); document.getElementById("txtQQ").focus(); return false; }
            else if (!(/^\d{5,10}$/.test(strQQ))) {
                alert("QQ号码格式不对"); document.getElementById("txtQQ").focus(); return false;
            }
            //所在省市
            var strProvinceAndCity = document.getElementById("txtProvinceAndCity").value;
            if (strProvinceAndCity == "") { alert("请输入所在省市"); document.getElementById("txtProvinceAndCity").focus(); return false; }
            //联系地址
            var strAddress = document.getElementById("txtAddress").value;
            if (strAddress == "") { alert("请输入联系地址"); document.getElementById("txtAddress").focus(); return false; }
            //贷款年限
            var yearsID = document.getElementById("Years");
            var Years = yearsID.options[yearsID.selectedIndex].value;
            if (Years == "请选择") { alert("请选择贷款年限"); document.getElementById("Years").focus(); return false; }
            //贷款金额
            var strMoney = document.getElementById("txtMoney").value;
            if (strMoney == "") { alert("请输入贷款金额"); document.getElementById("txtMoney").focus(); return false; }
            //贷款用途
            var strUse = document.getElementById("txtUse").value;
            if (strUse == "") { alert("请输入贷款用途"); document.getElementById("txtUse").focus(); return false; }
            //防止用户多次点击
            document.getElementById('Button1').disabled = true;
            document.getElementById('Button1').value = "正在提交...";
            //提交信息开始
            $.ajax({
                type: "get",
                url: "Submit.ashx?info=" + escape("姓名：" + strName + "， 性别：" + Sex + "， 身份证号：" + strIDCard + "， 联系电话：" + strPhone + "， QQ：" + strQQ + "， 所在省市：" + strProvinceAndCity + "， 联系地址：" + strAddress + "， 贷款年限：" + Years + "， 贷款金额：" + strMoney + "， 贷款用途：" + strUse),
                success: function (msg) {
                    if (msg == "success") {
                        document.getElementById('Button1').value = "恭喜你，提交成功";
                        alert("恭喜你，资料提交成功！");
                    }
                    else {
                        document.getElementById('Button1').value = "提交资料申请";
                        document.getElementById('Button1').disabled = false;
                        alert("含非法字符，资料提交失败！");
                    }
                }
            });
            //提交信息结束
        }
    </script>
    <style type="text/css">
        input
        {
            border: #CCCCCC solid 1px;
            margin: 0;
            padding: 0;
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <!--Content Start-->
    <table cellpadding="5" cellspacing="0" border="0" width="100%">
        <tr>
            <td width="80" align="right">
                真实姓名：
            </td>
            <td>
                <input id="txtName" name="txtName" type="text" style="width: 80px;" maxlength="4" />
            </td>
        </tr>
        <tr>
            <td align="right">
                身份证号：
            </td>
            <td>
                <input id="txtIDCard" name="txtIDCard" type="text" style="width: 160px;" maxlength="18" />
            </td>
        </tr>
        <tr>
            <td align="right">
                性别：
            </td>
            <td>
                <select id="Sex" name="Sex">
                    <option value="请选择" selected="selected">请选择</option>
                    <option value="男">男</option>
                    <option value="女">女</option>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                手机号码：
            </td>
            <td>
                <input id="txtPhone" name="txtPhone" type="text" style="width: 120px;" maxlength="11" />
            </td>
        </tr>
        <tr>
            <td align="right">
                QQ：
            </td>
            <td>
                <input id="txtQQ" name="txtQQ" style="width: 120px;" type="text" maxlength="10" />
            </td>
        </tr>
        <tr>
            <td align="right">
                所在省市：
            </td>
            <td>
                <input id="txtProvinceAndCity" name="txtProvinceAndCity" type="text" style="width: 120px;"
                    maxlength="32" />
            </td>
        </tr>
        <tr>
            <td align="right">
                联系地址：
            </td>
            <td>
                <input id="txtAddress" name="txtAddress" type="text" style="width: 200px;" maxlength="255" />
            </td>
        </tr>
        <tr>
            <td align="right">
                贷款年限：
            </td>
            <td>
                <select id="Years" name="Years">
                    <option value="请选择" selected="selected">请选择</option>
                    <option value="5年以下">5年以下</option>
                    <option value="5-10年">5-10年</option>
                    <option value="10年以上">10年以上</option>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right">
                贷款金额：
            </td>
            <td>
                <input id="txtMoney" name="txtMoney" type="text" style="width: 80px;" maxlength="7"
                    t_value="" o_value="" onkeypress="if(!this.value.match(/^[\+\-]?\d*?\.?\d*?$/))this.value=this.t_value;else this.t_value=this.value;if(this.value.match(/^(?:[\+\-]?\d+(?:\.\d+)?)?$/))this.o_value=this.value"
                    onkeyup="if(!this.value.match(/^[\+\-]?\d*?\.?\d*?$/))this.value=this.t_value;else this.t_value=this.value;if(this.value.match(/^(?:[\+\-]?\d+(?:\.\d+)?)?$/))this.o_value=this.value"
                    onblur="if(!this.value.match(/^(?:[\+\-]?\d+(?:\.\d+)?|\.\d*?)?$/))this.value=this.o_value;else{if(this.value.match(/^\.\d+$/))this.value=0+this.value;if(this.value.match(/^\.$/))this.value=0;this.o_value=this.value};" />
                万元
            </td>
        </tr>
        <tr>
            <td align="right">
                贷款用途：
            </td>
            <td>
                <input id="txtUse" name="txtUse" type="text" style="width: 200px;" maxlength="32" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <input id="Button1" name="Button1" type="button" value="提交资料申请" onclick="checkContent();"
                    style="cursor: pointer;" />
            </td>
        </tr>
    </table>
    <!--Content End-->
    </form>
</body>
</html>

