namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class PessoaJuridicaCadastroRequest : PessoaCadastroRequest
{
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public decimal FaturamentoMensal { get; set; }
    public decimal FaturamentoAnual { get; set; }
}
