namespace FinanceManager.Domain.Entidades;

public abstract class Pessoa
{
    public int Id { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public DateTime DataHoraAlteração { get; set; }
    public List<Endereco> Enderecos { get; private set; }
    public List<Telefone> Telefones { get; private set; }
    public List<string> Email { get; private set; }

    public Pessoa(List<Endereco> enderecos, List<Telefone> telefones, List<string> email)
    {
        Enderecos = enderecos;
        Telefones = telefones;
        Email = email;
    }
    public Pessoa()
    {

    }
}
