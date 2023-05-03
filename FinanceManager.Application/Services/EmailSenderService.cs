using FinanceManager.Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Text;

namespace FinanceManager.Application.Services;

public class EmailSender : IEmailSender
{
    private readonly EmailSenderOptions _options;

    public EmailSender(IOptions<EmailSenderOptions> options)
    {
        _options = options.Value;
    }
    private SmtpClient ObterClient()
    {
        var client = new SmtpClient(_options.Host, _options.Port)
        {
            Credentials = new System.Net.NetworkCredential(_options.Username, _options.Password),
            EnableSsl = false
        };
        return client;

    }

    public void SendEmail(string assuntoEmail, string destinatarios, string corpoEmail)
    {
        if ( string.IsNullOrEmpty(destinatarios) ||      
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
public class EmailSenderOptions
{
    public string FromName { get; set; }
    public string FromEmail { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}