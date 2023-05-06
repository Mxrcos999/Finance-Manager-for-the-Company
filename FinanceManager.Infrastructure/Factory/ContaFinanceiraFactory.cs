using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Infrastructure.Factory;

public class ContaFinanceiraFactory : IContaFinanceiraFactory
{
    public ContaFinanceira Create(ContaFinanceiraCadastroRequest contaFinanceira, Categoria? categoria)
    {
        return new ContaFinanceira
              (
              contaFinanceira.ValorLancamento,
              contaFinanceira.TipoLancamento,
              categoria
              );
    }
}
