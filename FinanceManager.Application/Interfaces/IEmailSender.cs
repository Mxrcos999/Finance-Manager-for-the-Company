namespace FinanceManager.Application.Interfaces;

public interface IEmailSender
{
    void SendEmail(string assuntoEmail, string destinatarios, string corpoEmail);
}
