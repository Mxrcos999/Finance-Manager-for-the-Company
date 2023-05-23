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
    private readonly string IdUsuarioLogado;

    public PessoaJuridicaRep(FinanceManagerContext context)
    {
        _context = context;
        _user = context.Set<ApplicationUser>();
        IdUsuarioLogado = _context._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
    public async Task<PessoaJuridicaResponse> ObterAsync()
    {
        var pessoaJuridica = await (from pessoa in _user
                            .AsNoTracking()
                            .Include(i => i.PessoaJuridica)
                            .Where(wh => wh.Id == IdUsuarioLogado)
                            select new PessoaJuridicaResponse()
                            {
                                TipoUsuario = pessoa.TipoUsuario,
                                RazaoSocial = pessoa.PessoaJuridica.RazaoSocial,
                                Cnpj = pessoa.PessoaJuridica.Cnpj,
                                DataAberturaEmpresa = pessoa.PessoaJuridica.DataAberturaEmpresa,
                                DataCriacaoConta = pessoa.PessoaJuridica.DataHoraCadastro,
                                Email = pessoa.Email,
                                Saldo = pessoa.Saldo
                            }).SingleOrDefaultAsync();
        return pessoaJuridica;
    }
}
