using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Telefone : EntidadeBase
{
    public string Ddd { get; private set; }
    public string Ddi { get; private set; }
    public string Numero { get; private set; }
    public bool Principal { get; private set; }
    public string TipoTelefone { get; private set; }

    public Telefone(string ddd, string ddi, string numero, bool principal, string tipoTelefone)
    {
        Ddd = ddd;
        Ddi = ddi;
        Numero = numero;
        Principal = principal;
        TipoTelefone = tipoTelefone;
    }
    public Telefone()
    {
        
    }
}
