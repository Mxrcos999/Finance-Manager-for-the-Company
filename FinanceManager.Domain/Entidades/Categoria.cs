using FinanceManager.Domain.Utils;
using static FinanceManager.Domain.Entidades.Lancamento;

namespace FinanceManager.Domain.Entidades;

public class Categoria : EntidadeBase
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string Tipo { get; private set; }
    public int ContaFinanceiraId { get;  set; }
    public ICollection<Lancamento> Lancamento { get;  set; }
    public string UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }
    public Categoria() {}

    public Categoria(string nome, string descricao, string tipo)
    {
        Nome = nome;
        Descricao = descricao;  
        Tipo = tipo;
        DataHoraCadastro = DateTime.Now.ToUniversalTime();
    }

    public void Alterar(string nome, string descricao, string tipo)
    {
        Nome = nome;
        Descricao  = descricao;
        Tipo = tipo;
    }
    public enum TipoCategoria
    {
        Entrada,
        Saida
    }

}