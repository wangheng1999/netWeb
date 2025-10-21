using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebApp.Components;

public partial class Contact2 : System.Web.UI.Page
{
    public int intClassID;
    public string strParentColumnName = null;
    public string strParentColumnSubName = null;
    public string strColumnName = null;
    public string strColumnSubName = null;
    public string strPath = null;
    public MyClass mc = new MyClass();
    public string strCompanyName = null;
    public string strAddress = null;
    public string strPhone = null;
    public string strMobile = null;
    public string strEmail = null;
    public string strFax = null;
    public string strContact = null;
    public string strWebUrl = null;
    public string strQQ = null;
    public string strMap = null;
    public string strWeChat = null;
    public string yangban;
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemTools systemtools = new SystemTools();
        if (systemtools.IsNumberic(Request["ClassID"]))
        {
            intClassID = Int32.Parse(Request["ClassID"]);
            //调用类
            Common common = new Common();
           
            //根据ClassID显示内容
            showContact();
            //显示栏目名称
            ClientColumnName clientcolumnname = new ClientColumnName();
            clientcolumnname = common.showColumnName(intClassID);
            strColumnName = clientcolumnname.ColumnName;
            strColumnSubName = clientcolumnname.ColumnSubName;
            //显示图片或者Flash
            strPath = clientcolumnname.Path;
            string strType = null;
            if (strPath.Length >= 3)
            {
                strType = strPath.Substring(strPath.Length - 3, 3);
            }
            string strLength = clientcolumnname.Length;
            string strWidth = clientcolumnname.Width;
            if (strType == "swf")
            {
                strPath = "<script type=\"text/javascript\">F_viewSwf('" + strWidth + "','" + strLength + "','transparent','transparent','" + strPath + "');</script>";
            }
            else
            {
                strPath = "<img src='" + clientcolumnname.Path + "' alt='' />"; //显示内页通栏图片
            }
            //显示父级栏目名称
            ClientParentColumnName clientparentcolumnname = new ClientParentColumnName();
            clientparentcolumnname = common.showParentColumnName(intClassID);
            strParentColumnName = clientparentcolumnname.ParentColumnName;
            strParentColumnSubName = clientparentcolumnname.ParentColumnSubName;


            //读取整站SEO的设置信息
            ClientSEO clientseo = common.showSEO();
            this.Title = strColumnName+"-"+ mc.ShowWebsiteKeyById(1, "CompanyName");
            description.Attributes["content"] = clientseo.WebDescription;
            keywords.Attributes["content"] = strColumnName + "," + mc.ShowWebsiteKeyById(1, "CompanyName");
            //读取某个栏目的SEO设置信息
            ClientColumnSEO clientcolumnseo = common.showColumnSEO(intClassID);
            if (clientcolumnseo.ColumnTitle.Length > 0)
            {
                this.Title = clientcolumnseo.ColumnTitle;

            }
            if (clientcolumnseo.ColumnDescription.Length > 0)
            {
                description.Attributes["content"] = clientcolumnseo.ColumnDescription;
            }
            if (clientcolumnseo.ColumnKeywords.Length > 0)
            {
                keywords.Attributes["content"] = clientcolumnseo.ColumnKeywords;
            }



            ContactZidingyi.Visible = false;
            ContactMoban.Visible = false;
            yangban = mc.ShowColumnKeyById(intClassID, "Sample");
            if (yangban == "" || yangban == "99")
            {
                ContactZidingyi.Visible = true;
            }
            else
            {
                ContactMoban.Visible = true;
                GetMobanhtml();
            }
        }
    }
    public string strAddress1;
    public string strEmail1;
    public string strQQ1;
    public string strPhone1;
    public string strFax1;
    public string strWebUrl1;

    protected void showContact()
    {
        Common common = new Common();
        Contact contact = new Contact();
        contact = common.showContact();
        strCompanyName = contact.CompanyName;
        if (strCompanyName != "")
        {
            strCompanyName = "<strong style=\"font-size: 14px;\">" + strCompanyName + "</strong>";
        }
        strAddress = contact.Address;
        strAddress1 = contact.Address;
        if (strAddress != "")
        {
            strAddress = "<li>地址：" + strAddress + "</li>";
        }
        strPhone = contact.Phone;
        strPhone1 = contact.Phone;
        if (strPhone != "")
        {
            strPhone = "<li>电话：" + strPhone + "</li>";
        }
        strMobile = contact.Mobile;
        if (strMobile != "")
        {
            strMobile = "<li>手机：" + strMobile + "</li>";
        }
        strEmail = contact.Email;
        strEmail1 = contact.Email;
        if (strEmail != "")
        {
            strEmail = "<li>Email：" + strEmail + "</li>";
        }
        strFax = contact.Fax;
        strFax1 = contact.Fax;
        if (strFax != "")
        {
            strFax = "<li>传真：" + strFax + "</li>";
        }
        strContact = contact.ContactName;
        if (strContact != "")
        {
            strContact = "<li>联系人：" + strContact + "</li>";
        }
        strWebUrl = contact.WebUrl;
        strWebUrl1 = contact.WebUrl;
        if (strWebUrl != "")
        {
            strWebUrl = "<li>公司网站：" + strWebUrl + "</li>";
        }
        strQQ = contact.QQ;
        strQQ1 = contact.QQ;
        if (strQQ != "")
        {
            strQQ = "<li>QQ：" + strQQ + "</li>";
        }
        strWeChat = contact.WeChat;
        if (strWeChat != "")
        {
            strWeChat = "<li>微信号：" + strWeChat + "</li>";
        }
        strMap = contact.Map;
        if (strMap != "")
        {
            strMap = "<li>" + strMap + "</li>";
        }

    }

    public string strhtml = "";
    public void GetMobanhtml()
    {

        if (yangban == "1")
        {
            strhtml += "<div class=\"update_contact1\">";
            strhtml += "<div class=\"update_contact1_map\">" + strMap + "</div>";
            strhtml += "<div class=\"update_contact1_right\">";
            strhtml += "<dl>";
            strhtml += "<dt>"+strCompanyName+"</dt>";
            strhtml += "<dd>"+strAddress+"</dd>";
            strhtml += "<dd>"+strPhone+"</dd>";
            strhtml += "<dd>"+strMobile+"</dd>";
            strhtml += "<dd>"+strWeChat+"</dd>";
            strhtml += "<dd>"+strEmail+"</dd>";
            strhtml += "<dd>"+strWebUrl+"</dd>";
            strhtml += "</dl>";
            strhtml += "</div>";
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</div>";
        }
        else if (yangban == "2")
        {
            strhtml += "<div class=\"update_contact2\">";
            strhtml += "<div class=\"update_contact_tit\">";
            strhtml += "<h2>联系我们</h2>";
            strhtml += "<h3>欢迎致电联系，我们期待与您的合作</h3>";
            strhtml += "</div>";
            strhtml += "<div class=\"update_contact2_lx\">";
            strhtml += "<div class=\"update_contact2_lx_left\">";
            strhtml += "<dl>";
            strhtml += "<dt>"+strCompanyName+"</dt>";
            strhtml += "<dd class=\"c_tel_1\">" + strMobile + "</dd>";
            strhtml += "<dd class=\"c_tel_1\">" + strPhone + "</dd>";
            strhtml += "<dd class=\"c_wechat_1\">" + strWeChat + "</dd>";
            strhtml += "<dd class=\"c_email_1\">" + strEmail + "</dd>";
            strhtml += "<dd class=\"c_web_1\">" + strWebUrl + "</dd>";
            strhtml += "<dd class=\"c_add_1\">" + strAddress + "</dd>";
            strhtml += "</dl>";
            strhtml += "</div>";
            strhtml += "<div class=\"update_contact2_lx_map\">" + strMap + "</div>";
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</div>";
            strhtml += "<div class=\"update_contact2_ly\">";
            strhtml += "<div class=\"update_contact_tit\">";
            strhtml += "<h2>在线留言</h2>";
            strhtml += "<h3>留下您宝贵的意见，我们提供更优质的服务</h3>";
            strhtml += "</div>";
            strhtml += "<ul>";
            strhtml += "<li><span>你的主题</span><input class=\"input_text\" type=\"text\" name=\"txtTitle\"  value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\"></li>";
            strhtml += "<li><span>您的姓名</span><input class=\"input_text\" type=\"text\" name=\"txtRealname\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\"></li>";
            strhtml += "<li><span>您的手机</span><input class=\"input_text\" type=\"text\" name=\"txtPhone\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\"></li>";
            strhtml += "<li><span>您的邮箱</span><input class=\"input_text\" type=\"text\" name=\"txtEmail\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\"></li>";
            strhtml += "<li class=\"last\"><span>您的内容</span><textarea name=\"txtContent\" rows=\"5\">默认出现文本</textarea></li>";
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "<button type=\"button\" name=\"Button1\" class=\"input_button\" onclick=\"return checkNull()\" style=\"cursor: pointer; outline: none;\">提交信息</button>";
            strhtml += "</div>";
            strhtml += "</div>";
        }
        else if (yangban == "3")
        {
            strhtml += "<div class=\"update_contact3\">";
            strhtml += "<div class=\"update_contact_tit\">";
            strhtml += "<h2>联系我们</h2>";
            strhtml += "<h3>欢迎致电联系，我们期待与您的合作</h3>";
            strhtml += "</div>";
            strhtml += "<div class=\"update_contact3_lx\">";
            strhtml += "<ul>";
            strhtml += "<li><img src=\"images/c_ico_tel1.png\"><strong>联系电话</strong><span>" + strPhone1 + "</span></li>";
            strhtml += "<li><img src=\"images/c_ico_add1.png\"><strong>工厂地址</strong><span>"+strAddress1+"</span></li>";
            strhtml += "<li><img src=\"images/c_ico_email1.png\"><strong>联系邮箱</strong><span>" + strEmail1 + "</span></li>";
            strhtml += "<li>";
            strhtml += "<img src=\"images/c_ico_qq1.png\"><strong>业务QQ</strong><span>" + strQQ1 + "</span></li>";
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</ul>";
            strhtml += "</div>";
            strhtml += "<div class=\"update_contact3_ly\">";
            strhtml += "<div class=\"update_contact3_map\">" + strMap + "</div>";
            strhtml += "<div class=\"update_contact3_right\">";
            strhtml += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            strhtml += "<tr>";
            strhtml += "<td width=\"100\">你的主题</td>";
            strhtml += "<td>";
            strhtml += "<input class=\"input_text\" type=\"text\" name=\"txtTitle\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\"></td>";
            strhtml += "</tr>";
            strhtml += "<tr>";
            strhtml += "<td>您的姓名</td>";
            strhtml += "<td>";
            strhtml += "<input class=\"input_text\" type=\"text\" name=\"txtRealname\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\"></td>";
            strhtml += "</tr>";
            strhtml += "<tr>";
            strhtml += "<td>您的手机</td>";
            strhtml += "<td>";
            strhtml += "<input class=\"input_text\" type=\"text\" name=\"txtPhone\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\"></td>";
            strhtml += "</tr>";
            strhtml += "<tr>";
            strhtml += "<td>您的邮箱</td>";
            strhtml += "<td>";
            strhtml += "<input class=\"input_text\" type=\"text\" name=\"txtEmail\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\"></td>";
            strhtml += "</tr>";
            strhtml += "<tr>";
            strhtml += "<td>您的内容</td>";
            strhtml += "<td>";
            strhtml += "<textarea name=\"txtContent\" rows=\"5\">默认出现文本</textarea></td>";
            strhtml += "</tr>";
            strhtml += "<tr>";
            strhtml += "<td>&nbsp;</td>";
            strhtml += "<td>";
            strhtml += "<button type=\"button\" name=\"Button1\" class=\"input_button\" onclick=\"return checkNull()\" style=\"cursor: pointer; outline: none;\">提交信息</button></td>";
            strhtml += "</tr>";
            strhtml += "</table>";
            strhtml += "</div>";
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</div>";
            strhtml += "</div>";
        }
    }
}

