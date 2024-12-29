using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Http;


namespace EmploymentSystem.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(Message message)
        {

            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message.Content;

            emailMessage.Body = bodyBuilder.ToMessageBody();

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            if (mailMessage.To.Count()!=0)
            {
                using (var client = new SmtpClient())
                {
                    try
                    {
                        client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                        client.Send(mailMessage);
                    }
                    catch
                    {
                        //log an error message or throw an exception or both.
                        throw new Exception("An Error Occured while sending email");
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }
            }
        }

        private string HTMLContene()
        {
            return "<!DOCTYPE html>\r\n<html lang=\"ar\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>EmploymentSystem</title>\r\n    <link href=\"https://fonts.googleapis.com/css2?family=Cairo:wght@400;600&display=swap\" rel=\"stylesheet\">\r\n    <style>\r\n        * {\r\n            margin: 0;\r\n            padding: 0;\r\n            box-sizing: border-box;\r\n            font-family: 'Cairo', sans-serif;\r\n        }\r\n        body {\r\n            background-color: #F4F4F4;\r\n        }\r\n        .container {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            padding: 30px;\r\n            background-color: #fff;\r\n            border-radius: 5px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n        .header {\r\n            text-align: center;\r\n            margin-bottom: 30px;\r\n        }\r\n        .header h1 {\r\n            font-size: 28px;\r\n            font-weight: bold;\r\n            color: #333;\r\n            margin-bottom: 10px;\r\n        }\r\n        .content {\r\n            text-align: center;\r\n            padding: 0 20px;\r\n            line-height: 1.6;\r\n            color: #333;\r\n        }\r\n        .button {\r\n            display: inline-block;\r\n            margin-top: 30px;\r\n            padding: 10px 20px;\r\n            background-color: #ECA10A;\r\n            color: #fff;\r\n            text-decoration: none;\r\n            border-radius: 5px;\r\n        }\r\n        .button:hover {\r\n            background-color: #D89D05;\r\n        }\r\n        .footer {\r\n            text-align: center;\r\n            margin-top: 30px;\r\n            color: #555;\r\n            font-size: 12px;\r\n        }\r\n        .footer a {\r\n            color: #555;\r\n        }\r\n        .footer a:hover {\r\n            color: #999;\r\n        }\r\n        .social-icons {\r\n            margin-top: 20px;\r\n            display: flex;\r\n            justify-content: center;\r\n        }\r\n        .social-icons a {\r\n            display: inline-block;\r\n            margin: 0 10px;\r\n            width: 30px;\r\n            height: 30px;\r\n            border-radius: 50%;\r\n            background-color: #ECA10A;\r\n            color: #fff;\r\n            text-align: center;\r\n            line-height: 30px;\r\n            text-decoration: none;\r\n        }\r\n        .social-icons a:hover {\r\n            background-color: #D89D05;\r\n        }\r\n        .social-icons a i {\r\n            font-size: 16px;\r\n        }\r\n        .social-icons a i.fa-facebook {\r\n            background-color: #3B5998;\r\n        }\r\n        .social-icons a i.fa-twitter {\r\n            background-color: #1DA1F2;\r\n        }\r\n        .social-icons a i.fa-instagram {\r\n            background-color: #C13584;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <h1>EmploymentSystem</h1>\r\n        </div>\r\n        <div class=\"content\">\r\n            <p>مرحبًا،</p>\r\n            <p>تم الموافقة على طلب حجز رحلتك. يرجى زيارة حسابك للتحقق من التفاصيل الحجز.</p>\r\n            <a href=\"#\" class=\"button\">زيارة حسابي</a>\r\n            <p>no thanks</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>تواصل معنا عبر مواقع التواصل الاجتماعي:</p>\r\n            <div class=\"social-icons\">\r\n                <a href=\"#\" target=\"_blank\"><i class=\"fab fa-facebook\"></i></a>\r\n                <a href=\"#\" target=\"_blank\"><i class=\"fab fa-twitter\"></i></a>\r\n                <a href=\"#\" target=\"_blank\"><i class=\"fab fa-instagram\"></i></a>\r\n            </div>\r\n            <p>© 2023 EmploymentSystem. جميع الحقوق محفوظة.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
        }

    }


}
