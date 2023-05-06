namespace FinanceManager.Domain.Entidades;

public abstract class Pessoa
{
    public int Id { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public DateTime DataHoraAlteração { get; set; }
    public ICollection<Endereco>? Enderecos { get; private set; }
    public ICollection<Telefone>? Telefones { get; private set; }
    public string[]? Email { get; private set; }

    public Pessoa(ICollection<Endereco> enderecos, ICollection<Telefone> telefones, string[] email)
    {
        Enderecos = enderecos;
        Telefones = telefones;
        Email = email;

    }
    public Pessoa()
    {

    }
}
