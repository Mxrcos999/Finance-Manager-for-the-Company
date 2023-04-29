﻿using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain;
using FinanceManager.Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repository;

public class ContaFinanceiraRepository : IContaFinanceiraRepository
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<ContaFinanceira> _contaFinanceiras;
    private readonly DbSet<ApplicationUser> _user;
    private readonly IUnitOfWork _unitOfWork;


    public ContaFinanceiraRepository(FinanceManagerContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _contaFinanceiras = context.Set<ContaFinanceira>();
        _user = context.Set<ApplicationUser>();
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ContaFinanceiraResponse>> ObtemContaFinanceira(string idUser)
    {
        var contas = from Contas in _contaFinanceiras
                       .AsNoTracking()
                       .Include(i => i.Categorias)
                       .Where(wh => wh.UsuarioId == idUser)
                     select new ContaFinanceiraResponse()
                     {
                         Datalancamento = Contas.Datalancamento,
                         TipoLancamento = Contas.TipoLancamento.ToString(),
                         ValorLancamento = Contas.ValorLancamento,
                         Categoria = new CategoriaResponse()
                         {
                             Nome = Contas.Categorias.Nome,
                             Descricao = Contas.Categorias.Descricao,
                             TipoCategoria = Contas.Categorias.Tipo.ToString()
                         }
                         
                     };
        return contas.AsEnumerable();
    }

    public async Task IncluirContaFinanceiraAsync(ContaFinanceira contaFinanceira, ApplicationUser user)
    {
        try
        {
            _user.Update(user);
            await _contaFinanceiras.AddAsync(contaFinanceira);
            await _unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            await _unitOfWork.Rollback();
            throw;
        }
    }
}