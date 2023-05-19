using FinanceManager.Domain.Entidades;

namespace FinanceManager.Domain.Factory;

public static class CategoriaFactory
{
    public static Categoria Create(string nome, string descricao, string tipo, string colorCode)
    {
        return new Categoria(nome, descricao, tipo, colorCode);
    }
}
