using System;
using System.Net;
using System.Net.Mail;

namespace leanoteLibrary.Service
{
    public class MailService : MailMessage
    {


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formAddress">发件人邮箱地址</param>
        /// <param name="toAddress">收件人邮箱地址</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="body">邮件内容</param>
        public MailService(string formAddress, string toAddress, string subject, string body)
        {
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            this.From = new MailAddress(formAddress);
            //收件人邮箱地址。
            this.To.Add(new MailAddress(toAddress));
            //邮件标题。
            this.Subject = subject;
            //邮件内容。
            this.Body = body;
//            //设置为html
//            this.IsBodyHtml = true;
        }
        /// <summary>
        /// 以默认邮箱创造一封邮件
        /// </summary>
        /// <param name="ToAddress">对方的邮箱</param>
        /// <param name="Subject">标题</param>
        /// <param name="Body">邮件内容</param>
        /// <returns></returns>
        public static MailService CreatMailManager(string  ToAddress,string Subject,string Body) 
        {
            //实例化一个发送邮件类。
            var mailMessage = new MailService("huanyinglike@qq.com",ToAddress,Subject,Body);
            return mailMessage;
        }
        public void ToAddressAdd(string emailAddress)
        {
            this.To.Add(new MailAddress(emailAddress));
        }
        /// <summary>
        /// 发送邮件已经创建好的邮箱
        /// </summary>
        public void SendEmail()
        {

            //实例化一个SmtpClient类。
            using (SmtpClient client = new SmtpClient())
            {
                //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
                client.Host = "smtp.qq.com";
                //使用安全加密连接。
                client.EnableSsl = true;
//                client.Port = 587;
                //不和请求一块发送。
                client.UseDefaultCredentials = false;
                //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
                
                client.Credentials = new NetworkCredential("huanyinglike@qq.com", "ypolfyvtmebkegff");
                //发送
                client.Send(this);
            }
        }
        private void Page_Load(object sender, EventArgs e)
        {
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            mailMessage.From = new MailAddress("123456@qq.com");
            //收件人邮箱地址。
            mailMessage.To.Add(new MailAddress("654321@qq.com"));
            //邮件标题。
            mailMessage.Subject = "发送邮件测试";
            //邮件内容。
            mailMessage.Body = "这是我给你发送的第一份邮件哦！";

            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();
            //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.qq.com";
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送。
            client.UseDefaultCredentials = false;
            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            client.Credentials = new NetworkCredential("123456@qq.com", "fnsedjxib");
//            ServicePointManager.ServerCertificateValidationCallback =
//                delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };
            //发送
            client.Send(mailMessage);
        }

    }
}
