using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Endereco : EntidadeBase
{
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Cep { get; private set; }
    public string TipoLogradouro { get; private set; }
    public string Uf { get; private set; }
    public Endereco(string logradouro, string numero, string uf, string cep, string tipoLogradouro)
    {
        Logradouro = logradouro;
        Numero = numero;
        Uf = uf;
        Cep = cep;
        TipoLogradouro = tipoLogradouro;
        DataHoraCadastro = DateTime.Now.ToUniversalTime();
    }

    public Endereco()
    {
        
    }

    public enum TiposLogradouro
    {
        Residencial,
        Comercial
    }
}
