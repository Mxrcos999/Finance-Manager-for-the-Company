namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class EmpregadorCadastroRequest
{
    public decimal ValorPago { get; set; }
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public bool EmpresaAtual { get; set; }
}
