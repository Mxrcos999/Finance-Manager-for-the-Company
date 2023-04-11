using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Endereco : EntidadeBase
{
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public string TipoLogradouro { get; set; }
}
