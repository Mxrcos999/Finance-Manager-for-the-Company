using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraRepository
{
    Task<IEnumerable<ContaFinanceiraResponse>> ObtemContaFinanceira();
    Task IncluirContaFinanceiraAsync(ContaFinanceira contaFinanceira);
    Task<Categoria> ObterCategoriaByIdAsync(int? idCategoria);
}
