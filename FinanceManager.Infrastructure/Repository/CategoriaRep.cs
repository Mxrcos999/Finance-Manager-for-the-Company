
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
    private readonly string IdUsuarioLogado;

    public CategoriaRep(FinanceManagerContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _user = context.Set<ApplicationUser>();
        _categorias = context.Set<Categoria>();
        _unitOfWork = unitOfWork;
        IdUsuarioLogado = _context._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

    }

    public async Task<IEnumerable<CategoriaResponse>> ObterAsync()
    {
        var categoriaObtida = from categoria in _categorias
                      .AsNoTracking()
                      .Where(wh => wh.UsuarioId == IdUsuarioLogado)
                      .OrderBy(ob => ob.DataHoraCadastro)
                              select new CategoriaResponse()
                              {

                                  Nome = categoria.Nome,
                                  Descricao = categoria.Descricao,
                                  TipoCategoria = categoria.Tipo.ToString()

                              };
        return categoriaObtida.AsEnumerable();
    }

    public async Task IncluirAsync(Categoria categoria)
    {
        try
        {
            await _categorias.AddAsync(categoria);

            await _unitOfWork.CommitAsync();
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
