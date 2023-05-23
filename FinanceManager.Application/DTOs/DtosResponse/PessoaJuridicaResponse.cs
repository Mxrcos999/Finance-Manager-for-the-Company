using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.DTOs.DtosResponse;

public sealed class PessoaJuridicaResponse
{
    public string Email { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public decimal Saldo { get; set; }
    public DateTime DataAberturaEmpresa { get; set; }
    public DateTime DataCriacaoConta { get; set; }
}
