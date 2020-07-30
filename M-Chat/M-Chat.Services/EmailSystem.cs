using System;
using System.Collections.Generic;
using System.Text;

namespace M_Chat.Services
{
    public class EmailSystem:EnviarEmail
    {
        public EmailSystem()
        {
            Remitente = "rojasbarreragbriel@gmail.com";
            Password = "Aa@4Marzo1995";
            Host = "smtp.gmail.com";
            Port = 587;
            Ssl = true;
            IniciarSmtpClient();
        }
    }
}
