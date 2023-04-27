using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraRepository
{
    Task IncluirContaFinanceiraAsync(ContaFinanceira contaFinanceira);
    Task<IEnumerable<ContaFinanceiraResponse>> ObtemContaFinanceira(string idUser);
}
