﻿using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceManager.Infrastructure.Repository;

public class CategoriaRep : ICategoriaRep
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<ApplicationUser> _user;
    private readonly DbSet<Categoria> _categorias;
    private readonly DbSet<Lancamento> _lancamentos;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string IdUsuarioLogado;

    public CategoriaRep(FinanceManagerContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _user = context.Set<ApplicationUser>();
        _lancamentos = context.Set<Lancamento>();
        _categorias = context.Set<Categoria>();
        _unitOfWork = unitOfWork;
        IdUsuarioLogado = _context._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

    }

    public async Task<IEnumerable<CategoriaResponse>> ObterAsync(HistoricoQuery historicoQuery)
    {
        var lancamentosPorCategoria = _lancamentos
          .Where(historicoQuery.CreateFilterExpression(IdUsuarioLogado))
          .GroupBy(l => l.Categorias)
          .Select(g => new
          {
              Categoria = g.Key,
              TotalValor = g.Sum(l => l.ValorLancamento)
          });

        decimal totalValorLancamentos = _lancamentos
            .Where(historicoQuery.CreateFilterExpression(IdUsuarioLogado))
            .Sum(l => l.ValorLancamento);


        var categoriaTratada = from categoria in _categorias
                .AsNoTracking()
                .Where(c => c.UsuarioId == IdUsuarioLogado)
                .OrderByDescending(c => c.DataHoraCadastro)
                               select new CategoriaResponse()
                               {
                                   Id = categoria.Id,
                                   Nome = categoria.Nome,
                                   Descricao = categoria.Descricao,
                                   TipoCategoria = categoria.Tipo.ToString(),
                                   ColorCode = categoria.ColorCode,
                                   Porcentagem = lancamentosPorCategoria
                 .Where(lp => lp.Categoria.Id == categoria.Id)
                 .Select(lp => lp.TotalValor / totalValorLancamentos * 100)
                 .FirstOrDefault()
                               };

        return categoriaTratada.AsEnumerable();
    }

    public async Task<IEnumerable<CategoriaResponse>> IncluirAsync(Categoria categoria)
    {
        try
        {
            categoria.UsuarioId = IdUsuarioLogado;
            await _categorias.AddAsync(categoria);

            var result = await _unitOfWork.CommitAsync();

            if (result)
                return await ObterAsync(new HistoricoQuery());
            return null;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }

    }


    public async Task<Categoria> ObterCategoriaByIdAsync(int? idCategoria)
    {
        using (_unitOfWork.BeginTransactionAsync())
        {
            var categoria = await _categorias
                .Include(i => i.Lancamento)
               .Where(wh => wh.Id == idCategoria && wh.UsuarioId == IdUsuarioLogado).SingleOrDefaultAsync();

            if (categoria is null)
                return null;

            await _unitOfWork.CloseConnectionAsync();
            return categoria;
        }

    }

    public async Task<IEnumerable<CategoriaResponse>> AlterarAsync(Categoria categoria)
    {
        try
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                _categorias.Update(categoria);

                await transaction.CommitAsync();

                var result = await _unitOfWork.CommitAsync();
                if (result)
                    return await ObterAsync(new HistoricoQuery());
                return null;

            }
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
