using System;
using System.Collections.Generic;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Text;

/// <summary>
/// 发送邮件
/// </summary>
namespace Basic.Tools
{
    public class Mail
    {
        /// <summary>
        /// 通用发送邮件（收件邮箱/发件人/邮件主题/邮件内容）
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="FajianRen"></param>
        /// <param name="Title"></param>
        /// <param name="strMailContent"></param>
        /// <returns></returns>
        public static bool Send(string Email, string FajianRen, string Title, string strMailContent)
        {
            bool jieguo = false;
            WebClient wc = new WebClient();
            StringBuilder postData = new StringBuilder();
            postData.Append("key=" + Basic.Keys.MailKey);
            postData.Append("&tomail=" + Email);
            postData.Append("&body=" + strMailContent);
            postData.Append("&fajianrenmingcheng=" + FajianRen);
            postData.Append("&youjianmingzi=" + Title);
            byte[] sendData = Encoding.GetEncoding("UTF-8").GetBytes(postData.ToString());
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            wc.Headers.Add("ContentLength", sendData.Length.ToString());
            byte[] recData = wc.UploadData(Basic.Keys.MailUrlNotice, "POST", sendData);

            try
            {
                string result = Encoding.GetEncoding("UTF-8").GetString(recData).ToLower();

                if (result == "true")
                {
                    jieguo = true;
                    //操作成功
                }
                else
                {
                    jieguo = false;
                    //操作失败
                }
            }
            catch (Exception ex)
            {

            }
            return jieguo;
        }
    }
}
