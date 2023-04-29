using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Infrastructure.Factory;

public class ContaFinanceiraFactory : IContaFinanceiraFactory
{
    public ContaFinanceira Create(ContaFinanceiraCadastroRequest contaFinanceira, Categoria? categoria)
    {
        if(categoria is null)
        {
            return new ContaFinanceira
           (
           contaFinanceira.ValorLancamento,
           contaFinanceira.TipoLancamento,
           new Categoria
               (contaFinanceira.Categoria.Nome,
               contaFinanceira.Categoria.Descricao,
               contaFinanceira.Categoria.Tipo.ToString())
           );
        }
        return new ContaFinanceira
              (
              contaFinanceira.ValorLancamento,
              contaFinanceira.TipoLancamento,
              categoria
              );
    }
}
