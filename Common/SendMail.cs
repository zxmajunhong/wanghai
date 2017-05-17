using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;
namespace Common
{
   public class SendMail
    {
       /// <summary>
       /// 发送电子邮件
       /// </summary>
       /// <param name="mailaddress"></param>
       /// <param name="title"></param>
       /// <param name="file"></param>
       /// <param name="content"></param>
       /// <param name="fromname"></param>
       /// <param name="pwd"></param>
       /// <param name="SendUserName"></param>
        public static void Sendmail(string mailaddress, string title, string file, string content,string SendUserName="king", string fromname="wangyuzhu88@126.com", string pwd="452118")
        {
            MailMessage mails = new MailMessage();
            string fileone;
            mails.From = new MailAddress(fromname, SendUserName, System.Text.Encoding.UTF8);//说明指定发件人的信息
            mails.Subject = title;
            fileone = file;
            if (file != String.Empty)
            {
                AlternateView avfile = new AlternateView(fileone);
                mails.AlternateViews.Add(avfile);
            }
            mails.BodyEncoding = System.Text.Encoding.UTF8;
            mails.IsBodyHtml = true;
            mails.Body = content;
            mails.Priority = MailPriority.High;//优先级
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(fromname, pwd);//发送人的邮箱
            string host = fromname.Substring(fromname.LastIndexOf("@") + 1);
            smtp.Host = "smtp." + host;
            string[] maillist = mailaddress.Split(';');
            for (int i = 0; i < maillist.Length; i++)
            {
                mails.To.Add(maillist[i]);//收件人的邮箱
            }

            try
            {
                smtp.EnableSsl = true;//ssl加密
                //smtp.Timeout = 1200;
                smtp.Send(mails);
               // HttpContext.Current.Response.Write(" <script>alert('发送成功'); </script>");
            }
            catch (Exception e)
            {
             //   HttpContext.Current.Response.Write(" <script>alert('" + e.Message + "'); </script>");
            }
        }
    }
}
