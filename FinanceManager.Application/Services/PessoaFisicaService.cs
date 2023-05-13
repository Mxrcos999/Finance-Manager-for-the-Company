using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;

namespace FinanceManager.Application.Services;

public class PessoaFisicaService : IPessoaFisicaService
{
    private readonly IPessoaFisicaRep _pessoaFisicaRep;

    public PessoaFisicaService(IPessoaFisicaRep pessoaFisicaRep)
    {
        _pessoaFisicaRep = pessoaFisicaRep;
    }

    public async Task<PessoaFisicaResponse> ObterAsync()
    {
        return await _pessoaFisicaRep.ObterAsync();
    }
}
