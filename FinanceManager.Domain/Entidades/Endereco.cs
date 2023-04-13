using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Endereco : EntidadeBase
{
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Cep { get; private set; }
    public string TipoLogradouro { get; private set; }
    public Endereco(string logradouro, string numero, string cep, string tipoLogradouro)
    {
        Logradouro = logradouro;
        Numero = numero;
        Cep = cep;
        TipoLogradouro = tipoLogradouro;
    }

    public Endereco()
    {
        
    }
}
