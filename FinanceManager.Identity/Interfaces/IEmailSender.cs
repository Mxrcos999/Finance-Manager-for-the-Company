namespace FinanceManager.Identity.Interfaces;

public interface IEmailSender
{
    void SendEmail(string assuntoEmail, string remetente, string destinatarios, string corpoEmail);
}
