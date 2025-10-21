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
using System.Data.SqlClient;
using WebApp.Components;
using basic;

public partial class Message2 : System.Web.UI.Page
{
    public MyClass mc = new MyClass();
    public int intClassID;
    public string strParentColumnName = null;
    public string strParentColumnSubName = null;
    public string strColumnName = null;
    public string strColumnSubName = null;
    public string strPath = null;
    int intRowCount;//用来记录总记录数
    public string yangban;
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemTools systemtools = new SystemTools();
        if (systemtools.IsNumberic(Request["ClassID"]))
        {
            intClassID = Int32.Parse(Request["ClassID"]);
            //调用类
            Common common = new Common();

            //以上结束
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
            this.Title = strColumnName + "-" + mc.ShowWebsiteKeyById(1, "CompanyName");
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



            MessageZidingyi.Visible = false;
            MessageMoban.Visible = false;
            yangban = mc.ShowColumnKeyById(intClassID, "Sample");
            if (yangban == "" || yangban == "99")
            {
                MessageZidingyi.Visible = true;
                GetMobanhtml();
            }
            else
            {
                MessageMoban.Visible = true;
                GetMobanhtml();
            }
        }
    }
    public string strhtml = "";
    public void GetMobanhtml()
    {

        if (yangban == "1" || yangban == "" || yangban == "99")
        {
            strhtml += "<div class=\"update_message1\">";
            strhtml += "<ul>";
            strhtml += "<li><input class=\"input_text\" type=\"text\" id=\"txtTitle\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\" placeholder=\"您的主题\"><font>*</font></li>";
            strhtml += "<li><input class=\"input_text\" type=\"text\" id=\"txtRealname\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\" placeholder=\"您的姓名\"><font>*</font></li>";
            strhtml += "<li><input class=\"input_text\" type=\"text\" id=\"txtPhone\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\" placeholder=\"您的手机\"><font>*</font></li>";
            strhtml += "<li><input class=\"input_text\" type=\"text\" id=\"txtEmail\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\" placeholder=\"您的邮箱\"><font>*</font></li>";
            strhtml += "<li><textarea rows=\"5\" id=\"txtContent\" placeholder=\"您的内容\"></textarea></li>";
            strhtml += "<li><input class=\"input_text1\" type=\"text\" id=\"txtCode\" value=\"\" onfocus=\"if(this.value=='') this.value='';\" onblur=\"if(this.value=='') this.value='';\" placeholder=\"请输入验证码\" ><img class=\"met-getcode\" title=\"看不清？点击更换验证码\" onclick=\"this.src='/Check/Code.aspx?' + Math.random()\" src=\"/Check/Code.aspx\" align=\"absmiddle\" role=\"button\"></li>";
            strhtml += "<li><div id=\"divbutton\">";
            strhtml += "<button type=\"button\" id=\"Button1\" class=\"input_button\" onclick=\"return checkNull()\" style=\"cursor: pointer; outline: none;\">提交信息</button>";
            strhtml += "</div>";
            strhtml += "<div>";
            strhtml += "<span id=\"loading\" style=\"display: none;\">";
            strhtml += "<button type=\"button\"  class=\"input_button\"  style=\"cursor: pointer; outline: none;\">正在提交...</button>";
            strhtml += "</span>";
            strhtml += "</div>";
            strhtml += "</li>";
            strhtml += "</ul>";
            strhtml += "</div>";
        }
        else if (yangban == "2")
        {
            strhtml += "<div class=\"update_message2\">";
            strhtml += "<h2>在线留言</h2>";
            strhtml += "<h3>感谢您对" + mc.ShowWebsiteKeyById(1, "CompanyName") + "的关注与支持，您可以直接联系客服热线，也可在线提交表单，我们会尽快安排工作人员与您取得联系。</h3>";
            strhtml += "<dl>";
            strhtml += "<dt>";
            strhtml += "<img src=\"images/message_tel.jpg\"><div class=\"pub-shadow\"></div>";
            strhtml += "<div class=\"update_message2_desc\"><span>客服专线</span><strong><a>" + mc.ShowWebsiteKeyById(1, "Phone") + "</a></strong></div>";
            strhtml += "</dt>";
            strhtml += "<dd>";
            strhtml += "<input type=\"text\" class=\"input_text\" id=\"txtTitle\" placeholder=\"主题\"><font>*</font></dd>";
            strhtml += "<dd class=\"mr-0\">";
            strhtml += "<input type=\"text\" id=\"txtRealname\" class=\"input_text\" placeholder=\"姓名\"><font>*</font></dd>";
            strhtml += "<dd>";
            strhtml += "<input type=\"text\" class=\"input_text\" id=\"txtEmail\" placeholder=\"邮箱\"><font>*</font></dd>";
            strhtml += "<dd class=\"mr-0\">";
            strhtml += "<input type=\"text\" class=\"input_text\" id=\"txtPhone\" placeholder=\"电话\"><font>*</font></dd>";
            strhtml += "<dd class=\"update_textarea2\">";
            strhtml += "<textarea cols=\"30\" rows=\"10\" class=\"get required\" id=\"txtContent\" placeholder=\"咨询内容\"></textarea><font>*</font></dd>";
            strhtml += "<dd>";
            strhtml += "<input class=\"input_text input_text1\" placeholder=\"请输入验证码\" id=\"txtCode\" type=\"text\" value=\"\"><span class=\"send-code\"><img class=\"met-getcode\" title=\"看不清？点击更换验证码\" onclick=\"this.src='/Check/Code.aspx?' + Math.random()\" src=\"/Check/Code.aspx\" align=\"absmiddle\" role=\"button\"></span></dd>";
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "<div id=\"divbutton\">";
            strhtml += "<button class=\"update_input_button\" type=\"button\" onclick=\"return checkNull()\" id=\"Button1\">提交</button>";
            strhtml += "</div>";
            strhtml += "<div>";
            strhtml += "<span id=\"loading\" style=\"display: none;\">";
            strhtml += "<button class=\"update_input_button\" type=\"button\">正在提交...</button>";
            strhtml += "</span>";
            strhtml += "</div>";
            strhtml += "</dl>";
            strhtml += "</div>";
        }
        else if (yangban == "3")
        {
            strhtml += "<div class=\"update_message3 wapper\">";
            strhtml += "<div class=\"update_message3_left\"><img src=\"images/mes.png\"></div>";
            strhtml += "<div class=\"update_message3_right\">";
            strhtml += "<h2>在线留言<span>解决您的需求，就是我们的使命</span></h2>";
            strhtml += "<ul>";
            strhtml += "<li><input class=\"input_text\" placeholder=\"主题\" id=\"txtTitle\" type=\"text\" value=\"\"></li>";
            strhtml += "<li><input class=\"input_text\" placeholder=\"姓名\" id=\"txtRealname\" type=\"text\" value=\"\"></li>";
            strhtml += "<li><input class=\"input_text\" placeholder=\"电话\" id=\"txtPhone\" type=\"text\" value=\"\"></li>";
            strhtml += "<li><input class=\"input_text\" placeholder=\"邮箱\" id=\"txtEmail\" type=\"text\" value=\"\"></li>";
            strhtml += "<li><input class=\"input_text input_text1\" placeholder=\"请输入验证码\" id=\"txtCode\" type=\"text\" value=\"\"><span class=\"send-code\"><img  class=\"met-getcode\" title=\"看不清？点击更换验证码\" onclick=\"this.src='/Check/Code.aspx?' + Math.random()\" src=\"/Check/Code.aspx\" align=\"absmiddle\" role=\"button\"></span></li>";
            strhtml += "<li><textarea id=\"txtContent\" class=\"form-control len-full\" rows=\"7\" placeholder=\"请把您的需求留下，我们为您提供专业的解决方案\" name=\"content\" cols=\"50\"></textarea></li>";
            strhtml += "<li id=\"divbutton\"><button type=\"button\" onclick=\"return checkNull()\" id=\"Button1\" class=\"update_input_button\">提 交</button></li>";
            strhtml += "<li id=\"loading\" style=\"display: none;\">";
            strhtml += "<button class=\"update_input_button\" type=\"button\">正在提交...</button>";
            strhtml += "</li>";
            strhtml += "</ul>";
            strhtml += "</div>";
            strhtml += "<div class=\"clear\"></div>";
            strhtml += "</div>";
        }
    }
}

