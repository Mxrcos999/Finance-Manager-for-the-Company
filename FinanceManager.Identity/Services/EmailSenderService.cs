using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using FinanceManager.Identity.Interfaces;
using System.Diagnostics;
using System.Text;

namespace FinanceManager.Identity.Services;

public class EmailSender : IEmailSender
{
    private readonly EmailSenderOptions _options;

    public EmailSender(IOptions<EmailSenderOptions> options)
    {
        _options = options.Value;
    }
    private SmtpClient ObterClient()
    {
        var client = new SmtpClient("smtp.titan.email", 587)
        {
            Credentials = new System.Net.NetworkCredential("rodrigo@formulasecretaseducao.com.br", "Quita123*"),
            EnableSsl = false
        };
        return client;

    }

    public void SendEmail(string assuntoEmail, string remetente, string destinatarios, string corpoEmail)
    {
        if (string.IsNullOrEmpty(remetente) ||
        string.IsNullOrEmpty(destinatarios) ||
        string.IsNullOrEmpty(assuntoEmail) ||
        string.IsNullOrEmpty(corpoEmail))
        {
            throw new ArgumentException("Os parâmetros remetente, destinatário, assunto e corpoo do email são obrigatórios.");
        }
        var listaDestinatarios = destinatarios.Split(",");
        using (var mm = new MailMessage("rodrigo@formulasecretaseducao.com.br", listaDestinatarios[0]))
        {
            foreach (var emailAtual in listaDestinatarios)
            {
                mm.To.Add(new MailAddress(emailAtual.TrimStart().TrimEnd()));
            }
            mm.Subject = $"{assuntoEmail}";
            mm.IsBodyHtml = true;
            mm.Body = $"<p> {corpoEmail} </p>";
            mm.SubjectEncoding = Encoding.GetEncoding("UTF-8");
            mm.BodyEncoding = Encoding.GetEncoding("UTF-8");
            using (var client = ObterClient())
            {
                client.Send(mm);
            }
        }
    }
}
//using System.Net.Mail;
//using System.Text;
//using Tss.Tse.Services.Comunicacao.Domain;
//using Tss.Tse.Services.Comunicacao.Interfaces;

//namespace Tss.Tse.Services.Comunicacao.Services
//{
//    public class SvcEmail : ISvcEmail
//    {
//        private readonly CredenciaisEmail _credenciais;
//        public SvcEmail(CredenciaisEmail credenciais)
//        {
//            if (string.IsNullOrEmpty(credenciais.UsernameSmtp) &&
//                 string.IsNullOrEmpty(credenciais.SenhaSmtp) &&
//                 string.IsNullOrEmpty(credenciais.HostSmtp))
//                throw new ArgumentNullException();
//            _credenciais = credenciais;
//        }

//        private SmtpClient ObterClient()
//        {
//            var client = new SmtpClient(_credenciais.HostSmtp, _credenciais.PortaSmtp)
//            {
//                Credentials = new System.Net.NetworkCredential(_credenciais.UsernameSmtp, _credenciais.SenhaSmtp),
//                EnableSsl = _credenciais.UsarSsl
//            };
//            return client;

//        }

//        public void EnviaEmail(string assuntoEmail, string remetente, string destinatarios, string corpoEmail)
//        {
//            if (string.IsNullOrEmpty(remetente) ||
//            string.IsNullOrEmpty(destinatarios) ||
//            string.IsNullOrEmpty(assuntoEmail) ||
//            string.IsNullOrEmpty(corpoEmail))
//            {
//                throw new ArgumentException("Os parâmetros remetente, destinatário, assunto e corpoo do email são obrigatórios.");
//            }
//            var listaDestinatarios = destinatarios.Split(",");
//            using (var mm = new MailMessage(remetente, listaDestinatarios[0]))
//            {
//                foreach (var emailAtual in listaDestinatarios)
//                {
//                    mm.To.Add(new MailAddress(emailAtual.TrimStart().TrimEnd()));
//                }
//                mm.Subject = $"{assuntoEmail}";
//                mm.IsBodyHtml = true;
//                mm.Body = $"<p> {corpoEmail} </p>";
//                mm.SubjectEncoding = Encoding.GetEncoding("UTF-8");
//                mm.BodyEncoding = Encoding.GetEncoding("UTF-8");
//                using (var client = ObterClient())
//                {
//                    client.Send(mm);
//                }
//            }
//        }
//    }
//}
public class EmailSenderOptions
{
    public string FromName { get; set; }
    public string FromEmail { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}