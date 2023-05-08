using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Factory;
using System.Data;

namespace FinanceManager.Application.Services;

public class ContaFinanceiraService : IContaFinanceiraService
{
    private readonly IContaFinanceiraRepository _contaFinanceiraRepository;
    private readonly ICategoriaRep _categoriaRep;

    public ContaFinanceiraService(IContaFinanceiraRepository contaFinanceiraRepository, ICategoriaRep categoriaRep)
    {
        _contaFinanceiraRepository = contaFinanceiraRepository;
        _categoriaRep = categoriaRep;
    }
    public async Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras(HistoricoQuery historicoQuery)
    {
        return await _contaFinanceiraRepository.ObtemContaFinanceira(historicoQuery);
    }

    public async Task<IEnumerable<ContaFinanceiraResponse>> IncluirContaFinanceira(ContaFinanceiraCadastroRequest contaFinanceira)
    {
        var categoriaObtida = await _categoriaRep.ObterCategoriaByIdAsync(contaFinanceira.CategoriaId);

        if (categoriaObtida is null)
            throw new DataException("Não foi encontrada nenhuma categoria com o id informado", new Exception("Não foi encontrada nenhuma categoria com o id informado"));

        var contaFinanceriaInserir = ContaFinanceiraFactory.Create(contaFinanceira.ValorLancamento, contaFinanceira.TipoLancamento, categoriaObtida);

        var historicoAtualizado = await _contaFinanceiraRepository.IncluirContaFinanceiraAsync(contaFinanceriaInserir);

        if (historicoAtualizado is null)
            return null;

        return historicoAtualizado;
    }
}



