namespace FinanceManager.Application.DTOs.DtosResponse;

public sealed class PessoaJuridicaResponse
{
    public string Email { get; set; }
    public string RazaoSocial { get; set; }
    public decimal Saldo { get; set; }
    public DateTime DataAberturaEmpresa { get; set; }
}
