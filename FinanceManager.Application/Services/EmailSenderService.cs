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
        var client = new SmtpClient("smtp.titan.email", 587)
        {
            Credentials = new System.Net.NetworkCredential("rodrigo@formulasecretaseducao.com.br", "Quita123*"),
            EnableSsl = false
        };
        return client;

    }

    public void SendEmail(string nome, string destinatarios, string token)
    {
        if ( string.IsNullOrEmpty(destinatarios) ||      
        string.IsNullOrEmpty(nome) ||
        string.IsNullOrEmpty(token))
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
            mm.Subject = $"Bem vindo a Cronus finance!";
            mm.IsBodyHtml = true;
            mm.Body = $"<p> Olá, {nome}<br> Bem vindo a Cronus Finance! Por favor confirme seu email no link abaixo <br> link: {token} </p>";
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