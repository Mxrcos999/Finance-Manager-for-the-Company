using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Factory;
using System.Data;

namespace FinanceManager.Application.Services;

public class LancamentoService : ILancamentoService
{
    private readonly ILancamentoRep _contaFinanceiraRepository;
    private readonly ICategoriaRep _categoriaRep;

    public LancamentoService(ILancamentoRep contaFinanceiraRepository, ICategoriaRep categoriaRep)
    {
        _contaFinanceiraRepository = contaFinanceiraRepository;
        _categoriaRep = categoriaRep;
    }
    public async Task<IEnumerable<LancamentoResponse>> ObterContasFinanceiras(HistoricoQuery historicoQuery)
    {
        return await _contaFinanceiraRepository.ObtemContaFinanceira(historicoQuery);
    }

    public async Task<IEnumerable<LancamentoResponse>> IncluirContaFinanceira(LancamentoCadastroRequest lancamento)
    {
        var categoriaObtida = await _categoriaRep.ObterCategoriaByIdAsync(lancamento.CategoriaId);

        if (categoriaObtida is null)
            throw new DataException("Não foi encontrada nenhuma categoria com o id informado", new Exception("Não foi encontrada nenhuma categoria com o id informado"));

        var contaFinanceriaInserir = LancamentoFactory.Create(lancamento.ValorLancamento, lancamento.TipoLancamento, categoriaObtida, lancamento.TituloLancamento);

        var historicoAtualizado = await _contaFinanceiraRepository.IncluirContaFinanceiraAsync(contaFinanceriaInserir);

        if (historicoAtualizado is null)
            return null;

        return historicoAtualizado;
    }
}



