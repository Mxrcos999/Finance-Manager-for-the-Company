using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraFactory
{
    ContaFinanceira Create(ContaFinanceiraCadastroRequest contaFinanceira, Categoria categoria);
}
