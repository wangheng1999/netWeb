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

public partial class UserControls_Contact : System.Web.UI.UserControl
{
    public string strCompanyName = null;
    public string strAddress = null;
    public string strContact = null;
    public string strPhone = null;
    public string strMobile = null;
    public string strEmail = null;
    public string strFax = null;
    public string strQQ = null;
    public string strICP = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        showContact();
    }
    protected void showContact()
    {
        Common common = new Common();
        Contact contact = new Contact();
        contact = common.showContact();
        strCompanyName = contact.CompanyName;
        if (strCompanyName != "")
        {
            strCompanyName = "<li>" + strCompanyName + "</li>";
        }
        strAddress = contact.Address;
        if (strAddress != "")
        {
            strAddress = "<li>地址：" + strAddress + "</li>";
        }
        strPhone = contact.Phone;
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
        if (strEmail != "")
        {
            strEmail = "<li>Email：" + strEmail + "</li>";
        }
        strFax = contact.Fax;
        if (strFax != "")
        {
            strFax = "<li>传真：" + strFax + "</li>";
        }
        strContact = contact.ContactName;
        if (strContact != "")
        {
            strContact = "<li>联系人：" + strContact + "</li>";
        }
        strQQ = contact.QQ;
        if (strQQ != "")
        {
            strQQ = "<li>QQ：" + strQQ + "</li>";
        }
    }

}

