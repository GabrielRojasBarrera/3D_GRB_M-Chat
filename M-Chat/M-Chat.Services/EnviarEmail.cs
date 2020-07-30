using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace M_Chat.Services
{
    public class EnviarEmail
    {
        private SmtpClient smtpClient;
        private string remitente;
        private string password;
        private string host;
        private int port;
        private bool ssl;

        protected string Remitente { get => remitente; set => remitente = value; }
        protected string Password { get => password; set => password = value; }
        protected string Host { get => host; set => host = value; }
        protected int Port { get => port; set => port = value; }
        protected bool Ssl { get => ssl; set => ssl = value; }

        protected void IniciarSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(remitente, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }
        public void EnviarCorreo(string Asunto, string Cuerpo, List<string> Destinatarios, Attachment file)
        {
            var MensajeDeCorreo = new MailMessage();
            try
            {
                MensajeDeCorreo.From = new MailAddress(remitente);
                foreach (string correos in Destinatarios)
                {
                    MensajeDeCorreo.To.Add(correos);
                }
                MensajeDeCorreo.Subject = Asunto;
                MensajeDeCorreo.Body = Cuerpo;
                MensajeDeCorreo.Priority = MailPriority.Normal;
                MensajeDeCorreo.Attachments.Add(file);
                smtpClient.Send(MensajeDeCorreo);
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                MensajeDeCorreo.Dispose();
                smtpClient.Dispose();
            }
        }
        
    }
}
