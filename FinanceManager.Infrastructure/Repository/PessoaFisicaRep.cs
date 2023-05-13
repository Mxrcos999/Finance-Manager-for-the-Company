using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceManager.Infrastructure.Repository;

public class PessoaFisicaRep : IPessoaFisicaRep
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<ApplicationUser> _user;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly string IdUsuarioLogado;

    public PessoaFisicaRep(FinanceManagerContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _user = context.Set<ApplicationUser>();
        _userManager = userManager;
        IdUsuarioLogado = _context._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
    public async Task<PessoaFisicaResponse> ObterAsync()
    {
        var pessoaFisica = await (from pessoa in _user
                           .Include(i => i.PessoaFisica)
                           .AsNoTracking()
                           .Where(wh => wh.Id == IdUsuarioLogado)
                           select new PessoaFisicaResponse()
                           {
                               DataCriacaoConta = pessoa.PessoaFisica.DataHoraCadastro,
                               Nome = pessoa.PessoaFisica.Nome,
                               Email = pessoa.Email,
                               DataNascimento = pessoa.PessoaFisica.DataNascimento,
                               Saldo = pessoa.Saldo
                           }).SingleOrDefaultAsync();

        return pessoaFisica;
    }
}
