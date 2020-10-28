using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    class Mail
    {
        private MailAddress sendAddress = null;
        private MailAddress toAddress = null;
        private string sendPassword = "lee960923";

        public Mail(string sendMail = "dydrkfsladl@gmail.com")
        {
            this.sendAddress = new MailAddress(sendMail);
        }
        public void SetToAddress(string toMail)
        {
            try
            {
                this.toAddress = new MailAddress(toMail);
            }catch(Exception err)
            {

            }
        }

        public string SendEmail(string subject, string body)
        {
            SmtpClient smtp = null;
            MailMessage message = null;
            try
            {
                smtp = new SmtpClient()
                {
                    Host = "smtp.gmail.com", //smtp.naver.com
                    EnableSsl = true,       //보안서버
                    DeliveryMethod = SmtpDeliveryMethod.Network,        //네트워크사용하여 전송
                    Credentials = new NetworkCredential(sendAddress.Address, sendPassword), //암호기반 인증체계에 자격증명
                    Timeout = 30000         //타입아웃
                };
                message = new MailMessage(sendAddress, toAddress)
                {
                    Subject = subject,      //제목설정
                    Body = body             //내용설정
                };
                smtp.Send(message);         //보냄
                return "send mail Ok";      //정상적으로 보냈으면
            }
            catch (Exception err)
            {
                return "send nail fail";
            }
            finally
            {
                if (smtp != null) { smtp.Dispose(); }//리소스 해제
                if (message != null) { message.Dispose(); }
            }
        }
    }
}
