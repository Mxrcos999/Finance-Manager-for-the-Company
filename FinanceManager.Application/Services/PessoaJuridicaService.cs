using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;

namespace FinanceManager.Application.Services;

public class PessoaJuridicaService : IPessoaJuridicaService
{
    private readonly IPessoaJuridicaRep _pessoaJuridicaRep;

    public PessoaJuridicaService(IPessoaJuridicaRep pessoaJuridicaRep)
    {
        _pessoaJuridicaRep = pessoaJuridicaRep;
    }

    public async Task<PessoaJuridicaResponse> Obtersync()
    {
        return await _pessoaJuridicaRep.ObterAsync();
    }
}
