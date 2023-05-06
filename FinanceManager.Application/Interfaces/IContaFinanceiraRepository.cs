﻿using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraRepository
{
    Task<IEnumerable<ContaFinanceiraResponse>> ObtemContaFinanceira(string idUser);
    Task IncluirContaFinanceiraAsync(ContaFinanceira contaFinanceira, ApplicationUser user);
    Task<Categoria> ObterCategoriaByNomeAsync(int? idCategoria);
}
