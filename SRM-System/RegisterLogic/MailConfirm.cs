using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.RegisterLogic
{
    public class MailConfirm
    {
        private static int confirmCode = 1111;   
        public static int GenerateConfirmCode()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
        public void SendConfirmMessage(string RecipientAdress)
        {
            confirmCode = GenerateConfirmCode();
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("crm_system_okvsu@mail.ru", "System");
            // кому отправляем
            MailAddress to = new MailAddress(RecipientAdress);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Подтверждение адреса электронной почты";
            // текст письма
            m.Body = $"Код для подтверждения электронной почты: {confirmCode}";
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("crm_system_okvsu@mail.ru", "LWSLefErHjyk44tYCwet");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public static bool CheckMailMath(string UserCode)
        {
            if (confirmCode.ToString() == UserCode)
                return true;
            else
                return false;
        }
    }
}
