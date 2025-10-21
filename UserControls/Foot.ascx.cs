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
using System.Net;
using System.IO;
using System.Text;

public partial class Foot : System.Web.UI.UserControl
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

    public string strPath;
    public string strState;
    public DataSet dstQQ = new DataSet();
    public int intQQ;
    public string strQQList = null;

    public string strContent;
    public string strCodeState;

    public string strWebKeywords;

    public string strSupportName;
    public string strTitle;
    public string strWebSite;
    public string strSupportState;
    public string strStateManage;
    public string strStateSitemap;
    public string ContactUrl;
    public MyClass mc = new MyClass();
    public BasicPage bp = new BasicPage();
    protected void Page_Load(object sender, EventArgs e)
    {
        Common common = new Common();
        Contact contact = new Contact();
        contact = common.showContact();
        strCompanyName = contact.CompanyName;
        if (strCompanyName != "")
        {
            strCompanyName = strCompanyName + "&nbsp;&nbsp;";
        }
        strAddress = contact.Address;

        strContact = contact.ContactName;

        strPhone = contact.Phone;

        strEmail = contact.Email;

        strQQ = contact.QQ;

        strMobile = contact.Mobile;

        strFax = contact.Fax;

        ClientMusic clientmusic = new ClientMusic();
        clientmusic = common.showMusic();
        strPath = clientmusic.Path;
        strState = clientmusic.State;

        QQ qq = new QQ();
        SqlDataReader reader = qq.GetQQState();
        DataTable dtbl = SystemTools.ConvertDataReaderToDataTable(reader);
        dstQQ.Tables.Add(dtbl);
        intQQ = dstQQ.Tables[0].Rows.Count;

        for (int i = 0; i < intQQ; i++)
        {
            strQQList = strQQList + dstQQ.Tables[0].Rows[i]["qq"].ToString() + "|" + dstQQ.Tables[0].Rows[i]["name"].ToString() + ",";
        }
        if (intQQ > 0)
        {
            strQQList = strQQList.Substring(0, strQQList.Length - 1);
        }

        SetupCode setupcode = new SetupCode();
        setupcode = common.showSetupCode();
        reader.Close();
        strCodeState = setupcode.State;
        strContent = setupcode.Content;//显示第三方代码

        //显示SEO关键词
        ClientSEO clientseo = common.showSEO();
        strWebKeywords = clientseo.WebKeywords;

        //设置技术支持
        ClientSupport clientsupport = common.showSupport();
        strSupportName = clientsupport.SupportName;
        strTitle = clientsupport.Title;
        strWebSite = clientsupport.WebSite;
        strSupportState = clientsupport.State;
        strStateManage = clientsupport.StateManage;
        strStateSitemap = clientsupport.StateSitemap;
        GetWebFootInfo();
        showLinks();
        showMenu();
        showNews3();
        SqlDataReader myread = bp.getRead("select top 1 ColumnUrlClient from ColumnList where ColumnType='联系方式' order by ColumnNo desc,id asc");
        if (myread.Read())
        {
            ContactUrl = myread[0].ToString();
        }
        myread.Close();
    }

    //获取技术支持、技术支持title、技术支持网址、ICP链接
    protected string GetWebFootInfo()
    {
        try
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Basic.WebFootInfo.Keys.FootInfoUrl);
            request.Method = "GET";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.UserAgent = "   Mozilla/5.0 (Windows NT 6.1; WOW64; rv:28.0) Gecko/20100101 Firefox/28.0";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //这个在Post的时候，一定要加上，如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            request.ServicePoint.Expect100Continue = false;
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.Default);//UTF-8
            string htmlContent = sr.ReadToEnd();

            if (htmlContent.IndexOf('|') != -1)
            {
                strSupportName = htmlContent.Split('|')[0].Trim();
                strTitle = htmlContent.Split('|')[1].Trim();
                strWebSite = htmlContent.Split('|')[2].Trim();
                string strICPUrl = htmlContent.Split('|')[3].Trim();

                Common common = new Common();
                Contact contact = new Contact();
                contact = common.showContact();
                string ICP = contact.ICP;
                if (ICP != "")
                {
                    strICP = "备案号：<a href='" + strICPUrl + "' target=\"_blank\">" + ICP + "</a>";
                }
            }
        }
        catch (Exception ex)
        {

        }
        return "ERROR";
    }

    public DataSet dstMenu = new DataSet();
    public int intMenu;
    private void showMenu()
    {
        dstMenu = bp.SelectDataBase("News", "select Id,ParentId,ColumnType,ColumnName,ColumnNo,ColumnUrlClient,ColumnStaticPage,StaticPage from ColumnList where ParentId=0 and IndexStatus=0 order by ColumnNo desc,Id asc");
        intMenu = dstMenu.Tables[0].Rows.Count;
    }
    public DataTable dtLink = new DataTable();
    public int intLink;
    private void showLinks()
    {
        dtLink = bp.SelectDataBase("News", "select top 30 title,url from Links order by id desc").Tables[0];
        intLink = dtLink.Rows.Count;
    }
    //产品分类
    public DataTable dtblNew3 = new DataTable();
    public int intNews3;
    private void showNews3()
    {
        dtblNew3 = bp.SelectDataBase("ProClass", "select * from ProClass where ParentId=0 and State=0 order by Paixu desc,Id asc").Tables[0];
        intNews3 = dtblNew3.Rows.Count;
    }
}

