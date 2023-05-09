
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceManager.Infrastructure.Repository;

public class CategoriaRep : ICategoriaRep
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<ApplicationUser> _user;
    private readonly DbSet<Categoria> _categorias;
    private readonly DbSet<ContaFinanceira> _lancamentos;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string IdUsuarioLogado;

    public CategoriaRep(FinanceManagerContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _user = context.Set<ApplicationUser>();
        _lancamentos = context.Set<ContaFinanceira>();
        _categorias = context.Set<Categoria>();
        _unitOfWork = unitOfWork;
        IdUsuarioLogado = _context._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

    }

    public async Task<IEnumerable<CategoriaResponse>> ObterAsync()
    {
        var lancamentosPorCategoria = _lancamentos
          .Where(l => l.UsuarioId == IdUsuarioLogado)
          .GroupBy(l => l.Categorias)
          .Select(g => new
          {
              Categoria = g.Key,
              TotalValor = g.Sum(l => l.ValorLancamento)
          });

        decimal totalValorLancamentos = _lancamentos
            .Where(l => l.UsuarioId == IdUsuarioLogado)
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
                                   Porcentagem = lancamentosPorCategoria
                 .Where(lp => lp.Categoria.Id == categoria.Id)
                 .Select(lp => lp.TotalValor / totalValorLancamentos * 100)
                 .FirstOrDefault() };

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
                return await ObterAsync();
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
        var categoria = await _categorias
            .Where(wh => wh.Id == idCategoria && wh.UsuarioId == IdUsuarioLogado).SingleOrDefaultAsync();

        if (categoria is null)
            return null;

        return categoria;
    }
}
