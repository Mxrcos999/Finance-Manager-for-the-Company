namespace FinanceManager.Application.DTOs.DtosResponse;

public sealed class PessoaFisicaResponse
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public decimal Saldo { get; set; }
    public DateTime DataNascimento { get; set; }
}
