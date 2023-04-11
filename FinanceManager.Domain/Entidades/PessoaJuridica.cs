using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class PessoaJuridica : EntidadeBase
{
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public decimal FaturamentoMensal { get; set; }
    public decimal FaturamentoANual { get; set; }
}
