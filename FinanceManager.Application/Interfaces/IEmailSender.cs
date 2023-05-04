namespace FinanceManager.Application.Interfaces;

public interface IEmailSender
{
    void SendEmail(string nome, string destinatarios, string token);
}
