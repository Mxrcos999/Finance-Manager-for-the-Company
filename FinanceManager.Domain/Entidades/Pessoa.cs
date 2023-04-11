using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Pessoa : EntidadeBase
{
    public List<Endereco> Enderecos { get; set; }
    public List<Telefone> Telefones { get; set; }
    public List<string> Email { get; set; }
    public PessoaFisica PessoaFisica { get; set; }
    public PessoaJuridica PessoaJuridica { get; set; }
}
