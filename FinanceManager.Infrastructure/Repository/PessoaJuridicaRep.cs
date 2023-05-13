using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceManager.Infrastructure.Repository;

public class PessoaJuridicaRep : IPessoaJuridicaRep
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<ApplicationUser> _user;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly string IdUsuarioLogado;

    public PessoaJuridicaRep(FinanceManagerContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _user = context.Set<ApplicationUser>();
        _userManager = userManager;
    }
    public async Task<PessoaJuridicaResponse> ObterAsync()
    {
        var pessoa = await (from pessoaJuridica in _user
                            .AsNoTracking()
                            .Include(i => i.PessoaJuridica)
                            .Where(wh => wh.Id == IdUsuarioLogado)
                            select new PessoaJuridicaResponse()
                            {
                                RazaoSocial = pessoaJuridica.PessoaJuridica.RazaoSocial,
                                DataAberturaEmpresa = pessoaJuridica.PessoaJuridica.DataAberturaEmpresa,
                                Email = pessoaJuridica.Email,
                                Saldo = pessoaJuridica.Saldo
                            }).SingleOrDefaultAsync();
        return pessoa;
    }
}
