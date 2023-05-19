
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
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaRep(FinanceManagerContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _user = context.Set<ApplicationUser>();
        _categorias = context.Set<Categoria>();
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CategoriaResponse>> ObtemCategoria(string idUser)
    {
        var categoriaObtida = from categoria in _categorias
                      .AsNoTracking()
                      .Include(i => i.)
                      .Where(wh => wh.UsuarioId == IdUsuarioLogado)
                      .OrderBy(ob => ob.Datalancamento)
                     select new ContaFinanceiraResponse()
                     {
                         SaldoAtual = Contas.Usuario.Saldo,
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

    {
        Task ICategoriaRep.IncluirCategoriaAsync(Categoria categoria, ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<CategoriaResponse>> ICategoriaRep.ObtemCategoria(string idUser)
    {
        throw new NotImplementedException();
    }

    Task<Categoria> ICategoriaRep.ObterCategoriaByNomeAsync(int? idCategoria)
    {
        throw new NotImplementedException();
    }
}
