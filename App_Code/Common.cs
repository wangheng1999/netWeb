using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Components
{
    /// <summary>
    /// 网站前台页面通用类
    /// </summary>
    public class Common
    {
        public WebSiteState showWebSiteState()
        {
            WebSiteState websitestate = new WebSiteState();
            WebSite website = new WebSite();

            int intID = 1;
            SqlDataReader dr = website.GetWebSiteControl(intID);
            if (dr.Read())
            {
                websitestate.State = dr["State"].ToString();
                websitestate.Tishi = dr["Tishi"].ToString();
            }
            dr.Close();

            return websitestate;
        }
        public SetupCode showSetupCode()
        {
            SetupCode setupcode = new SetupCode();
            WebSite website = new WebSite();

            int intID = 1;
            SqlDataReader dr = website.GetSetupCode(intID);
            if (dr.Read())
            {
                setupcode.State = dr["State"].ToString();
                setupcode.Content = dr["Content"].ToString();
            }
            dr.Close();

            return setupcode;
        }
        public Contact showContact()
        {
            Contact contact = new Contact();
            int intID = 1;
            WebSite website = new WebSite();
            SqlDataReader dr = website.GetWesSite(intID);
            if (dr.Read())
            {
                contact.CompanyName = dr["CompanyName"].ToString();
                contact.NameState = dr["NameState"].ToString();
                contact.Address = dr["Address"].ToString();
                contact.ICP = dr["ICP"].ToString();
                contact.Phone = dr["Phone"].ToString();
                contact.Mobile = dr["Mobile"].ToString();
                contact.Email = dr["Email"].ToString();
                contact.Fax = dr["Fax"].ToString();
                contact.ContactName = dr["Contact"].ToString();
                contact.WebUrl = dr["WebUrl"].ToString();
                contact.QQ = dr["QQ"].ToString();
                contact.Map = dr["Map"].ToString();
                contact.WeChat = dr["WeChat"].ToString();
                contact.Zip = dr["Zip"].ToString();

            }
            dr.Close();
            return contact;
        }
        public ClientAbout showContent(int intID)
        {
            ClientAbout clientabout = new ClientAbout();
            About about = new About();
            SqlDataReader dr = about.GetAbout(intID);
            if (dr.Read())
            {
                clientabout.Content = dr["Content"].ToString();
            }
            else
            {
                clientabout.Content = "资料整理中…";
            }
            dr.Close();
            return clientabout;
        }
        public ClientColumnName showColumnName(int intClassID)
        {
            ClientColumnName clientcolumnname = new ClientColumnName();
            NewsClass newsclass = new NewsClass();
            SqlDataReader dr = newsclass.GetSingleColumnList(intClassID);
            if (dr.Read())
            {
                clientcolumnname.ColumnName = dr["ColumnName"].ToString();
                clientcolumnname.ColumnSubName = dr["ColumnSubName"].ToString();
                clientcolumnname.Path = dr["Path"].ToString();
                clientcolumnname.Length = dr["Length"].ToString();
                clientcolumnname.Width = dr["Width"].ToString();
            }
            dr.Close();
            return clientcolumnname;
        }
        public ClientParentColumnName showParentColumnName(int intClassID)
        {
            ClientParentColumnName clientparentcolumnname = new ClientParentColumnName();
            NewsClass newsclass = new NewsClass();
            SqlDataReader dr = newsclass.GetSingleParentColumnList(intClassID);
            if (dr.Read())
            {
                clientparentcolumnname.ParentColumnName = dr["ColumnName"].ToString();
                clientparentcolumnname.ParentColumnSubName = dr["ColumnSubName"].ToString();
            }
            dr.Close();
            return clientparentcolumnname;
        }
        public ClientSkin showSkin()
        {
            ClientSkin clientskin = new ClientSkin();

            Skin skin = new Skin();
            SqlDataReader dr = skin.GetStateSkin();
            if (dr.Read())
            {
                clientskin.StylePath = dr["StyleUrl"].ToString();
            }
            dr.Close();

            return clientskin;
        }
        public ClientSEO showSEO()
        {
            ClientSEO clientseo = new ClientSEO();
            SEO seo = new SEO();

            int intID = 1;
            SqlDataReader dr = seo.GetSEO(intID);
            if (dr.Read())
            {
                clientseo.WebTitle = dr["WebTitle"].ToString();
                clientseo.WebDescription = dr["WebDescription"].ToString();
                clientseo.WebKeywords = dr["WebKeywords"].ToString();
            }
            dr.Close();

            return clientseo;
        }
        public ClientMusic showMusic()
        {
            ClientMusic clientmusic = new ClientMusic();
            Music music = new Music();

            int intID = 1;
            SqlDataReader dr = music.GetWebMusic(intID);
            if (dr.Read())
            {
                clientmusic.Path = dr["Path"].ToString();
                clientmusic.State = dr["State"].ToString();
            }
            dr.Close();

            return clientmusic;
        }
        public ClientTimeLimit showTimeLimit()
        {
            ClientTimeLimit clienttimelimit = new ClientTimeLimit();
            Time time = new Time();

            int intID = 1;
            SqlDataReader dr = time.GetTimeLimit(intID);
            if (dr.Read())
            {
                clienttimelimit.EndTime = dr["EndTime"].ToString();
            }
            dr.Close();

            return clienttimelimit;
        }
        public ClientColumnSEO showColumnSEO(int intID)
        {
            ClientColumnSEO clientcolumnseo = new ClientColumnSEO();
            NewsClass newsclass = new NewsClass();
            SqlDataReader dr = newsclass.GetSingleColumnList(intID);
            if (dr.Read())
            {
                clientcolumnseo.ColumnTitle = dr["ColumnTitle"].ToString();
                clientcolumnseo.ColumnDescription = dr["ColumnDescription"].ToString();
                clientcolumnseo.ColumnKeywords = dr["ColumnKeywords"].ToString();
                clientcolumnseo.ColumnStaticPage = dr["ColumnStaticPage"].ToString();
            }
            dr.Close();

            return clientcolumnseo;
        }
        public ClientSupport showSupport()
        {
            ClientSupport clientsupport = new ClientSupport();
            WebSite website = new WebSite();
            int intID = 1;
            SqlDataReader dr = website.GetSupport(intID);
            if (dr.Read())
            {
                clientsupport.SupportName = dr["SupportName"].ToString();
                clientsupport.Title = dr["Title"].ToString();
                clientsupport.WebSite = dr["WebSite"].ToString();
                clientsupport.State = dr["State"].ToString();
                clientsupport.StateManage = dr["StateManage"].ToString();
                clientsupport.StateSitemap = dr["StateSitemap"].ToString();
            }
            dr.Close();

            return clientsupport;
        }
    }
    public class WebSiteState
    {
        private string strState;
        private string strTishi;
        public string State
        {
            get { return strState; }
            set { strState = value; }
        }
        public string Tishi
        {
            get { return strTishi; }
            set { strTishi = value; }
        }
    }
    public class SetupCode
    {
        private string strState;
        private string strContent;
        public string State
        {
            get { return strState; }
            set { strState = value; }
        }
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }
    }
    public class Contact
    {
        private string strCompanyName;
        private string strAddress;
        private string strICP;
        private string strPhone;
        private string strMobile;
        private string strEmail;
        private string strFax;
        private string strContact;
        private string strWebUrl;
        private string strQQ;
        private string strNameState;
        private string strMap;
        private string strWeChat;
        private string strZip;


        public string CompanyName
        {
            get { return strCompanyName; }
            set { strCompanyName = value; }
        }
        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }
        }
        public string ICP
        {
            get { return strICP; }
            set { strICP = value; }
        }
        public string Phone
        {
            get { return strPhone; }
            set { strPhone = value; }
        }
        public string Mobile
        {
            get { return strMobile; }
            set { strMobile = value; }
        }
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        public string Fax
        {
            get { return strFax; }
            set { strFax = value; }
        }
        public string ContactName
        {
            get { return strContact; }
            set { strContact = value; }
        }
        public string WebUrl
        {
            get { return strWebUrl; }
            set { strWebUrl = value; }
        }
        public string QQ
        {
            get { return strQQ; }
            set { strQQ = value; }
        }
        public string NameState
        {
            get { return strNameState; }
            set { strNameState = value; }
        }
        public string Map
        {
            get { return strMap; }
            set { strMap = value; }
        }
        public string WeChat
        {
            get { return strWeChat; }
            set { strWeChat = value; }
        }
        public string Zip
        {
            get { return strZip; }
            set { strZip = value; }
        }
    }

    public class ClientAbout
    {
        private string strContent;
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }
    }

    public class ClientColumnName
    {
        private string strColumnName;
        public string ColumnName
        {
            get { return strColumnName; }
            set { strColumnName = value; }
        }
        private string strColumnSubName;
        public string ColumnSubName
        {
            get { return strColumnSubName; }
            set { strColumnSubName = value; }
        }
        private string strPath;
        public string Path
        {
            get { return strPath; }
            set { strPath = value; }
        }
        private string strLength;
        public string Length
        {
            get { return strLength; }
            set { strLength = value; }
        }
        private string strWidth;
        public string Width
        {
            get { return strWidth; }
            set { strWidth = value; }
        }
    }

    public class ClientParentColumnName
    {
        private string strParentColumnName;
        public string ParentColumnName
        {
            get { return strParentColumnName; }
            set { strParentColumnName = value; }
        }
        private string strParentColumnSubName;
        public string ParentColumnSubName
        {
            get { return strParentColumnSubName; }
            set { strParentColumnSubName = value; }
        }
    }
    public class ClientSkin
    {
        private string strStylePath;
        public string StylePath
        {
            get { return strStylePath; }
            set { strStylePath = value; }
        }
    }
    public class ClientSEO
    {
        private string strWebTitle;
        public string WebTitle
        {
            get { return strWebTitle; }
            set { strWebTitle = value; }
        }
        private string strWebDescription;
        public string WebDescription
        {
            get { return strWebDescription; }
            set { strWebDescription = value; }
        }
        private string strWebKeywords;
        public string WebKeywords
        {
            get { return strWebKeywords; }
            set { strWebKeywords = value; }
        }
    }
    public class ClientMusic
    {
        private string strPath;
        public string Path
        {
            get { return strPath; }
            set { strPath = value; }
        }
        private string strState;
        public string State
        {
            get { return strState; }
            set { strState = value; }
        }
    }
    public class ClientTimeLimit
    {
        private string strEndTime;
        public string EndTime
        {
            get { return strEndTime; }
            set { strEndTime = value; }
        }
    }
    public class ClientColumnSEO
    {
        private string strColumnTitle;
        private string strColumnDescription;
        private string strColumnKeywords;
        private string strColumnStaticPage;
        public string ColumnTitle
        {
            get { return strColumnTitle; }
            set { strColumnTitle = value; }
        }
        public string ColumnDescription
        {
            get { return strColumnDescription; }
            set { strColumnDescription = value; }
        }
        public string ColumnKeywords
        {
            get { return strColumnKeywords; }
            set { strColumnKeywords = value; }
        }
        public string ColumnStaticPage
        {
            get { return strColumnStaticPage; }
            set { strColumnStaticPage = value; }
        }
    }
    public class ClientSupport
    {
        private string strSupportName;
        private string strTitle;
        private string strWebSite;
        private string strState;
        private string strStateManage;
        private string strStateSitemap;
        public string SupportName
        {
            get { return strSupportName; }
            set { strSupportName = value; }
        }
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }
        public string WebSite
        {
            get { return strWebSite; }
            set { strWebSite = value; }
        }
        public string State
        {
            get { return strState; }
            set { strState = value; }
        }
        public string StateManage
        {
            get { return strStateManage; }
            set { strStateManage = value; }
        }
        public string StateSitemap
        {
            get { return strStateSitemap; }
            set { strStateSitemap = value; }
        }
    }
}

