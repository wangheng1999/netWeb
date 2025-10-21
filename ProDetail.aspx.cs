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
using System.Text.RegularExpressions;

public partial class ProDetail : System.Web.UI.Page
{
    public int intID;
    public string strParentColumnName = "";
    public string strColumnName = "Product display";

    public string strProName;
    public string strProBianhao;
    public string strProChandi;
    public string strProPrice;
    public string strKeywords;
    public string strKeywords2;
    public string strKeywords3;
    public string strPutdate;
    public int intHits;
    public string strProPath;
    public string strProDescription;
    public string[] ConImg = { "" };
    public string strPhone;
    public BasicPage bp = new BasicPage();
    public MyClass mc = new MyClass();
    public int intPrevious;
    public int intNext;
    public string strPrevious = "没有了";
    public string strNext = "没有了";
    public string strPreviousUrl = "#";
    public string strNextUrl = "#";
    public string yangban;
    public string strQQ;
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemTools systemtools = new SystemTools();
        if (systemtools.IsNumberic(Request["ProId"]))
        {
            intID = Int32.Parse(Request["ProId"]);
          
            //上一个产品，下一个产品
            showPreviousAndNext(intID);
            //调用类
            Common common = new Common();

            //读取整站SEO的设置信息
            ClientSEO clientseo = common.showSEO();
            this.Title = clientseo.WebTitle;
            description.Attributes["content"] = clientseo.WebDescription;
            keywords.Attributes["content"] = clientseo.WebKeywords;
            //联系方式
            Contact contact = new Contact();
            contact = common.showContact();
            strPhone = contact.Phone;
            strQQ = contact.QQ;
            //根据ID显示内容
            showContent();
            showPro();
            yangban = mc.ShowWebsiteKeyById(1, "ProDetailSample");
            ProZidingyi.Visible = false;
            ProMoban1.Visible = false;
            ProMoban2.Visible = false;
            ProMoban3.Visible = false;
            switch (yangban)
            {
               
                case "1": ProMoban1.Visible = true; break;
                case "2": ProMoban2.Visible = true; break;
                case "3": ProMoban3.Visible = true; break;
                default: ProZidingyi.Visible = true; break;
            }
        }
        else
        {
            Response.Write("您的请求带有不合法的参数，谢谢合作！");
            Response.End();
        }
    }
    public string paths;
    public string content1;
    public string content2;
    public string strProKeyDescription;
    protected void showContent()
    {
        Products products = new Products();

        SqlDataReader reader = products.GetSingleProduct(intID);
        if (reader.Read())
        {
            strProName = reader["ProName"].ToString();
            strProBianhao = reader["ProBianhao"].ToString();
            strProChandi = reader["ProChandi"].ToString();
            strProPrice = reader["ProPrice"].ToString();
            strKeywords = reader["Keywords"].ToString();
            strKeywords2 = reader["Keywords2"].ToString();
            strKeywords3 = reader["Keywords3"].ToString();
            strPutdate = Convert.ToDateTime(reader["Putdate"].ToString()).ToString("yyyy-MM-dd");
            strProPath = reader["ProPath"].ToString();
            strProDescription = reader["ProDescription"].ToString();
            strProKeyDescription = reader["ProKeyDescription"].ToString();
            content1 = reader["content1"].ToString();
            content2 = reader["content2"].ToString();
            paths = reader["paths"].ToString();
            if (paths == "")
            {
                paths = strProPath;
            }
            else { 
                paths = strProPath + "|" + paths;
            }
            ConImg = paths.Split('|');
        }
        reader.Close();

        this.Title = strProName + "-" + mc.ShowWebsiteKeyById(1, "CompanyName");

    }

    //产品展示
    public DataTable dtPro = new DataTable();
    public int intPro;
    public void showPro()
    {
        dtPro = bp.SelectDataBase("product", "select top 8 * from product where Proid<>"+intID+" order by paixu desc,proid desc").Tables[0];
        intPro = dtPro.Rows.Count;
    }

    public void showPreviousAndNext(int ID)
    {
        MyClass mc = new MyClass();
        Products products = new Products();
        SqlDataReader reader = products.GetAllProducts();
        DataTable dtbl = SystemTools.ConvertDataReaderToDataTable(reader);
        DataSet dstProducts = new DataSet();
        dstProducts.Tables.Add(dtbl);

        intPrevious = ID;
        intNext = ID;
        for (int i = 0; i < dstProducts.Tables[0].Rows.Count; i++)
        {
            if (intID == Int32.Parse(dstProducts.Tables[0].Rows[i]["ProId"].ToString()))
            {
                if (i >= 1)
                {
                    intNext = Int32.Parse(dstProducts.Tables[0].Rows[i - 1]["ProId"].ToString());
                    //strNext = dstProducts.Tables[0].Rows[i - 1]["ProName"].ToString();
                    strNext = "上一个产品";
                    strNextUrl = "ProDetail.aspx?ProId=" + intNext;
                }
                if (i < dstProducts.Tables[0].Rows.Count - 1)
                {
                    intPrevious = Int32.Parse(dstProducts.Tables[0].Rows[i + 1]["ProId"].ToString());
                    //strPrevious = dstProducts.Tables[0].Rows[i + 1]["ProName"].ToString();
                    strPrevious = "下一个产品";
                    strPreviousUrl = "ProDetail.aspx?ProId=" + intPrevious;
                }
            }
        }
    }
}

