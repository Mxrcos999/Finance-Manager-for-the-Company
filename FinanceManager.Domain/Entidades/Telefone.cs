using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Telefone : EntidadeBase
{
    public string Ddd { get; set; }
    public string Ddi { get; set; }
    public string Numero { get; set; }
    public bool Principal { get; set; }
    public string Ramal { get; set; }
    public string TipoTelefone { get; set; }
}
